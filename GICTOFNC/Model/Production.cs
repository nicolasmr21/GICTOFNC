using System;
using System.Collections.Generic;
using System.Linq;


namespace GICTOFNC.Model
{
    /**
     *  This class represents a production into de grammar, it mean something likely to A->B
     *  Where A is the head and B the body of the production
     */
    public class Production  {

        /**
        *    Head of a production, it means the variable of the grammar
        */
        public char Head { get; private set; }

        /**
        *    Body of a production
        */
        public List<string> Body { get; set; }

        /**
        *    This method provides a constructor to a production
        */
        public Production(char head, string body) {
            Head = head;
            Body = body.Split('|').ToList();
        }

        /**
           This method concatenate the body to obtain the original production   
        */
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
