using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_characters
    {
    internal class Program
        {
        private static void Main( string[] args )
            {
            Mage mage = new Mage();

            mage.showBaseStats();
            mage.LevelUp();
            mage.LevelUp();
            mage.LevelUp();
            mage.showBaseStats();

            Ranger ranger = new Ranger();
            ranger.LevelUp();
            ranger.LevelUp();
            ranger.LevelUp();
            ranger.showBaseStats();

            Rogue rogue = new Rogue();
            rogue.LevelUp();
            rogue.LevelUp();
            rogue.LevelUp();
            rogue.showBaseStats();

            Warrior warrior = new Warrior();
            warrior.LevelUp();
            warrior.LevelUp();
            warrior.LevelUp();
            warrior.showBaseStats();

            // Make sure your weapon values look like this while testing!!!
            Weapon testStaff = new Weapon()
                {
                ItemName = "Common Staff", // String
                RequiredLevel = 1, // int
                ItemSlot = Slot.SLOT_WEAPON, // Enum Slot
                TypeOfWeapon = WeaponType.WEAPON_STAFF, // Enum WeaponType
                Damage = 7, // int
                AttackSpeed = 1.7 // double
                };

            Armour testClothHead = new Armour()
                {
                ItemName = "Common cloth head armour",
                RequiredLevel= 1,
                ItemSlot= Slot.SLOT_HEAD,
                ArmourType = ArmourType.ARMOUR_CLOTH,
                Strength = 1,
                Intelligence = 0,
                Dexterity = 0,
                };

            Armour testClothBody = new Armour()
                {
                ItemName = "Common cloth body armour",
                RequiredLevel= 1,
                ItemSlot= Slot.SLOT_BODY,
                ArmourType = ArmourType.ARMOUR_CLOTH,
                Strength = 5,
                Intelligence = 6,
                Dexterity = 8,
                };

            Armour testClothLegs = new Armour()
                {
                ItemName = "Common cloth legs armour",
                RequiredLevel= 1,
                ItemSlot= Slot.SLOT_LEGS,
                ArmourType = ArmourType.ARMOUR_CLOTH,
                Strength = 2,
                Intelligence = 5,
                Dexterity = 3,
                };

            Armour testClothLegs2 = new Armour()
                {
                ItemName = "Common cloth legs armour override",
                RequiredLevel= 1,
                ItemSlot= Slot.SLOT_LEGS,
                ArmourType = ArmourType.ARMOUR_CLOTH,
                Strength = 4,
                Intelligence = 9,
                Dexterity = 5,
                };

            mage.EquipWeapon( testStaff );

            mage.EquipArmour( testClothHead );
            mage.EquipArmour( testClothBody );
            mage.EquipArmour( testClothLegs );
            mage.EquipArmour( testClothLegs2 );
            }
        }

    /*
        *** Following logic to calculate the attributes as far as I understood ***

        *** Base Attributes ***
        Mage: S = 1, D = 1, I = 8 Initial
        lvlup: S += 1, D +=1, I +=5 , Level +=1
        Level2: S = 2, D = 2, I = 13
        Base Damage (Intelligence) = I + (I *100 / 1)  ( 8 -> 8,08)

        *** 3 x Armor Attributes ***
        Head, Body, Legs => Strength = Total Attribute = BaseStrength + Head + Body + Legs

        *** Weapon Damage ***
        DPS = Damage (Weapon) * Attack Speed

        *** Character Damage ***
        Total Attribute = DPS * (1 + Total Attribute / 100)

        *** Total attribute calculation ***
        Total Base Damage: S + D + (I + (I * 100 / 1))
        If Head is equipped -> + 1 * Base Attributes
        If Body is equipped -> + 1 * Base Attributes
        If Legs is equipped -> + 1 * Base Attributes

        All Equipped Armor: Head + Body + Legs
        */

    
    public enum Slot
        {
        SLOT_HEAD,
        SLOT_BODY,
        SLOT_LEGS,
        SLOT_WEAPON
        }

    public enum WeaponType
        {
        WEAPON_AXE,
        WEAPON_BOW,
        WEAPON_DAGGER,
        WEAPON_HAMMER,
        WEAPON_STAFF,
        WEAPON_SWORD,
        WEAPON_WAND
        }

    public enum ArmourType
        {
        ARMOUR_CLOTH,
        ARMOUR_LEATHER,
        ARMOUR_MAIL,
        ARMOUR_PLATE
        }
    }