using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game.Engine.Monsters.MonsterFactories
{
    class DragonFactory : MonsterFactory
    {
        private int encounterNumber = 0;
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Dragon(playerLevel);
            }
            else
            {
                return null;
            }
        }

        public override Image Hint()
        {
            if (encounterNumber == 0)
            {
                return new Dragon(0).GetImage();
            }
            else
            {
                return null;
            }
        }
    }
}
