using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items.BasicArmor
{
    [Serializable]
    class TitanCuirass : Item
    {
        public TitanCuirass() : base("item0010")
        {
            PublicName = "Titan Cuirass";
            GoldValue = 60;
            arMod = 35;
            mgcMod = 30;
        }

        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.ArmorBuff += arMod + currentPlayer.Level / 2;
            currentPlayer.MagicPowerBuff += mgcMod + currentPlayer.MagicPower / 4;
        }

        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if(otherItems.Contains("Lighting Sword"))
            {
                pack.ArmorDmg -= pack.ArmorDmg / 2;
            }
            return pack;
        }
    }
}
