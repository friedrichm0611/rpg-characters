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

            Weapon testAxe = new Weapon()
                {
                ItemName = "Common Axe",
                RequiredLevel = 1,
                ItemSlot = "Weapon",
                WeaponType = "Axe",
                Damage = 7,
                AttackSpeed = 1.1
                };

            mage.EquipWeapon( testAxe );

            Console.ReadLine();
            }
        }

    public class Mage : BaseMage
        {
        public string name = ""; // Name must be accessible from outside

        private static Dictionary<string, string> Slot = new Dictionary<string, string>();
        private static Dictionary<int, string> AllowedWeaponType = new Dictionary<int, string>();

        public Mage()
            {
            characterclass = "Mage";
            strength = 1;
            dexterity = 1;
            intelligence = 8;

            Slot.Add( "Head", "" );
            Slot.Add( "Body", "" );
            Slot.Add( "Legs", "" );
            Slot.Add( "Weapon", "" );

            AllowedWeaponType.Add( 0, "Staff" );
            AllowedWeaponType.Add( 1, "Wand" );
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
            bool found = false;
            string typeOfWapon = weapon.WeaponType;
            for ( int i = 0; i < AllowedWeaponType.Count; i++ )
                {
                if ( AllowedWeaponType[i] == typeOfWapon )
                    {
                    found = true;
                    break;
                    }
                }
            if ( found == false ) throw new InvalidWeaponException();
            if ( weapon.RequiredLevel >= level ) throw new InvalidLevelException();

            Console.WriteLine( "You are allowed to wear this weapon!" ); // Ausbauen!!!
            Slot.Remove( "Weapon" );
            Slot.Add( "Weapon", weapon.ItemName );
            damage += weapon.Damage;
            attackSpeed = weapon.AttackSpeed;
            }

        //Console.WriteLine( "You are allowed!" );

        private void setDamage()
            {
            damage += ( intelligence / 100 * 1 );
            // depending on amour, weapon and
            }

        // equip with weapon

        // equip with amour (head, body, feet)
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

    public class BaseAttributes : Weapon
        {
        protected int dexterity = 0;
        protected int intelligence = 0;
        protected int level = 0;
        protected int strength = 0;
        protected double damage = 0;
        protected string characterclass = "";
        protected double attackSpeed = 0;

        //public Slot mySlot { get; set; }

        public void showStats()
            {
            Console.WriteLine( "Here are the values of your character's (" + characterclass + ") base attributes:\n\nStength: " + strength + "\nDexterity: " + dexterity + "\nintelligence: " + intelligence + "\nLevel: " + level );
            }
        }

    public class Weapon
        {
        public string ItemName { get; set; }
        public int RequiredLevel { get; set; }
        public string ItemSlot { get; set; }
        public string WeaponType { get; set; }

        public double Damage { get; set; }
        public double AttackSpeed { get; set; }
        }

    public enum SLOT_WEAPON
        {
        HEAD,
        BODY,
        LEGS,
        WEAPON
        }

    public enum WeaponType
        {
        WEAPON_AXE,
        WEAPON_BOW,
        WEAPON_DAGGER,
        WEAPON_HAMMER,
        WEAPON_STAFF,
        WEAPON_SWORD,
        WEAPON_WAND,
        }
    }