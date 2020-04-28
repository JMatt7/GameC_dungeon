using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    //example monster Demon
    class Dragon : Monster
    {
        Random random = new Random();
        public Dragon(int dragonLevel)
        {
            Health = 50 + 5 * dragonLevel;
            Strength = 20 + 2 * dragonLevel;
            Armor = 10;
            Precision = 75;
            MagicPower = 20;
            Stamina = 100 + dragonLevel;
            XPValue = 100 + dragonLevel;
            Name = "monster0004";
            BattleGreetings = "Let the games begin!"; // Demon is greeting you

        }
        public override List<StatPackage> BattleMove()
        {
            if (stamina > 0)
            {
                int rand = random.Next(0, 10);
                if (rand < 8)
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
    }
}
