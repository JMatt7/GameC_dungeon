using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicWeaponMoves
{
    [Serializable]
    class HellsTouchDecorator : SkillDecorator
    {
        public HellsTouchDecorator(Skill skill) : base("Hell's Touch", 25, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "Combo: Extremely quick burst of energy: increased strength by 30, decreased enemy magic power by 15 and " + decoratedSkill.PublicName.Replace("Combo: ", "");
            RequiredItem = "Axe";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("incised");
            response.MagicPowerDmg = 15;
            player.Strength += 30;
            response.CustomText = "You use Hell's Touch (Player's strength increased by 30 and enemy magic power decreased by 15)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            return combo; 
        }
    }
}
