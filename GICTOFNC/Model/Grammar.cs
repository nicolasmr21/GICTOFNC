using System;
using System.Text;
using System.Collections.Generic;

namespace Chomskiador {

    public class Grammar {

        public SortedSet<Variable> Variables { get; set; }

        public SortedSet<Terminal> Terminals { get; set; }
        
        public SortedSet<Production> Productions { get; set; }

        public Grammar() {
            Productions = new SortedSet<Production>();
            Terminals = new SortedSet<Terminal>();
            Variables = new SortedSet<Variable>();
        }

        public override String ToString() {
            StringBuilder sb = new StringBuilder();
            string prod;
            foreach (Variable v in Variables) {
                if (IsHead(v.Var)) {
                    sb.Append("\n");
                    sb.Append(v.Var);
                    sb.Append("->");
                    prod = "";
                    foreach (Production p in Productions) {
                        if (v.Var == p.Head) {
                            prod += (p.Body + "|");
                        }
                    }
                    prod = prod.TrimEnd(new char[1] { '|' });
                    sb.Append(prod); 
                }
            }
            return sb.ToString();
        }

        public void Compile() {
            foreach (Production p in Productions) {
                Variables.Add(new Variable(p.Head));
                foreach (char c in p.Body.ToCharArray()) {
                    if (Utils.IsTerminal(c)) {
                        Terminals.Add(new Terminal(c));
                    } else if (Utils.IsVariable(c)) {
                        Variables.Add(new Variable(c));
                    }
                }
            }
        }

        public bool IsHead(char c) {
            foreach (Production p in Productions) {
                if (p.Head == c) {
                    return true;
                }
            }
            return false;
        }

        public string ConcatTerminals() {
            StringBuilder sb = new StringBuilder();
            foreach (Terminal t in Terminals)
                sb.Append(t.Term + " ");
            return sb.ToString();
        }

        public string ConcatVariables() {
            StringBuilder sb = new StringBuilder();
            foreach (Variable v in Variables)
                sb.Append(v.Var + " ");
            return sb.ToString();
        }

        public char NextVariable() {
            return (char)(((int)Variables.Max.Var) + 1);
        }

        public char NextChar(char c) {
            return (char)(((int)c) + 1);
        }

        public void Start() {
            //Productions.UnionWith(Production.Parse("Z->S"));
            Compile();
        }

        public void Term1() {
            SortedSet<Production> newP = new SortedSet<Production>();
            char nextVar = NextVariable();
            foreach (Production p in Productions) {
                char[] body = p.Body.ToCharArray();
                if (body.Length > 1) {
                    foreach (Char c in body) {
                        if (Utils.IsTerminal(c)) {
                            bool success = newP.Add(new Production(nextVar, "" + c));
                            if (success) {
                                nextVar = NextChar(nextVar);
                            }
                        }
                    } 
                }
            }
            Productions.UnionWith(newP);
            Compile();
        }

        public void Term2() {
            SortedSet<Production> terminable = new SortedSet<Production>();
            foreach (Production p in Productions) {
                if (p.Body.Length == 1 && Utils.IsTerminal(p.Body.ToCharArray()[0])) {
                    terminable.Add(p);
                }
            }
            SortedSet<Production> newP = new SortedSet<Production>();
            SortedSet<Production> delP = new SortedSet<Production>();
            do {
                newP.Clear();
                delP.Clear();
                foreach (Production p in Productions) {
                    foreach (Production t in terminable) {
                        if (p.Body.Contains(t.Body) && p.Body.Length > 1) {
                            Production prod = new Production(p.Head, p.Body);
                            prod.Body = prod.Body.Replace(t.Body, "" + t.Head);
                            delP.Add(new Production(p.Head, p.Body));
                            newP.Add(prod);
                        }
                    }
                }
                foreach (Production p in delP) {
                    Productions.Remove(p);
                }
                Productions.UnionWith(newP); 
            } while (delP.Count + newP.Count >= 1);
            Compile();
        }

        public void Bin() {
            char nextVar = NextVariable();
            SortedSet<Production> newP = new SortedSet<Production>();
            SortedSet<Production> delP = new SortedSet<Production>();
            do {
                newP.Clear();
                delP.Clear();
                foreach (Production p in Productions) {
                    if (p.Body.Length >= 3) {
                        newP.Add(new Production(p.Head, p.Body.Remove(1) + nextVar));
                        newP.Add(new Production(nextVar, p.Body.Substring(1)));
                        delP.Add(p);
                        nextVar = NextChar(nextVar);
                    }
                }
                foreach (Production p in delP) {
                    Productions.Remove(p);
                }
                Productions.UnionWith(newP);
            } while (delP.Count + newP.Count >= 1);
            Compile();
        }
        
        public void Del() {
            SortedSet<Variable> nullableV = new SortedSet<Variable>();
            SortedSet<Production> nullableP = new SortedSet<Production>();
            foreach (Production p in Productions){
                if (Utils.IsNullable(p)) {
                    nullableV.Add(new Variable(p.Head));
                    nullableP.Add(p);
                }
            }
            if (nullableV.Count == 0) return;
            SortedSet<Variable> addN = new SortedSet<Variable>();
            SortedSet<Production> newP = new SortedSet<Production>();
            do {
                addN.Clear();
                newP.Clear();
                foreach (Production p in Productions) {
                    char[] chars = p.Body.ToCharArray();
                    int counter = 0;
                    foreach (char c in chars) {
                        if (nullableV.Contains(new Variable(c))) {
                            counter++;
                        }
                    }
                    if (counter == chars.Length && !nullableV.Contains(new Variable(p.Head))) {
                        addN.Add(new Variable(p.Head));
                        newP.Add(new Production(p.Head, "z"));
                        nullableP.Add(new Production(p.Head, "z"));
                        nullableP.Add(p);
                    }
                }
                nullableV.UnionWith(addN);
                Productions.UnionWith(newP);
            } while (addN.Count >= 1);
            newP.Clear();
            string pro = "";
            foreach (Production p in Productions) {
                SortedSet<string> binaries = Utils.Binaries(p.Body.Length);
                char[] chars = p.Body.ToCharArray();
                foreach (string s in binaries) {
                    char[] binC = s.ToCharArray();
                    for (int c = 0; c < chars.Length; c++) {
                        if (!nullableV.Contains(new Variable(chars[c])) || (binC[c] == '1')) {
                            pro += chars[c];
                        }
                    }
                    if (pro != "") {
                        newP.Add(new Production(p.Head, pro));
                    }
                    pro = "";
                }
            }
            Productions.UnionWith(newP);
            foreach (Production p in nullableP) {
                if (Utils.IsNullable(p) && !Utils.IsInitial(p)) {
                    Productions.Remove(p);
                }
            }
            Compile();
        }

        public void Unit() {
            SortedSet<Production> unitary = new SortedSet<Production>();
            SortedSet<Production> newP = new SortedSet<Production>();
            SortedSet<Production> delP = new SortedSet<Production>();
            do {
                unitary.Clear();
                newP.Clear();
                delP.Clear();
                foreach (Production p in Productions) {
                    if (p.Body.Length == 1 && Utils.IsVariable(p.Body.ToCharArray()[0])) {
                        unitary.Add(p);
                    }
                }
                foreach (Production p in Productions) {
                    foreach (Production u in unitary) {
                        if (u.Body == ("" + p.Head)) {
                            newP.Add(new Production(u.Head, p.Body));
                            delP.Add(u);
                        }
                    }
                }
                foreach (Production p in delP) {
                    Productions.Remove(p);
                }
                Productions.UnionWith(newP);
            } while (delP.Count + newP.Count >= 1);
            Compile();
        }

    }

}
