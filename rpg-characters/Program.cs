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

            // Make sure your weapon values look like this while testing
            Weapon testAxe = new Weapon()
                {
                ItemName = "Common Axe", // String
                RequiredLevel = 1, // int
                ItemSlot = Slot.SLOT_WEAPON, // Enums Slot
                TypeOfWeapon = WeaponType.WEAPON_WAND, // Enums WeaponType
                Damage = 7, // int
                AttackSpeed = 1.1 // double
                };

            /*Armour testPlateBody = new Armour()
                {
                ItemName = "Common plate body armour",
                RequiredLevel= 1,
                ItemSlot= Slot.SLOT_BODY,
                ArmourType = ArmourType.ARMOUR_PLATE,
                Strength = 1
                };*/

            mage.EquipWeapon( testAxe );

            //mage.EquipArmour( testPlateBody );

            mage.showBaseStats();

            
            }
        }

    public class Mage : BaseAttributes
        {
        public string name = ""; // Name can be changed from outside

        private static Dictionary<Enum, double> mySlot = new Dictionary<Enum, double>(); // mySlot
        private static Dictionary<int, Enum> AllowedWeaponType = new Dictionary<int, Enum>(); // AllowedWeaponType
        private static Dictionary<int, Enum> AllowedArmourType = new Dictionary<int, Enum>(); // AllowedArmourType

        /*public void setActualDamage()
            {
            ActualDamage = BaseDamage;
            // depending on amour, weapon and
            }*/

        public Mage()
            {
            BaseLevel = 1;  
            BaseDexterity = 1;
            BaseStrength = 1;
            BaseIntelligence = 8;
            BaseAttackSpeed = 0;
            HeadStrength = 0;
            BodyStrength = 0;
            LegsStrength = 0;
            TotalAttributes = BaseStrength + BaseDexterity + BaseIntelligence;



            CharacterClass = "Mage";
            ActualStrength = BaseStrength + HeadStrength + BodyStrength + LegsStrength;
            ActualDexterity = BaseDexterity;
            ActualItelligence = BaseIntelligence;            

            mySlot.Add( Slot.SLOT_HEAD, 0 );
            mySlot.Add( Slot.SLOT_BODY, 0 );
            mySlot.Add( Slot.SLOT_LEGS, 0 );
            mySlot.Add( Slot.SLOT_WEAPON, 0 );

            AllowedWeaponType.Add( 0, WeaponType.WEAPON_STAFF );
            AllowedWeaponType.Add( 1, WeaponType.WEAPON_WAND );

            AllowedArmourType.Add( 0, ArmourType.ARMOUR_CLOTH );
            }

            protected void setActualDamage()
            {
            ActualDamage = DPS * (1 + TotalAttributes / 100 )  ;
            // depending on amour, weapon and
            }


        public void LevelUp()
            {
            BaseStrength++;
            BaseDexterity++;
            BaseIntelligence += 5;
            BaseLevel++;
            BaseDamage = 1;
            TotalAttributes = BaseStrength + BaseDexterity + BaseIntelligence;
            setActualDamage();
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
            if ( weapon.RequiredLevel > BaseLevel ) throw new InvalidLevelException();

            Console.WriteLine( "You are allowed to wear this weapon!" );
            DPS = weapon.Damage * weapon.AttackSpeed;
            mySlot.Remove( weapon.ItemSlot );
            mySlot.Add( weapon.ItemSlot, DPS );


            ActualAttackSpeed = BaseAttackSpeed + weapon.AttackSpeed;
            ActualDamage = BaseDamage + weapon.Damage;
            
            setActualDamage();
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

            if ( armour.RequiredLevel > BaseLevel ) throw new InvalidLevelException();
            Console.WriteLine( "You are allowed to wear this armour!" );
            

            if ( armour.ItemSlot.Equals( "WEAPON_HEAD" ) )
                {
                HeadStrength = armour.Strength;
                ActualStrength = BaseStrength + HeadStrength;
                }

            if ( armour.ItemSlot.Equals( "WEAPON_BODY" ) )
                {
                BodyStrength = armour.Strength;
                ActualStrength = BaseStrength + BodyStrength;
                }

            if ( armour.ItemSlot.Equals( "WEAPON_LEGS" ) )
                {
                LegsStrength = armour.Strength;
                ActualStrength = BaseStrength + LegsStrength;
                }

            mySlot.Remove( armour.ItemSlot );
            mySlot.Add( armour.ItemSlot, LegsStrength );


            }

        
        }

    public class Ranger : BaseRanger
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

    public class Rogue : BaseRogue
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

    public class Warrior : BaseWarrior
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
    public abstract class BaseMage : BaseAttributes
        {
        

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
            sb.AppendLine( "Stength: " + BaseStrength  );
            sb.AppendLine( "Dexterity: " + BaseDexterity  );
            sb.AppendLine( "Intelligence: " + BaseIntelligence  );
            sb.AppendLine( "Level: " + BaseLevel   );
            sb.AppendLine( "Attack Speed: " + BaseAttackSpeed  );
            sb.AppendLine( "Damage: " + BaseDamage   );
            sb.AppendLine("Actual Damage: " + ActualDamage);    

            Console.WriteLine(sb);
                        
            }

        public void showActualStats()
            {
            StringBuilder sb = new StringBuilder("", 300);

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