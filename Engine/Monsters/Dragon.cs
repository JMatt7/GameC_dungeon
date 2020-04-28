using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]

    class Dragon : Monster
    {
        int lastDamageTaken = 0;
        public Dragon(int dragonLevel)
        {
            Health = 100 + 5 * dragonLevel;
            Strength = 30 + 2 * dragonLevel;
            Armor = 20;
            Precision = 100;
            MagicPower = 30;
            Stamina = 200 + 5*dragonLevel;
            XPValue = 200 + dragonLevel;
            Name = "monster0004";
            BattleGreetings = "Let the games begin!"; // Dragon is greeting you

        }
        public override List<StatPackage> BattleMove()
        {
            if (stamina > 30)
            {
                if (lastDamageTaken < 0.5*Health && stamina >=30)
                {
                    stamina -= 30;
                    return new List<StatPackage>() { new StatPackage("Dragon Breath	", strength/2, "Dragon use Dragon Breath! (" + strength/2 + ") burnt damage") };
                }
                else if(lastDamageTaken >= 0.5*Health && lastDamageTaken<=0.9*Health && stamina >= 60)
                {
                    stamina -= 60;
                    return new List<StatPackage>() { new StatPackage("Dragon Claw", strength , strength/2, armor/2, precision/2, magicPower/2, "Dragon use Dragon Claw! (" + strength + ") damage taken!") };
                }
                else
                {
                    stamina -= 100;
                    return new List<StatPackage>() { new StatPackage("Devastating Drake", strength * 3, strength, armor, precision, magicPower, "Dragon use Devastating Drake attack! (" + strength * 3 + ") damage taken!") };

                }
            }
            else
            {
                stamina += 30;
                return new List<StatPackage>() { new StatPackage("none", 0, "Dragon is gathering stamina for next attack!") };
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
