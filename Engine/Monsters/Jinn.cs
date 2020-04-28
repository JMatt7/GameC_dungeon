using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Jinn : Monster
    {
        int lastMagicPower = 0;
        Random rand = new Random();
        public Jinn(int jinnLevel)
        {
            Health = 60 + jinnLevel;
            Strength = 10;
            Armor = 40 + 2 * jinnLevel;
            Precision = 200;
            magicPower = 14 + 2*jinnLevel;
            stamina = 120 + jinnLevel*10;
            XPValue = 200 + 5 * jinnLevel;
            Name = "monster0005";
            BattleGreetings = "My magic will destroy you!!!";
        }

        public override List<StatPackage> BattleMove()
        {
            if(stamina > 20)
            {
                int r = rand.Next(1, 4);
                if(lastMagicPower < 0.5 * MagicPower)
                {
                    stamina -= 20;
                    return new List<StatPackage>() { new StatPackage("Ice Strike", magicPower*r, "Jinn use Ice strike! (" + magicPower * r + ") damage taken!") };

                }
                else
                {
                    stamina -= 20;
                    return new List<StatPackage>() { new StatPackage("Blizzard", magicPower * r, 0, armor/2, 0, magicPower, "Jinn use Blizzard attack! (" + magicPower * r + ") damage taken!") };

                }
            }
            else
            {
                stamina += 20;
                return new List<StatPackage>() { new StatPackage("none", 0, "Jinn is gathering stamina for next attack!") };
            }
        }

        public override void React(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                lastMagicPower = pack.MagicPowerDmg;
                Health -= pack.HealthDmg;
                Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
            }

        }
    }
}
