using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    class CentaursAxe : Axe
    {
        private int centaurWrath;
        Random rand = new Random();
        public CentaursAxe(string name) : base("item0011")
        {
            PublicName = "Centaur's Axe";
            GoldValue = 50;
            strMod = 25;
            prMod = 15;
            staMod = 10;
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            centaurWrath = rand.Next(10, 30);
            if(pack.DamageType == "stab" || pack.DamageType == "incised")
            {
                pack.HealthDmg = (100 +  centaurWrath/ 4) * pack.HealthDmg / 50;
            }
            return pack;
        }
    }
}
