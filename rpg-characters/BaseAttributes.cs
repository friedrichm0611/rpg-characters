using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_characters
{
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
            sb.AppendLine("\nHere are the (new) base values of your character's (" + CharacterClass + ") base attributes:\n");
            sb.AppendLine("Stength: " + BaseStrength);
            sb.AppendLine("Dexterity: " + BaseDexterity);
            sb.AppendLine("Intelligence: " + BaseIntelligence);
            sb.AppendLine("Level: " + BaseLevel);

            Console.WriteLine(sb);
        }
    }

}
