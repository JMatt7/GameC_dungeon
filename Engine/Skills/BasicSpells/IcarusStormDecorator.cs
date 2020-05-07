using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSpells
{
    [Serializable]
    class IcarusStormDecorator : SkillDecorator
    {
        public IcarusStormDecorator(Skill skill) : base("Icarus Storm", 20, 3, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "Combo - Icarus Storm: Player's Level + 0.5*MP damage [air] and" + decoratedSkill.PublicName.Replace("Combo: ", "");
            RequiredItem = "Staff";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage resp = new StatPackage("air");
            resp.HealthDmg = player.Level + (int)(0.5 * player.MagicPower);
            resp.CustomText = "You use Icarus Storm - a spinning attack that hits enemy with air (" + (player.Level + (int)(0.5 * player.MagicPower)) + ") air damage!";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(resp);
            return combo;
        }
    }
}
