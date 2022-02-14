using System;
using System.Collections.Generic;

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
            mage.showStats();

            Ranger ranger = new Ranger();
            ranger.LevelUp();
            ranger.LevelUp();
            ranger.LevelUp();
            ranger.showStats();

            Rogue rogue = new Rogue();
            rogue.LevelUp();
            rogue.LevelUp();
            rogue.LevelUp();
            rogue.showStats();

            Warrior warrior = new Warrior();
            warrior.LevelUp();
            warrior.LevelUp();
            warrior.LevelUp();
            warrior.showStats();

            // Make sure your weapon values look like this while testing
            Weapon testAxe = new Weapon()
                {
                ItemName = "Common Axe", // String
                RequiredLevel = 1, // int
                ItemSlot = Slot.SLOT_WEAPON, // Enums Slot
                TypeOfWeapon = WeaponType.WEAPON_AXE, // Enums WeaponType
                Damage = 7, // int
                AttackSpeed = 1.1 // double
                };

            Armour testPlateBody = new Armour()
                {
                ItemName = "Common plate body armour",
                RequiredLevel= 1,
                ItemSlot= Slot.SLOT_BODY,
                ArmourType = ArmourType.ARMOUR_PLATE,
                Strength = 1
                };

            //mage.EquipWeapon( testAxe );

            mage.EquipArmour( testPlateBody );

            mage.showStats();

            Console.ReadLine();
            }
        }

    public class Mage : BaseMage
        {
        public string name = ""; // Name must be accessible from outside

        private static Dictionary<Enum, string> mySlot = new Dictionary<Enum, string>(); // mySlot
        private static Dictionary<int, Enum> AllowedWeaponType = new Dictionary<int, Enum>(); // AllowedWeaponType
        private static Dictionary<int, Enum> AllowedArmourType = new Dictionary<int, Enum>(); // AllowedArmourType

        public Mage()
            {
            characterclass = "Mage";
            strength = 1;
            dexterity = 1;
            intelligence = 8;

            mySlot.Add( Slot.SLOT_HEAD, "" );
            mySlot.Add( Slot.SLOT_BODY, "" );
            mySlot.Add( Slot.SLOT_LEGS, "" );
            mySlot.Add( Slot.SLOT_WEAPON, "" );

            AllowedWeaponType.Add( 0, WeaponType.WEAPON_STAFF );
            AllowedWeaponType.Add( 1, WeaponType.WEAPON_WAND );

            AllowedArmourType.Add( 0, ArmourType.ARMOUR_CLOTH );
            }

        public void LevelUp()
            {
            strength++;
            dexterity++;
            intelligence += 5;
            level++;
            damage = 1;
            setDamage();
            }

        public void EquipWeapon( Weapon weapon )
            {
            Console.WriteLine( "\nRetrieving Weapon: " + weapon.TypeOfWeapon );
            bool found = false;

            for ( int i = 0; i < AllowedWeaponType.Count; i++ )
                {
                if ( AllowedWeaponType[i].Equals( weapon.TypeOfWeapon ) )
                    {
                    found = true;
                    break;
                    }
                }
            if ( found == false ) throw new InvalidWeaponException();
            if ( weapon.RequiredLevel > level ) throw new InvalidLevelException();

            Console.WriteLine( "You are allowed to wear this weapon!" );
            mySlot.Remove( weapon.ItemSlot );
            mySlot.Add( weapon.ItemSlot, weapon.ItemName.ToString() );
            damage += weapon.Damage;
            attackSpeed = weapon.AttackSpeed;
            }

        public void EquipArmour( Armour armour )
            {
            Console.WriteLine( "\nRetrieving Armour: " + armour.ItemName );

            bool found = false;

            for ( int i = 0; i < AllowedArmourType.Count; i++ )
                {
                Console.WriteLine( AllowedArmourType[i] );
                Console.WriteLine( armour.ArmourType );
                if ( AllowedArmourType[i].Equals( armour.ArmourType ) )
                    {
                    found = true;
                    break;
                    }
                }
            if ( found == false ) throw new InvalidArmourException();

            if ( armour.RequiredLevel > level ) throw new InvalidLevelException();
            Console.WriteLine( "You are allowed to wear this armour!" );
            mySlot.Remove( armour.ItemSlot );
            mySlot.Add( armour.ItemSlot, armour.ArmourType.ToString() );
            strength += armour.Strength;
            }

        private void setDamage()
            {
            damage += ( intelligence / 100 * 1 );
            // depending on amour, weapon and
            }
        }

    public class Ranger : BaseRanger
        {
        public string name = ""; // Name must be accessible from outside

        public Ranger()
            {
            characterclass = "Ranger";
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
            }

        private void setDamage()
            {
            damage += ( intelligence / 100 * 1 );
            // depending on amour, weapon and
            }

        // equip with weapon

        // equip with amour (head, body, feet)
        }

    public class Rogue : BaseRogue
        {
        public string name = ""; // Name must be accessible from outside

        public Rogue()
            {
            characterclass = "Rogue";
            strength += 2;
            dexterity += 6;
            intelligence += 1;
            }

        public void LevelUp()
            {
            strength++;
            dexterity += 4;
            intelligence++;
            level++;
            setDamage();
            }

        private void setDamage()
            {
            damage += ( intelligence / 100 * 1 );
            // depending on amour, weapon and
            }

        // equip with weapon

        // equip with amour (head, body, feet)
        }

    public class Warrior : BaseWarrior
        {
        public string name = ""; // Name must be accessible from outside

        public Warrior()
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
            }

        // equip with weapon

        // equip with amour (head, body, feet)
        }

    // defining base classes with individual combat values aso.
    public abstract class BaseMage : BaseAttributes
        {
        protected string weaponTypes = "Staff, Wand";
        protected string armorTypes = "Cloth";

        // some other stuff
        }

    public abstract class BaseRanger : BaseAttributes
        {
        protected string weaponTypes = "Bow";
        protected string armorTypes = "Leather, Mail";

        // some other values
        }

    public abstract class BaseRogue : BaseAttributes
        {
        protected string weaponTypes = "Dagger, Sword";
        protected string armorTypes = "Leather, Mail";

        // some other values
        }

    public abstract class BaseWarrior : BaseAttributes
        {
        protected string weaponTypes = "Axe, Hammer, Sword";
        protected string armorTypes = "Mail, Plate";

        // some other values
        }

    public abstract class BaseAttributes : Weapon
        {
        protected int dexterity = 0;
        protected int intelligence = 0;
        protected int level = 0;
        protected int strength = 0;
        protected double damage = 1;
        protected string characterclass = "";
        protected double attackSpeed = 1;

        //public Slot mySlot { get; set; }

        public void showStats()
            {
            Console.WriteLine( "Here are the values of your character's (" + characterclass + ") base attributes:\n\nStength: " + strength + "\nDexterity: " + dexterity + "\nintelligence: " + intelligence + "\nLevel: " + level + "\nAttack Speed: " + attackSpeed + "\nDamage: " + damage );
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