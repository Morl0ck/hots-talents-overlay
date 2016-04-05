using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExternalDirectxOverlayNet2
{
    public class Build
    {
        public string name { get; set; }
        public List<Talent> talents { get; set; }

        public Build()
        {
            this.talents = new List<Talent>();
        }
    }
}
