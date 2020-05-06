using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicWeaponMoves
{
    class HellsTouch : Skill
    {
        public HellsTouch() : base("Hell's Touch", 25, 2)
        {
            PublicName = "Hell's Touch Attack [requires axe]: ";
            RequiredItem = "Axe";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage resp = new StatPackage("incised");
            resp.HealthDmg = (int)(0.3 * player.Strength) + (int)(0.2 * player.Level);
            resp.CustomText = "You use Hell's Touch Attack! (" + (int)(0.3 * player.Strength) + (int)(0.2 * player.Level) + " incised damage!)";
            return new List<StatPackage>() { resp };
        }
    }
}
