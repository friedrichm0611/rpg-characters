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
            if ( mySlot[Slot.SLOT_BODY] != 0 ) { AmourAttributes = BaseIntelligence + BaseDexterity + BaseStrength + mySlot[Slot.SLOT_BODY]; }
            if ( mySlot[Slot.SLOT_HEAD] != 0 ) { AmourAttributes = AmourAttributes + BaseIntelligence + BaseDexterity + mySlot[Slot.SLOT_HEAD]; }
            if ( mySlot[Slot.SLOT_LEGS] != 0 ) { AmourAttributes = AmourAttributes + BaseIntelligence + BaseDexterity + mySlot[Slot.SLOT_LEGS]; }
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
            TotalArmourAttributes = 0;

            CharacterClass = "Mage";

            // The Armour and weapon Slots
            mySlot.Add( Slot.SLOT_HEAD, 0 ); // Value is Attribute + given Value
            mySlot.Add( Slot.SLOT_BODY, 0 ); // Value is Attribute + given Value
            mySlot.Add( Slot.SLOT_LEGS, 0 ); // Value is Attribute + given Value
            mySlot.Add( Slot.SLOT_WEAPON, 1 ); // Value is DPS

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
            ActualStrength = BaseStrength;
            ActualItelligence = BaseIntelligence;
            ActualDexterity = BaseDexterity;
            ActualAttackSpeed = BaseIntelligence;
            TotalAttributes = BaseStrength + BaseDexterity + BaseIntelligence;
            Console.WriteLine( $"{CharacterClass} was levelled up!" );
            TotalAttrributeCalculation();
            }

        public void EquipWeapon( Weapon weapon )
            {
            Console.WriteLine( "\nRetrieving Weapon for " + CharacterClass + ": " + weapon.TypeOfWeapon );
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
            mySlot.Add( Slot.SLOT_WEAPON, DPS ); ;

            // Storing the actual damage to calculate with
            ActualDamage = BaseDamage + weapon.Damage;

            TotalAttrributeCalculation();
            }

        public void EquipArmour( Armour armour )
            {
            Console.WriteLine( "\nRetrieving Armour for " + CharacterClass + ": " + armour.ItemName );

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

            // Hmm, now I have to store the data somewhere
            // I decided to calculate all the given attributes together and store it in the Slot
            // There are surely better OOP ways to do that but I'm new at this and have to learn how
            // Time ist short...

            Console.WriteLine( "Slot: " + armour.ItemSlot );

            if ( armour.ItemSlot.Equals( Slot.SLOT_HEAD ) )
                {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                mySlot.Remove( Slot.SLOT_HEAD );
                mySlot.Add( Slot.SLOT_HEAD, TotalArmourAttributes );// Store the value in Slot
                Console.WriteLine( "TotalArmourAttributes: " + TotalArmourAttributes );
                }

            if ( armour.ItemSlot.Equals( Slot.SLOT_BODY ) )
                {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                mySlot.Remove( Slot.SLOT_BODY );
                mySlot.Add( Slot.SLOT_BODY, TotalArmourAttributes );// Store the value in Slot
                Console.WriteLine( "TotalArmourAttributes: " + TotalArmourAttributes );
                }

            if ( armour.ItemSlot.Equals( Slot.SLOT_LEGS ) )
                {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                LegsStrength = armour.Strength;
                mySlot.Remove( Slot.SLOT_LEGS );
                mySlot.Add( Slot.SLOT_LEGS, TotalArmourAttributes ); // Store the value in Slot
                Console.WriteLine( "TotalArmourAttributes: " + TotalArmourAttributes );
                }
            TotalAttrributeCalculation();
            }
        }

    public class Ranger : BaseAttributes
        {
        public string name = ""; // Name can be changed from outside

        private static Dictionary<Slot, double> mySlot = new Dictionary<Slot, double>(); // mySlot
        private static Dictionary<int, WeaponType> AllowedWeaponType = new Dictionary<int, WeaponType>(); // AllowedWeaponType
        private static Dictionary<int, ArmourType> AllowedArmourType = new Dictionary<int, ArmourType>(); // AllowedArmourType

        protected void TotalAttrributeCalculation() // That's my understanding how it should work
            {
            double TotalAttribute = ActualItelligence + ActualDexterity + ActualStrength + (ActualDexterity * 100 / 1);
            double AmourAttributes = 0;
            double TotalCharacterDamage = 0;
            if ( mySlot[Slot.SLOT_BODY] != 0 ) { AmourAttributes = BaseIntelligence + BaseDexterity + BaseStrength + mySlot[Slot.SLOT_BODY]; }
            if ( mySlot[Slot.SLOT_HEAD] != 0 ) { AmourAttributes = AmourAttributes + BaseIntelligence + BaseDexterity + BaseStrength + mySlot[Slot.SLOT_HEAD]; }
            if ( mySlot[Slot.SLOT_LEGS] != 0 ) { AmourAttributes = AmourAttributes + BaseIntelligence + BaseDexterity + BaseStrength + mySlot[Slot.SLOT_LEGS]; }
            TotalAttribute = TotalAttribute + AmourAttributes;

            DPS = mySlot[Slot.SLOT_WEAPON]; // Is already calculated in EquipWeapon()
            // DPS * (1 + Total Attribute / 100)
            TotalCharacterDamage = DPS * ( 1 + TotalAttribute / 100 );

            Console.WriteLine( "TotalCharacterDamage: " + TotalCharacterDamage );
            }

        public Ranger()
            {
            // Initializing
            BaseLevel = 1;
            BaseDexterity = 7;
            BaseStrength = 1;
            BaseIntelligence = 1;
            BaseAttackSpeed = 0;
            HeadStrength = 0;
            BodyStrength = 0;
            LegsStrength = 0;
            TotalArmourAttributes = 0;

            CharacterClass = "Ranger";

            // The Armour and weapon Slots
            mySlot.Add( Slot.SLOT_HEAD, 0 ); // Value is Attribute + given Value
            mySlot.Add( Slot.SLOT_BODY, 0 ); // Value is Attribute + given Value
            mySlot.Add( Slot.SLOT_LEGS, 0 ); // Value is Attribute + given Value
            mySlot.Add( Slot.SLOT_WEAPON, 1 ); // Value is DPS

            // Allowed weapons (could be increased later)
            AllowedWeaponType.Add( 0, WeaponType.WEAPON_BOW );

            // Allowed armour type (could be increased later)
            AllowedArmourType.Add( 0, ArmourType.ARMOUR_LEATHER );
            AllowedArmourType.Add( 1, ArmourType.ARMOUR_MAIL );
            }

        public void LevelUp() // Affectes the base values
            {
            BaseStrength++;
            BaseDexterity += 5;
            BaseIntelligence++;
            BaseLevel++;
            BaseDamage = 1;
            ActualStrength = BaseStrength;
            ActualItelligence = BaseIntelligence;
            ActualDexterity = BaseDexterity;
            ActualAttackSpeed = BaseDexterity;
            TotalAttributes = BaseStrength + BaseDexterity + BaseIntelligence;
            Console.WriteLine( $"{CharacterClass} was levelled up!" );
            TotalAttrributeCalculation();
            }

        public void EquipWeapon( Weapon weapon )
            {
            Console.WriteLine( "\nRetrieving Weapon for " + CharacterClass + ": " + weapon.TypeOfWeapon );
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
            mySlot.Add( Slot.SLOT_WEAPON, DPS ); ;

            // Storing the actual damage to calculate with
            ActualDamage = BaseDamage + weapon.Damage;

            TotalAttrributeCalculation();
            }

        public void EquipArmour( Armour armour )
            {
            Console.WriteLine( "\nRetrieving Armour for " + CharacterClass + ": " + armour.ItemName );

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

            // Hmm, now I have to store the data somewhere
            // I decided to calculate all the given attributes together and store it in the Slot
            // There are surely better OOP ways to do that but I'm new at this and have to learn how
            // Time ist short...

            Console.WriteLine( "Slot: " + armour.ItemSlot );

            if ( armour.ItemSlot.Equals( Slot.SLOT_HEAD ) )
                {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                mySlot.Remove( Slot.SLOT_HEAD );
                mySlot.Add( Slot.SLOT_HEAD, TotalArmourAttributes );// Store the value in Slot
                Console.WriteLine( "TotalArmourAttributes: " + TotalArmourAttributes );
                }

            if ( armour.ItemSlot.Equals( Slot.SLOT_BODY ) )
                {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                mySlot.Remove( Slot.SLOT_BODY );
                mySlot.Add( Slot.SLOT_BODY, TotalArmourAttributes );// Store the value in Slot
                Console.WriteLine( "TotalArmourAttributes: " + TotalArmourAttributes );
                }

            if ( armour.ItemSlot.Equals( Slot.SLOT_LEGS ) )
                {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                LegsStrength = armour.Strength;
                mySlot.Remove( Slot.SLOT_LEGS );
                mySlot.Add( Slot.SLOT_LEGS, TotalArmourAttributes ); // Store the value in Slot
                Console.WriteLine( "TotalArmourAttributes: " + TotalArmourAttributes );
                }
            TotalAttrributeCalculation();
            }
        }

    public class Rogue : BaseAttributes
        {
        public string name = ""; // Name can be changed from outside

        private static Dictionary<Slot, double> mySlot = new Dictionary<Slot, double>(); // mySlot
        private static Dictionary<int, WeaponType> AllowedWeaponType = new Dictionary<int, WeaponType>(); // AllowedWeaponType
        private static Dictionary<int, ArmourType> AllowedArmourType = new Dictionary<int, ArmourType>(); // AllowedArmourType

        protected void TotalAttrributeCalculation() // That's my understanding how it should work
            {
            double TotalAttribute = ActualItelligence + ActualDexterity + ActualStrength + (ActualDexterity * 100 / 1);
            double AmourAttributes = 0;
            double TotalCharacterDamage = 0;
            if ( mySlot[Slot.SLOT_BODY] != 0 ) { AmourAttributes = BaseIntelligence + BaseDexterity + BaseStrength + mySlot[Slot.SLOT_BODY]; }
            if ( mySlot[Slot.SLOT_HEAD] != 0 ) { AmourAttributes = AmourAttributes + BaseIntelligence + BaseDexterity + mySlot[Slot.SLOT_HEAD]; }
            if ( mySlot[Slot.SLOT_LEGS] != 0 ) { AmourAttributes = AmourAttributes + BaseIntelligence + BaseDexterity + mySlot[Slot.SLOT_LEGS]; }
            TotalAttribute = TotalAttribute + AmourAttributes;

            DPS = mySlot[Slot.SLOT_WEAPON]; // Is already calculated in EquipWeapon()
            // DPS * (1 + Total Attribute / 100)
            TotalCharacterDamage = DPS * ( 1 + TotalAttribute / 100 );

            Console.WriteLine( "TotalCharacterDamage: " + TotalCharacterDamage );
            }

        public Rogue()
            {
            // Initializing
            BaseLevel = 1;
            BaseDexterity = 6;
            BaseStrength = 2;
            BaseIntelligence = 1;
            BaseAttackSpeed = 0;
            HeadStrength = 0;
            BodyStrength = 0;
            LegsStrength = 0;
            TotalArmourAttributes = 0;

            CharacterClass = "Rogue";

            // The Armour and weapon Slots
            mySlot.Add( Slot.SLOT_HEAD, 0 ); // Value is Attribute + given Value
            mySlot.Add( Slot.SLOT_BODY, 0 ); // Value is Attribute + given Value
            mySlot.Add( Slot.SLOT_LEGS, 0 ); // Value is Attribute + given Value
            mySlot.Add( Slot.SLOT_WEAPON, 1 ); // Value is DPS

            // Allowed weapons (could be increased later)
            AllowedWeaponType.Add( 0, WeaponType.WEAPON_DAGGER );
            AllowedWeaponType.Add( 1, WeaponType.WEAPON_SWORD );

            // Allowed armour type (could be increased later)
            AllowedArmourType.Add( 0, ArmourType.ARMOUR_LEATHER );
            AllowedArmourType.Add( 1, ArmourType.ARMOUR_MAIL );
            }

        public void LevelUp() // Affectes the base values
            {
            BaseStrength++;
            BaseDexterity += 4;
            BaseIntelligence++;
            BaseLevel++;
            BaseDamage = 1;
            ActualStrength = BaseStrength;
            ActualItelligence = BaseIntelligence;
            ActualDexterity = BaseDexterity;
            ActualAttackSpeed = BaseDexterity;
            TotalAttributes = BaseStrength + BaseDexterity + BaseIntelligence;
            Console.WriteLine( $"{CharacterClass} was levelled up!" );
            TotalAttrributeCalculation();
            }

        public void EquipWeapon( Weapon weapon )
            {
            Console.WriteLine( "\nRetrieving Weapon for " + CharacterClass + ": " + weapon.TypeOfWeapon );
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
            mySlot.Add( Slot.SLOT_WEAPON, DPS ); ;

            // Storing the actual damage to calculate with
            ActualDamage = BaseDamage + weapon.Damage;

            TotalAttrributeCalculation();
            }

        public void EquipArmour( Armour armour )
            {
            Console.WriteLine( "\nRetrieving Armour for " + CharacterClass + ": " + armour.ItemName );

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

            // Hmm, now I have to store the data somewhere
            // I decided to calculate all the given attributes together and store it in the Slot
            // There are surely better OOP ways to do that but I'm new at this and have to learn how
            // Time ist short...

            Console.WriteLine( "Slot: " + armour.ItemSlot );

            if ( armour.ItemSlot.Equals( Slot.SLOT_HEAD ) )
                {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                mySlot.Remove( Slot.SLOT_HEAD );
                mySlot.Add( Slot.SLOT_HEAD, TotalArmourAttributes );// Store the value in Slot
                Console.WriteLine( "TotalArmourAttributes: " + TotalArmourAttributes );
                }

            if ( armour.ItemSlot.Equals( Slot.SLOT_BODY ) )
                {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                mySlot.Remove( Slot.SLOT_BODY );
                mySlot.Add( Slot.SLOT_BODY, TotalArmourAttributes );// Store the value in Slot
                Console.WriteLine( "TotalArmourAttributes: " + TotalArmourAttributes );
                }

            if ( armour.ItemSlot.Equals( Slot.SLOT_LEGS ) )
                {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                LegsStrength = armour.Strength;
                mySlot.Remove( Slot.SLOT_LEGS );
                mySlot.Add( Slot.SLOT_LEGS, TotalArmourAttributes ); // Store the value in Slot
                Console.WriteLine( "TotalArmourAttributes: " + TotalArmourAttributes );
                }
            TotalAttrributeCalculation();
            }
        }

    public class Warrior : BaseAttributes
        {
        public string name = ""; // Name can be changed from outside

        private static Dictionary<Slot, double> mySlot = new Dictionary<Slot, double>(); // mySlot
        private static Dictionary<int, WeaponType> AllowedWeaponType = new Dictionary<int, WeaponType>(); // AllowedWeaponType
        private static Dictionary<int, ArmourType> AllowedArmourType = new Dictionary<int, ArmourType>(); // AllowedArmourType

        protected void TotalAttrributeCalculation() // That's my understanding how it should work
            {
            double TotalAttribute = ActualItelligence + ActualDexterity + ActualStrength + (ActualStrength * 100 / 1);
            double AmourAttributes = 0;
            double TotalCharacterDamage = 0;
            if ( mySlot[Slot.SLOT_BODY] != 0 ) { AmourAttributes = BaseIntelligence + BaseDexterity + BaseStrength + mySlot[Slot.SLOT_BODY]; }
            if ( mySlot[Slot.SLOT_HEAD] != 0 ) { AmourAttributes = AmourAttributes + BaseIntelligence + BaseDexterity + mySlot[Slot.SLOT_HEAD]; }
            if ( mySlot[Slot.SLOT_LEGS] != 0 ) { AmourAttributes = AmourAttributes + BaseIntelligence + BaseDexterity + mySlot[Slot.SLOT_LEGS]; }
            TotalAttribute = TotalAttribute + AmourAttributes;

            DPS = mySlot[Slot.SLOT_WEAPON]; // Is already calculated in EquipWeapon()
            // DPS * (1 + Total Attribute / 100)
            TotalCharacterDamage = DPS * ( 1 + TotalAttribute / 100 );

            Console.WriteLine( "TotalCharacterDamage: " + TotalCharacterDamage );
            }

        public Warrior()
            {
            // Initializing
            BaseLevel = 1;
            BaseDexterity = 2;
            BaseStrength = 5;
            BaseIntelligence = 1;
            BaseAttackSpeed = 0;
            HeadStrength = 0;
            BodyStrength = 0;
            LegsStrength = 0;
            TotalArmourAttributes = 0;

            CharacterClass = "Warrior";

            // The Armour and weapon Slots
            mySlot.Add( Slot.SLOT_HEAD, 0 ); // Value is Attribute + given Value
            mySlot.Add( Slot.SLOT_BODY, 0 ); // Value is Attribute + given Value
            mySlot.Add( Slot.SLOT_LEGS, 0 ); // Value is Attribute + given Value
            mySlot.Add( Slot.SLOT_WEAPON, 1 ); // Value is DPS

            // Allowed weapons (could be increased later)
            AllowedWeaponType.Add( 0, WeaponType.WEAPON_AXE );
            AllowedWeaponType.Add( 1, WeaponType.WEAPON_HAMMER );
            AllowedWeaponType.Add( 2, WeaponType.WEAPON_SWORD );

            // Allowed armour type (could be increased later)
            AllowedArmourType.Add( 0, ArmourType.ARMOUR_MAIL );
            AllowedArmourType.Add( 1, ArmourType.ARMOUR_PLATE );
            }

        public void LevelUp() // Affectes the base values
            {
            BaseStrength += 3;
            BaseDexterity += 2;
            BaseIntelligence++;
            BaseLevel++;
            BaseDamage = 1;
            ActualStrength = BaseStrength;
            ActualItelligence = BaseIntelligence;
            ActualAttackSpeed = BaseDexterity;
            TotalAttributes = BaseStrength + BaseDexterity + BaseIntelligence;
            Console.WriteLine( $"{CharacterClass} was levelled up!" );
            TotalAttrributeCalculation();
            }

        public void EquipWeapon( Weapon weapon )
            {
            Console.WriteLine( "\nRetrieving Weapon for " + CharacterClass + ": " + weapon.TypeOfWeapon );
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
            mySlot.Add( Slot.SLOT_WEAPON, DPS ); ;

            // Storing the actual damage to calculate with
            ActualDamage = BaseDamage + weapon.Damage;

            TotalAttrributeCalculation();
            }

        public void EquipArmour( Armour armour )
            {
            Console.WriteLine( "\nRetrieving Armour for " + CharacterClass + ": " + armour.ItemName );

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

            // Hmm, now I have to store the data somewhere
            // I decided to calculate all the given attributes together and store it in the Slot
            // There are surely better OOP ways to do that but I'm new at this and have to learn how
            // Time ist short...

            Console.WriteLine( "Slot: " + armour.ItemSlot );

            if ( armour.ItemSlot.Equals( Slot.SLOT_HEAD ) )
                {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                mySlot.Remove( Slot.SLOT_HEAD );
                mySlot.Add( Slot.SLOT_HEAD, TotalArmourAttributes );// Store the value in Slot
                Console.WriteLine( "TotalArmourAttributes: " + TotalArmourAttributes );
                }

            if ( armour.ItemSlot.Equals( Slot.SLOT_BODY ) )
                {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                mySlot.Remove( Slot.SLOT_BODY );
                mySlot.Add( Slot.SLOT_BODY, TotalArmourAttributes );// Store the value in Slot
                Console.WriteLine( "TotalArmourAttributes: " + TotalArmourAttributes );
                }

            if ( armour.ItemSlot.Equals( Slot.SLOT_LEGS ) )
                {
                TotalArmourAttributes = BaseDamage + BaseDexterity + BaseIntelligence + armour.Dexterity + armour.Intelligence + armour.Strength;
                LegsStrength = armour.Strength;
                mySlot.Remove( Slot.SLOT_LEGS );
                mySlot.Add( Slot.SLOT_LEGS, TotalArmourAttributes ); // Store the value in Slot
                Console.WriteLine( "TotalArmourAttributes: " + TotalArmourAttributes );
                }
            TotalAttrributeCalculation();
            }
        }

    public abstract class BaseAttributes
        {
        protected int BaseDexterity { get; set; }
        protected int BaseIntelligence { get; set; }
        protected int BaseStrength { get; set; }
        protected int BaseLevel { get; set; }
        protected double BaseAttackSpeed { get; set; }
        protected double BaseDamage { get; set; }

        protected double ActualStrength { get; set; }
        protected double ActualDexterity { get; set; }
        protected double ActualItelligence { get; set; }
        protected double ActualAttackSpeed { get; set; }
        protected double ActualDamage { get; set; }

        protected double TotalAttributes { get; set; }

        protected double TotalArmourAttributes { get; set; }

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
            sb.AppendLine( "\nHere are the (new) base values of your character's (" + CharacterClass + ") base attributes:\n" );
            sb.AppendLine( "Stength: " + BaseStrength );
            sb.AppendLine( "Dexterity: " + BaseDexterity );
            sb.AppendLine( "Intelligence: " + BaseIntelligence );
            sb.AppendLine( "Level: " + BaseLevel );

            Console.WriteLine( sb );
            }
        }

    public class Weapon
        {
        public string ItemName { get; set; }
        public int RequiredLevel { get; set; }
        public Enum ItemSlot { get; set; }
        public Enum TypeOfWeapon { get; set; }

        public int Damage { get; set; }
        public double AttackSpeed { get; set; }
        }

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