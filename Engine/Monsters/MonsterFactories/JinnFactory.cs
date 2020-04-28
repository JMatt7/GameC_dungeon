using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game.Engine.Monsters.MonsterFactories
{
    class JinnFactory : MonsterFactory
    {
        private int encounterNumber = 0;

        public override Monster Create(int playerLevel)
        {
            if (encounterNumber < 2)
            {
                encounterNumber++;
                return new Jinn(playerLevel);
            }
            else
            {
                return null;
            }
        }

        public override Image Hint()
        {
            if (encounterNumber < 2)
            {
                return new Jinn(0).GetImage();
            }
            else
            {
                return null;
            }
        }
    }
}
