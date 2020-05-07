using System;
using System.Collections.Generic;
using Game.Engine.Skills.BasicSkills;
using Game.Engine.CharacterClasses;
using Game.Engine.Skills.BasicSpells;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class BasicSpellFactory : SkillFactory
    {  
        // this factory produces skills from BasicSpells directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); // check what spells from the BasicSpells category are known by the player already
            if (known == null) // no BasicSpells known - we will return one of them
            {
                FireArrow s1 = new FireArrow();
                LightFlash s2 = new LightFlash();
                WindGust s3 = new WindGust();
                IcarusStorm s4 = new IcarusStorm();
                // only include elligible spells
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (s4.MinimumLevel <= player.Level) tmp.Add(s4);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (known.decoratedSkill == null) // a BasicSpell has been already learned, use decorator to create a combo
            {
                FireArrowDecorator s1 = new FireArrowDecorator(known);
                LightFlashDecorator s2 = new LightFlashDecorator(known);
                WindGustDecorator s3 = new WindGustDecorator(known);
                IcarusStormDecorator s4 = new IcarusStormDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (s4.MinimumLevel <= player.Level) tmp.Add(s4);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null; // a combo of BasicSpells has been already learned - this factory doesn't offer double combos so we stop here
        }
        private Skill CheckContent(List<Skill> skills) // wrapper method for checking
        {
            foreach (Skill skill in skills)
            {
                if (skill is FireArrow || skill is WindGust || skill is LightFlash || skill is FireArrowDecorator || skill is WindGustDecorator || skill is LightFlashDecorator || skill is IcarusStorm || skill is IcarusStormDecorator) return skill;
            }
            return null;
        }       

    }
}
