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

        public Jinn(int jinnLevel)
        {
            Health = 60 + jinnLevel;
            Strength = 10;
            Armor = 40 + 2 * jinnLevel;
            Precision = 200;

        }

        public override List<StatPackage> BattleMove()
        {
            throw new NotImplementedException();
        }
    }
}
