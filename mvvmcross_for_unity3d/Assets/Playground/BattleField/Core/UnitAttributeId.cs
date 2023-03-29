namespace Playground.BattleField
{
    public class UnitAttributeId : System.Attribute
    {
        public int Id { get; }

        public UnitAttributeId(int id)
        {
            this.Id = id;
        }
    }
}