using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;
using Game.Engine.Skills.BasicWeaponMoves;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class AdvancedWeaponSkillFactory : SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playersSkills = player.ListOfSkills;
            Skill known = CheckContent(playersSkills);
            if(known == null)
            {
                QuiveringBlade s1 = new QuiveringBlade();
                HellsTouch s2 = new HellsTouch();

                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1);
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else if(known.decoratedSkill == null)
            {
                QuiveringBladeDecorator s1 = new QuiveringBladeDecorator(known);
                HellsTouchDecorator s2 = new HellsTouchDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1);
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else
            {
                return null;
            }
        }

        private Skill CheckContent(List<Skill> playersSkills)
        {
            foreach(Skill skill in playersSkills)
            {
                if (skill is QuiveringBlade || skill is QuiveringBladeDecorator || skill is HellsTouch || skill is HellsTouchDecorator) return skill;
            }

            return null;
        }
    }
}
