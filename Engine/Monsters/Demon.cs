using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    //example monster Demon
    class Demon : Monster
    {
        Random random = new Random();
        int lastDamageTaken = 0;
        public Demon(int demonLevel)
        {
            Health = 50 + 5 * demonLevel;
            Strength = 20 + 2 * demonLevel;
            Armor = 10;
            Precision = 75;
            MagicPower = 20;
            Stamina = 100 + demonLevel;
            XPValue = 100 + demonLevel;
            Name = "monster0003";
            BattleGreetings = "The fire will burn you!"; // Demon is greeting you

        }
        public override List<StatPackage> BattleMove()
        {
            if (stamina > 0)
            {
                int rand = random.Next(0, 10);
                if (rand < 8 || lastDamageTaken < 0.6*Health)
                {
                    stamina -= 15;
                    return new List<StatPackage>() { new StatPackage("Basic Fire", strength, "Demon use fire attack! (" + strength + ") burnt damage") };
                }
                else
                {
                    stamina -= 30;
                    return new List<StatPackage>() { new StatPackage("Advanced Fire", strength * 2, strength, armor, precision, magicPower, "Demon use advanced fire attack! (" + strength * 2 + ") burnt damage") };
                }
            }
            else
            {
                stamina += 10;
                return new List<StatPackage>() { new StatPackage("none", 0, "Demon is gathering stamina for next attack!") };
            }
        }

        public override void React(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                lastDamageTaken = pack.HealthDmg;
                Health -= pack.HealthDmg;
                Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
            }
        }
    }
}
