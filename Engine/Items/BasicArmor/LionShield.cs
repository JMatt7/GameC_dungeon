using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items.BasicArmor
{
    [Serializable]
    class LionShield : Item
    {
        public LionShield() : base("item0012")
        {
            PublicName = "Lion's Shield of Courage";
            GoldValue = 50;
            arMod = 40;
            mgcMod = 20;
        }

        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.ArmorBuff += arMod + currentPlayer.Level / 2;
            currentPlayer.MagicPowerBuff += mgcMod + currentPlayer.MagicPower / 4;
        }

    }
}
