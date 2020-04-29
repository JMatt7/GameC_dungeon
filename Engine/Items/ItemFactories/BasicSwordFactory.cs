using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
    class BasicSwordFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> basicArmor = new List<Item>()
            {
                new BasicSword(),
                new LightingSword()
            };
            return basicArmor[Index.RNG(0, basicArmor.Count)];
        }

        public Item CreateNonMagicItem()
        {
            List<Item> basicArmor = new List<Item>()
            {
                new BasicSword(),
                new LightingSword()
            };
            return basicArmor[Index.RNG(0, basicArmor.Count)];
        }

        public Item CreateNonWeaponItem()
        {
            return null;
        }
    }
}
