using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKC3_Init_scripts
{
    class KeyValueScript
    {
        public int addr;
        public string str;
        public int key = -1;
        public List<int> values = new List<int>();
        public int pointer = 0;

        public KeyValueScript(int addr, string str)
        {
            this.addr = addr & 0x3fffff;
            this.str = str;
        }
        public override string ToString()
        {
            return str;
        }
    }
}
