using System;
using System.Collections.Generic;
using System.Linq;

namespace GICTOFNC.Model
{

    public class Production  {

        public char Head { get; private set; }

        public List<string> Body { get; set; }

        public Production(char head, string body) {
            Head = head;
            Body = body.Split('|').ToList();
        }

        public override string ToString() {
            string r = Head + "->";
            foreach(var t in Body)
            {
                r += t + "|";
            }
            return r.Substring(0, r.Length-1);
        }

        

    }

}
