using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTheFinalFrontier
{
    public class StarTrooper
    {
        public enum TrooperClass { Soldier, Medic, Scientist};

        List<string> TroopSkill = new List<string>();

        public List<string> GetSkills(TrooperClass trooperClass)
        {
            switch (trooperClass)
            {
                case TrooperClass.Soldier:
                    TroopSkill = new List<string>(new string[] { "Weaponry", "TacticalCombat", "HandToHandComabt" });
                    break;
                case TrooperClass.Medic:
                    TroopSkill = new List<string>(new string[] { "CPR", "AdvancedLifeSupport" });
                    break;
                case TrooperClass.Scientist:
                    TroopSkill = new List<string>(new string[] { "Chemistry", "MollecularDeconstruction", "QuarkTheory" });
                    break;
                default:
                    TroopSkill = new List<string>(new string[] { "none" });
                    break;
            }

            return TroopSkill;
        }
    }
}
