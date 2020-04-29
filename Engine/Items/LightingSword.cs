using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{
    [Serializable]
    class LightingSword : Sword
    {
        public LightingSword() : base("item0009")
        {
            strMod = 30;
            prMod = 12;
            GoldValue = 100;
            staMod = 20;
            PublicName = "Lighting Sword";
        }

        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StrengthBuff += strMod + currentPlayer.Stamina / 2;
            currentPlayer.Stamina += staMod + currentPlayer.Level;
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if(pack.DamageType == "Fire" || pack.DamageType == "Air")
            {
                pack.HealthDmg = (strMod * 4);
            }

            return pack;
        }
    }
}
