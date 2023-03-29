namespace Playground.BattleField
{
    public class Battle
    {
        private readonly Character _character = new Character();

        public void Test()
        {
            _character.SetAttributeValue<HpAttribute>(20);
            _character.SetAttributeValue(1001, 20);

            _character.SetAttributeValue<MpAttribute>(20);
            _character.SetAttributeValue(1002, 20);

            _character.GetAttributeValue<HpAttribute>();
            _character.GetAttributeValue(1001);

            _character.GetAttributeValue<MpAttribute>();
            _character.GetAttributeValue(1002);
        }
    }
}