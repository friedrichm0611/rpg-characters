using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_characters
    {
    internal class Program
        {
        private static void Main( string[] args )
            {
            // decrlaring base variables

            Mage mage = new Mage();

            mage.LevelUp();
            mage.LevelUp();
            mage.LevelUp();
            mage.showBaseStats();

            /* Ranger ranger = new Ranger();
             ranger.LevelUp();
             ranger.LevelUp();
             ranger.LevelUp();
             ranger.showStats();*/

            /*Rogue rogue = new Rogue();
            rogue.LevelUp();
            rogue.LevelUp();
            rogue.LevelUp();
            rogue.showStats();*/

            /*Warrior warrior = new Warrior();
            warrior.LevelUp();
            warrior.LevelUp();
            warrior.LevelUp();
            warrior.showStats();*/

            // Make sure your weapon values look like this while testing!!!
            Weapon testAxe = new Weapon()
                {
                ItemName = "Common Axe", // String
                RequiredLevel = 1, // int
                ItemSlot = Slot.SLOT_WEAPON, // Enums Slot
                TypeOfWeapon = WeaponType.WEAPON_STAFF, // Enums WeaponType
                Damage = 7, // int
                AttackSpeed = 1.1 // double
                };

            Armour testPlateBody = new Armour()
                {
                ItemName = "Common plate body armour",
                RequiredLevel= 1,
                ItemSlot= Slot.SLOT_BODY,
                ArmourType = ArmourType.ARMOUR_CLOTH,
                Strength = 1
                };

            mage.EquipWeapon( testAxe );

            mage.EquipArmour( testPlateBody );

            //mage.showBaseStats();
            //mage.showActualStats();
            }
        }

    public class Mage : BaseAttributes
        {
        public string name = ""; // Name can be changed from outside

        private static Dictionary<Slot, double> mySlot = new Dictionary<Slot, double>(); // mySlot
        private static Dictionary<int, WeaponType> AllowedWeaponType = new Dictionary<int, WeaponType>(); // AllowedWeaponType
        private static Dictionary<int, ArmourType> AllowedArmourType = new Dictionary<int, ArmourType>(); // AllowedArmourType

        /*
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

        protected void TotalAttrributeCalculation()
            {
            double TotalAttribute = ActualItelligence + ActualDexterity + ActualStrength + (ActualItelligence * 100 / 1);
            double AmourAttributes = 0;
            double TotalCharacterDamage = 0;
            if ( mySlot[Slot.SLOT_BODY] != 0 ) { AmourAttributes = BaseIntelligence + BaseDexterity + BaseStrength + mySlot[Slot.SLOT_BODY]; }
            if ( mySlot[Slot.SLOT_HEAD] != 0 ) { AmourAttributes = AmourAttributes + BaseIntelligence + BaseDexterity + BaseStrength; }
            if ( mySlot[Slot.SLOT_LEGS] != 0 ) { AmourAttributes = AmourAttributes + BaseIntelligence + BaseDexterity + BaseStrength; }
            TotalAttribute = TotalAttribute + AmourAttributes;
            DPS = mySlot[Slot.SLOT_WEAPON]; // Is already calculated in EquipWeapon()
            // DPS * (1 + Total Attribute / 100)
            TotalCharacterDamage = DPS * ( 1 + TotalAttribute / 100 );

            Console.WriteLine( "TotalCharacterDamage: " + TotalCharacterDamage );
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

            CharacterClass = "Mage";

            // Actual values are set to store a momentum
            ActualStrength = BaseStrength + HeadStrength + BodyStrength + LegsStrength;
            ActualDexterity = BaseDexterity;
            ActualItelligence = BaseIntelligence;

            // The Armour and weapon Slots
            mySlot.Add( Slot.SLOT_HEAD, 0 );
            mySlot.Add( Slot.SLOT_BODY, 0 );
            mySlot.Add( Slot.SLOT_LEGS, 0 );
            mySlot.Add( Slot.SLOT_WEAPON, 1 );

            // Allowed weapons (could be increased later)
            AllowedWeaponType.Add( 0, WeaponType.WEAPON_STAFF );
            AllowedWeaponType.Add( 1, WeaponType.WEAPON_WAND );

            // Allowed armour type (could be increased later)
            AllowedArmourType.Add( 0, ArmourType.ARMOUR_CLOTH );
            }

        public void LevelUp() // Affectes the base values
            {
            BaseStrength++;
            BaseDexterity++;
            BaseIntelligence += 5;
            BaseLevel++;
            BaseDamage = 1;
            TotalAttributes = BaseStrength + BaseDexterity + BaseIntelligence;
            TotalAttrributeCalculation();
            }

        public void EquipWeapon( Weapon weapon )
            {
            Console.WriteLine( "\nRetrieving Weapon: " + weapon.TypeOfWeapon );
            bool found = false;

            for ( int i = 0; i < AllowedWeaponType.Count; i++ )
                {
                if ( AllowedWeaponType[i].Equals( weapon.TypeOfWeapon ) ) // Is the weapon allowed to wear?
                    {
                    found = true;
                    break;
                    }
                }
            if ( found == false ) throw new InvalidWeaponException(); // as required, get off if not allowed
            if ( weapon.RequiredLevel > BaseLevel ) throw new InvalidLevelException(); // as required, get off if BaseLevel too low

            Console.WriteLine( "You are allowed to wear this weapon!" );
            DPS = weapon.Damage * weapon.AttackSpeed; // DPS calculation

            // Writing to the Slots
            mySlot.Remove( Slot.SLOT_WEAPON );
            mySlot.Add( Slot.SLOT_WEAPON, DPS );

            // Storing the actual damage to calculate with
            ActualDamage = BaseDamage + weapon.Damage;

            TotalAttrributeCalculation();
            }

        public void EquipArmour( Armour armour )
            {
            Console.WriteLine( "\nRetrieving Armour: " + armour.ItemName );

            bool found = false;

            for ( int i = 0; i < AllowedArmourType.Count; i++ )
                {
                if ( AllowedArmourType[i].Equals( armour.ArmourType ) ) // Is it allowed?
                    {
                    found = true;
                    break;
                    }
                }
            if ( found == false ) throw new InvalidArmourException(); // Get off if not allowed

            if ( armour.RequiredLevel > BaseLevel ) throw new InvalidLevelException(); // Get off if level too low
            Console.WriteLine( "You are allowed to wear this armour!" );

            if ( armour.ItemSlot.Equals( "WEAPON_HEAD" ) )
                {
                HeadStrength = armour.Strength;
                mySlot.Remove( Slot.SLOT_HEAD );
                mySlot.Add( Slot.SLOT_HEAD, HeadStrength );// Store the value in Slot
                ActualStrength = BaseStrength + mySlot[Slot.SLOT_HEAD] + mySlot[Slot.SLOT_BODY] + mySlot[Slot.SLOT_LEGS];
                }

            if ( armour.ItemSlot.Equals( "WEAPON_BODY" ) )
                {
                BodyStrength = armour.Strength;
                mySlot.Remove( Slot.SLOT_BODY );
                mySlot.Add( Slot.SLOT_BODY, BodyStrength );// Store the value in Slot
                ActualStrength = BaseStrength + mySlot[Slot.SLOT_HEAD] + mySlot[Slot.SLOT_BODY] + mySlot[Slot.SLOT_LEGS];
                }

            if ( armour.ItemSlot.Equals( "WEAPON_LEGS" ) )
                {
                LegsStrength = armour.Strength;
                mySlot.Remove( Slot.SLOT_LEGS );
                mySlot.Add( Slot.SLOT_LEGS, LegsStrength ); // Store the value in Slot
                ActualStrength = BaseStrength + mySlot[Slot.SLOT_HEAD] + mySlot[Slot.SLOT_BODY] + mySlot[Slot.SLOT_LEGS];
                }
            TotalAttrributeCalculation();
            }
        }

    public class Ranger : BaseAttributes
        {
        public string name = ""; // Name must be accessible from outside

        /* public Ranger()
             {
             CharacterClass = "Ranger";
             strength = 1;
             dexterity = 7;
             intelligence = 1;
             }

         public void LevelUp()
             {
             strength++;
             dexterity += 5;
             intelligence++;
             level++;
             setDamage();
             }*/

        /*private void setDamage()
            {
            damage += ( intelligence / 100 * 1 );
            // depending on amour, weapon and
            }*/

        // equip with weapon

        // equip with amour (head, body, feet)
        }

    public class Rogue : BaseAttributes
        {
        public string name = ""; // Name must be accessible from outside

        /*public Rogue()
            {
            CharacterClass = "Rogue";
            ActualStrength = 2;
            dexterity += 6;
            intelligence += 1;
            }
*/

        public void LevelUp()
            {
            BaseStrength++;
            BaseDexterity += 4;
            BaseIntelligence++;
            BaseLevel++;
            setBaseDamage();
            }

        private void setBaseDamage()
            {
            //damage += ( intelligence / 100 * 1 );
            // depending on amour, weapon and
            }

        // equip with weapon

        // equip with amour (head, body, feet)
        }

    public class Warrior : BaseAttributes
        {
        public string name = ""; // Name must be accessible from outside

        /*public Warrior()
            {
            characterclass = "Warrior";
            strength += 5;
            dexterity += 2;
            intelligence += 1;
            }

        public void LevelUp()
            {
            strength += 3;
            dexterity += 2;
            intelligence++;
            level++;
            setDamage();
            }

        private void setDamage()
            {
            damage += ( intelligence / 100 * 1 );
            // depending on amour, weapon and
            }*/

        // equip with weapon

        // equip with amour (head, body, feet)
        }

    // defining base classes with individual combat values aso.

    public abstract class BaseAttributes
        {
        protected int BaseDexterity { get; set; }
        protected int BaseIntelligence { get; set; }
        protected int BaseStrength { get; set; }
        protected int BaseLevel { get; set; }
        protected double BaseAttackSpeed { get; set; }
        public double BaseDamage { get; set; }

        protected double ActualStrength { get; set; }
        protected double ActualDexterity { get; set; }
        protected double ActualItelligence { get; set; }
        protected double ActualAttackSpeed { get; set; }
        protected double ActualDamage { get; set; }

        public double TotalAttributes { get; set; }

        protected double DPS { get; set; }

        protected double HeadStrength { get; set; }
        protected double BodyStrength { get; set; }
        protected double LegsStrength { get; set; }

        protected double WeaponDamage { get; set; }
        protected double WeaponAttackSpeed { get; set; }

        protected string CharacterClass { get; set; }

        public void showBaseStats()
            {
            StringBuilder sb = new StringBuilder("", 300);
            sb.AppendLine( "Here are the base values of your character's (" + CharacterClass + ") base attributes:\n" );
            sb.AppendLine( "Stength: " + BaseStrength );
            sb.AppendLine( "Dexterity: " + BaseDexterity );
            sb.AppendLine( "Intelligence: " + BaseIntelligence );
            sb.AppendLine( "Level: " + BaseLevel );

            Console.WriteLine( sb );
            }

        public void showActualStats()
            {
            StringBuilder act = new StringBuilder("", 300);
            act.AppendLine( "Here are the calculated weapon values of your character's (" + CharacterClass + ") based on your base attributes:\n" );
            act.AppendLine( "Attack Speed: " + ActualAttackSpeed );
            act.AppendLine( "Damage: " + BaseDamage );
            act.AppendLine( "Actual Damage: " + ActualDamage );
            act.AppendLine( "DPS: " + DPS );

            Console.WriteLine( act );

            // Damage
            // AttackSpeed
            // BaseStrength
            // ActualStrength
            }
        }

    public class Weapon
        {
        public string ItemName { get; set; }
        public int RequiredLevel { get; set; }
        public Enum ItemSlot { get; set; }
        public Enum TypeOfWeapon { get; set; }

        public double Damage { get; set; }
        public double AttackSpeed { get; set; }
        }

    public class Armour
        {
        public string ItemName { get; set; }
        public int RequiredLevel { get; set; }
        public Enum ItemSlot { get; set; }
        public Enum ArmourType { get; set; }

        public int Strength { get; set; }
        }

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