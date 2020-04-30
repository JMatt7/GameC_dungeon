using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
    class BasicWeaponFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> basicWeapon = new List<Item>()
            {
                new BasicSword(),
                new LightingSword(),
                new BasicSpear(),
                new BasicAxe(),
                new BasicStaff(),
                new CentaursAxe()
            };
            return basicWeapon[Index.RNG(0, basicWeapon.Count)];
        }

        public Item CreateNonMagicItem()
        {
            List<Item> basicMelee = new List<Item>()
            {
                new BasicSword(),
                new LightingSword(),
                new BasicSpear(),
                new BasicAxe(),
                new CentaursAxe()
            };
            return basicMelee[Index.RNG(0, basicMelee.Count)];
        }

        public Item CreateNonWeaponItem()
        {
            List<Item> basicMagicWeapon = new List<Item>()
            {
                new BasicStaff()
            };
            return basicMagicWeapon[Index.RNG(0, basicMagicWeapon.Count)];

        }
    }
}
