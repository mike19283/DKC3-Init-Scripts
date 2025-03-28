using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKC3_Init_scripts
{
    public class Sprites
    {
        public int key;
        public string value;

        public Sprites (int key, string value)
        {
            this.key = key;
            this.value = value;
        }
        public override string ToString()
        {
            return value;
        }
    }
}
