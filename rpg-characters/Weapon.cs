using System;


namespace rpg_characters
{
    public class Weapon
    {
        public string ItemName { get; set; }
        public int RequiredLevel { get; set; }
        public Enum ItemSlot { get; set; }
        public Enum TypeOfWeapon { get; set; }

        public int Damage { get; set; }
        public double AttackSpeed { get; set; }
    }
}
