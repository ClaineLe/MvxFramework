using System.Collections.Generic;
using System.Reflection;
using MvvmCross.IoC;

namespace Playground.BattleField
{
    public abstract class BattleUnit
    {
        private Dictionary<string, int> attrNameToIdMapping = new Dictionary<string, int>();
        private Dictionary<int, UnitAttribute> attrDict = new Dictionary<int, UnitAttribute>();

        protected BattleUnit()
        {
        }

        public void regAttribute<T>(int defValue = 0) where  T : UnitAttribute, new ()
        {
            var attrType = typeof(T); 
            var attrId = attrType.GetCustomAttribute<UnitAttributeId>().Id;
            attrNameToIdMapping.Add(attrType.Name, attrId);
            attrDict.Add(attrId, new T { Value = defValue });
        }

        public int GetAttributeValue<T>(int defReturn = 0) where T : UnitAttribute
        {
            if (attrNameToIdMapping.TryGetValue(typeof(T).Name, out var attrId) == false)
                return defReturn;

            return GetAttributeValue(attrId, defReturn);
        }

        public int GetAttributeValue(int attrId, int defReturn = 0)
        {
            if (attrDict.TryGetValue(attrId, out var attribute) == false)
                return defReturn;

            return attribute.Value;
        }

        public bool SetAttributeValue<T>(int value = 0) where T : UnitAttribute
        {
            if (attrNameToIdMapping.TryGetValue(typeof(T).Name, out var attrId) == false)
                return false;
            return SetAttributeValue(attrId, value);
        }

        public bool SetAttributeValue(int attrId, int value)
        {
            if (attrDict.TryGetValue(attrId, out var attribute) == false)
                return false;

            attribute.Value = value;
            return true;
        }
    }
}