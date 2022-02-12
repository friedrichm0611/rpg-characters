using System;

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
            }
        }

    public class Mage : BaseMage
        {
        public string name = ""; // Name must be accessible from outside

        public Mage()
            {
            characterclass = "Mage";
            strength = 1;
            dexterity = 1;
            intelligence = 8;
            }

        public void LevelUp()
            {
            strength++;
            dexterity++;
            intelligence += 5;
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
            strength = 2;
            dexterity = 6;
            intelligence = 1;
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
            strength = 5;
            dexterity = 2;
            intelligence = 1;
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

    public abstract class BaseAttributes
        {
        protected int dexterity = 0;
        protected int intelligence = 0;
        protected int level = 0;
        protected int strength = 0;
        protected double damage = 0;
        protected string characterclass = "";

        public void showStats()
            {
            Console.WriteLine( "Here are the values of your character's (" + characterclass + ") base attributes:\n\nStength: " + strength + "\nDexterity: " + dexterity + "\nintelligence: " + intelligence + "\nLevel: " + level );
            }
        }
        enum Weapon
        {
        Axe,
        Bow,
        Dagger,
        Hammer,
        Staff,
        Sword,
        Wand
        }

        enum Armour
        {
        Cloth,
        Leather,
        Mail,
        Plate
        }
    }