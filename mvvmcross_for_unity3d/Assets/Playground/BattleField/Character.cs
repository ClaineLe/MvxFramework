using UnityEngine;

namespace Playground.BattleField
{
    public class Character : BattleUnit
    {
        public GameObject RenderUnit;
        
        public Character() {
            regAttribute<HpAttribute>();
            regAttribute<MpAttribute>();
        }

        public int GetHP()
        {
            var hp = this.GetAttributeValue(1001);
            var hpAddValue = this.GetAttributeValue(1002);
            return hp + hpAddValue;
        }
    }
}