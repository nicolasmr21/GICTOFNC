using System;

namespace Chomskiador {

    public class Terminal : IComparable {

        public char Term { get; private set; }

        public Terminal(char term) {
            Term = term;
        }

        public int CompareTo(Object obj) {
            if (obj == null) return 1;
            Terminal otherTerminal = obj as Terminal;
            if (otherTerminal != null)
                return Term.CompareTo(otherTerminal.Term);
            else
                throw new ArgumentException("El argumento no es un terminal.");
        }

    }

}
