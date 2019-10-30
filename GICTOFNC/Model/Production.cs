using System;
using System.Collections.Generic;

namespace Chomskiador {

    public class Production : IComparable {

        public char Head { get; private set; }

        public string Body { get; set; }

        public Production(char head, string body) {
            Head = head;
            Body = body;
        }

        public override string ToString() {
            return Head + "->" + Body;
        }

        public static SortedSet<Production> Parse(string line) {
            String[] production = line.Split(new char[2] { '-', '>' });
            char head = production[0].ToCharArray()[0];
            String[] bodies = production[2].Split(new char[1] { '|' });
            SortedSet<Production> list = new SortedSet<Production>();
            foreach (String body in bodies)
                list.Add(new Production(head, body));
            return list;
        }

        public int CompareTo(Object obj) {
            if (obj == null) return 1;
            Production otherProduction = obj as Production;
            if (otherProduction != null) {
                if (Body.Length == 1 && Body == otherProduction.Body && Utils.IsTerminal(Body.ToCharArray()[0])) {
                    return 0;
                }
                return (Head + Body).CompareTo(otherProduction.Head + otherProduction.Body);
            } else
                throw new ArgumentException("El argumento no es una producción.");
        }

    }

}
