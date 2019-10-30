using System;

namespace Chomskiador {

    public class Variable : IComparable {

        public char Var { get; private set; }

        public Variable(char var) {
            Var = var;
        }

        public int CompareTo(Object obj) {
            if (obj == null) return 1;
            Variable otherVariable = obj as Variable;
            if (otherVariable != null)
                return Var.CompareTo(otherVariable.Var);
            else
                throw new ArgumentException("El argumento no es una variable.");
        }

    }

}
