using System;

namespace rpg_characters
    {
    internal class Program
        {
        private static void Main( string[] args )
            {
            // decrlaring base variables

            Mage mage = new Mage();
            mage.LvLup();
            mage.LvLup();
            mage.LvLup();
            mage.showStats();

            Ranger ranger = new Ranger();
            ranger.LvLup();
            ranger.LvLup();
            ranger.LvLup();
            ranger.showStats();

            Rogue rogue = new Rogue();
            rogue.LvLup();
            rogue.LvLup();
            rogue.LvLup();
            rogue.showStats();

            Warrior warrior = new Warrior();
            warrior.LvLup();
            warrior.LvLup();
            warrior.LvLup();
            warrior.showStats();
            }
        }

    public class Mage : BaseMage
        {
        public string name = ""; // Name must be accessible from outside

        public Mage()
            {
            strength = 1;
            dexterity = 1;
            intelligence = 8;
            }

        public void LvLup()
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
            strength = 1;
            dexterity = 7;
            intelligence = 1;
            }

        public void LvLup()
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
            strength = 2;
            dexterity = 6;
            intelligence = 1;
            }

        public void LvLup()
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
            strength = 5;
            dexterity = 2;
            intelligence = 1;
            }

        public void LvLup()
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
        protected string characterclass = "Mage";

        public void showStats()
            {
            Console.WriteLine( "Here are the values of your character's (" + characterclass + ") base attributes:\n\nStength: " + strength + "\n" + "Dexterity: " + dexterity + "\n" + "intelligence: " + intelligence + "\n" + "Level: " + level );
            }

        // some other stuff
        }

    public abstract class BaseRanger : BaseAttributes
        {
        protected string weaponTypes = "Bow";
        protected string armorTypes = "Leather, Mail";
        protected string characterclass = "Ranger";

        public void showStats()
            {
            Console.WriteLine( "Here are the values of your character's (" + characterclass + ") base attributes:\n\nStength: " + strength + "\n" + "Dexterity: " + dexterity + "\n" + "intelligence: " + intelligence + "\n" + "Level: " + level );
            }

        // some other values
        }

    public abstract class BaseRogue : BaseAttributes
        {
        protected string weaponTypes = "Dagger, Sword";
        protected string armorTypes = "Leather, Mail";
        protected string characterclass = "Rogue";

        public void showStats()
            {
            Console.WriteLine( "Here are the values of your character's (" + characterclass + ") base attributes:\n\nStength: " + strength + "\n" + "Dexterity: " + dexterity + "\n" + "intelligence: " + intelligence + "\n" + "Level: " + level );
            }

        // some other values
        }

    public abstract class BaseWarrior : BaseAttributes
        {
        protected string weaponTypes = "Axe, Hammer, Sword";
        protected string armorTypes = "Mail, Plate";
        protected string characterclass = "Warrior";

        public void showStats()
            {
            Console.WriteLine( "Here are the values of your character's (" + characterclass + ") base attributes:\n\nStength: " + strength + "\n" + "Dexterity: " + dexterity + "\n" + "intelligence: " + intelligence + "\n" + "Level: " + level );
            }

        // some other values
        }

    public abstract class BaseAttributes
        {
        protected int dexterity = 0;
        protected int intelligence = 0;
        protected int level = 0;
        protected int strength = 0;
        protected double damage = 0;
        protected int itemLevel = 0;
        protected string weaponType = "";
        protected bool weaponSlot = true;
        }
    }