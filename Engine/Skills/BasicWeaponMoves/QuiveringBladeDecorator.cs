using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicWeaponMoves
{
    [Serializable]
    class QuiveringBladeDecorator : SkillDecorator
    {
        public QuiveringBladeDecorator(Skill skill) : base("Quivering Blade" , 30, 3, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "Combo: Wrath of Gods: decrease enemy armor by 20 and" + decoratedSkill.PublicName.Replace("Combo: ", "");
            RequiredItem = "Sword";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("stab");
            response.ArmorDmg = 20;
            response.CustomText = "You use Quivering Blade (enemy armor decreased by 20)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
            
        }
    }
}
