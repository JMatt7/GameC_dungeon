using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicWeaponMoves
{
    [Serializable]
    class QuiveringBlade : Skill
    {
        public QuiveringBlade() : base("Quivering Blade", 30, 3)
        {
            PublicName = "Quivering Blade Attack [requires sword]: ";
            RequiredItem = "Sword";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response1 = new StatPackage("stab");
            response1.HealthDmg = (int)(0.2 * player.Strength) + (int)(0.5 * player.Level);
            StatPackage response2 = new StatPackage("incised");
            response2.HealthDmg = (int)(0.2 * player.MagicPower);
            response2.CustomText = "You use Quivering Blade Attack! (" + ((int)(0.2 * player.Strength) + (int)(0.5 * player.Level)) + " stab damage, " + ((int)(0.2 * player.MagicPower) + " incised damage)");
            return new List<StatPackage>() { response1, response2 };
        }
    }
}
