using System;


namespace rpg_characters
{
    public class Armour
    {
        public string ItemName { get; set; }
        public int RequiredLevel { get; set; }
        public Enum ItemSlot { get; set; }
        public Enum ArmourType { get; set; }

        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
    }
}
