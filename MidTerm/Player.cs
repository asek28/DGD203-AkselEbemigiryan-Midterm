using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm
{
    public class Player
    {
        public string Name { get; set; }

        public Player(string name = "Alan Grant")
        {
            Name = name;
        }


        public void Initialize(string name)
        {
            Name = name;
        }
    }
}
