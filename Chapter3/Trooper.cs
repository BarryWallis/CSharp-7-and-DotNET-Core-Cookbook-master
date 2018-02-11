using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTheFinalFrontier
{
    public class Trooper
    {
        public virtual List<string> GetSkills() => new List<string>(new string[] { "none" });
    }
}
