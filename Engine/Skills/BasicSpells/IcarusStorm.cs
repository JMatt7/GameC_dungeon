using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSpells
{
    [Serializable]
    class IcarusStorm : Skill
    {
        public IcarusStorm() : base("Icarus Storm", 20, 3)
        {
            PublicName = "Icarus Storm: Player's Level + 0.5*MP damage [air]";
            RequiredItem = "Staff";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage resp = new StatPackage("air");
            resp.HealthDmg = player.Level + (int)(0.5 * player.MagicPower);
            resp.CustomText = "You use Icarus Storm! (" + (player.Level + (int)(0.5 * player.MagicPower)) + ") air damage.";
            return new List<StatPackage>() { resp };
        }
    }
}
