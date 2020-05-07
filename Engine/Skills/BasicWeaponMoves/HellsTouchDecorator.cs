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

            RequiredItem = "Axe";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
