using System;
using System.Collections.Generic;


namespace rpg_characters
{
    public class Mage : BaseAttributes
    {
        public string name = ""; // Name can be changed from outside

        private static Dictionary<Slot, double> mySlot = new Dictionary<Slot, double>(); // mySlot
        private static Dictionary<int, WeaponType> AllowedWeaponType = new Dictionary<int, WeaponType>(); // AllowedWeaponType
        private static Dictionary<int, ArmourType> AllowedArmourType = new Dictionary<int, ArmourType>(); // AllowedArmourType

        protected void TotalAttrributeCalculation() // That's my understanding how it should work
        {
            double TotalAttribute = ActualItelligence + ActualDexterity + ActualStrength + (ActualItelligence * 100 / 1);
            double AmourAttributes = 0;
            double TotalCharacterDamage = 0;
            if (mySlot[Slot.SLOT_BODY] != 0) { AmourAttributes = BaseIntelligence + BaseDexterity + BaseStrength + mySlot[Slot.SLOT_BODY]; }
            if (mySlot[Slot.SLOT_HEAD] != 0) { AmourAttributes = AmourAttributes + BaseIntelligence + BaseDexterity + mySlot[Slot.SLOT_HEAD]; }
            if (mySlot[Slot.SLOT_LEGS] != 0) { AmourAttributes = AmourAttributes + BaseIntelligence + BaseDexterity + mySlot[Slot.SLOT_LEGS]; }
            TotalAttribute = TotalAttribute + AmourAttributes;

            DPS = mySlot[Slot.SLOT_WEAPON]; // Is already calculated in EquipWeapon()
            // DPS * (1 + Total Attribute / 100)
            TotalCharacterDamage = DPS * (1 + TotalAttribute / 100);

            Console.WriteLine("TotalCharacterDamage: " + TotalCharacterDamage);
        }

        public Mage()
        {
            // Initializing
            BaseLevel = 1;
            BaseDexterity = 1;
            BaseStrength = 1;
            BaseIntelligence = 8;
            BaseAttackSpeed = 0;
            HeadStrength = 0;
            BodyStrength = 0;
            LegsStrength = 0;
            TotalArmourAttributes = 0;

            CharacterClass = "Mage";

            // The Armour and weapon Slots
            mySlot.Add(Slot.SLOT_HEAD, 0); // Value is Attribute + given Value
            mySlot.Add(Slot.SLOT_BODY, 0); // Value is Attribute + given Value
            mySlot.Add(Slot.SLOT_LEGS, 0); // Value is Attribute + given Value
            mySlot.Add(Slot.SLOT_WEAPON, 1); // Value is DPS

            // Allowed weapons (could be increased later)
            AllowedWeaponType.Add(0, WeaponType.WEAPON_STAFF);
            AllowedWeaponType.Add(1, WeaponType.WEAPON_WAND);

            // Allowed armour type (could be increased later)
            AllowedArmourType.Add(0, ArmourType.ARMOUR_CLOTH);
        }

        public void LevelUp() // Affectes the base values
        {
            BaseStrength++;
            BaseDexterity++;
            BaseIntelligence += 5;
            BaseLevel++;
            BaseDamage = 1;
            ActualStrength = BaseStrength;
            ActualItelligence = BaseIntelligence;
            ActualDexterity = BaseDexterity;
            ActualAttackSpeed = BaseIntelligence;
            TotalAttributes = BaseStrength + BaseDexterity + BaseIntelligence;
            Console.WriteLine($"{CharacterClass} was levelled up!");
            TotalAttrributeCalculation();
        }

        public void EquipWeapon(Weapon weapon)
        {
            Console.WriteLine("\nRetrieving Weapon for " + CharacterClass + ": " + weapon.TypeOfWeapon);
            bool found = false;

            for (int i = 0; i < AllowedWeaponType.Count; i++)
            {
                if (AllowedWeaponType[i].Equals(weapon.TypeOfWeapon)) // Is the weapon allowed to wear?
                {
                    found = true;
                    break;
                }
            }
            if (found == false) throw new InvalidWeaponException(); // as required, get off if not allowed
            if (weapon.RequiredLevel > BaseLevel) throw new InvalidLevelException(); // as required, get off if BaseLevel too low

            Console.WriteLine("You are allowed to wear this weapon!");
            DPS = weapon.Damage * weapon.AttackSpeed; // DPS calculation

            // Writing to the Slots
            mySlot.Remove(Slot.SLOT_WEAPON);
            mySlot.Add(Slot.SLOT_WEAPON, DPS); ;

            // Storing the actual damage to calculate with
            ActualDamage = BaseDamage + weapon.Damage;

            TotalAttrributeCalculation();
        }

        public void EquipArmour(Armour armour)
        {
            Console.WriteLine("\nRetrieving Armour for " + CharacterClass + ": " + armour.ItemName);

            bool found = false;

            for (int i = 0; i < AllowedArmourType.Count; i++)
            {
                if (AllowedArmourType[i].Equals(armour.ArmourType)) // Is it allowed?
                {
                    found = true;
                    break;
                }
            }
            if (found == false) throw new InvalidArmourException(); // Get off if not allowed

            if (armour.RequiredLevel > BaseLevel) throw new InvalidLevelException(); // Get off if level too low
            Console.WriteLine("You are allowed to wear this armour!");

            // Hmm, now I have to store the data somewhere
            // I decided to calculate all the given attributes together and store it in the Slot
            // There are surely better OOP ways to do that but I'm new at this and have to learn how
            // Time ist short...

            Console.WriteLine("Slot: " + armour.ItemSlot);

            if (armour.ItemSlot.Equals(Slot.SLOT_HEAD))
            {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                mySlot.Remove(Slot.SLOT_HEAD);
                mySlot.Add(Slot.SLOT_HEAD, TotalArmourAttributes);// Store the value in Slot
                Console.WriteLine("TotalArmourAttributes: " + TotalArmourAttributes);
            }

            if (armour.ItemSlot.Equals(Slot.SLOT_BODY))
            {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                mySlot.Remove(Slot.SLOT_BODY);
                mySlot.Add(Slot.SLOT_BODY, TotalArmourAttributes);// Store the value in Slot
                Console.WriteLine("TotalArmourAttributes: " + TotalArmourAttributes);
            }

            if (armour.ItemSlot.Equals(Slot.SLOT_LEGS))
            {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                LegsStrength = armour.Strength;
                mySlot.Remove(Slot.SLOT_LEGS);
                mySlot.Add(Slot.SLOT_LEGS, TotalArmourAttributes); // Store the value in Slot
                Console.WriteLine("TotalArmourAttributes: " + TotalArmourAttributes);
            }
            TotalAttrributeCalculation();
        }
    }
}
