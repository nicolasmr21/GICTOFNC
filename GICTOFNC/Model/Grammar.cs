using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace GICTOFNC.Model
{

    public class Grammar {

        public List<char> Variables { get; set; }

        public List<char> Terminals { get; set; }

        public List<Production> Productions;

        public Grammar() {
            Productions = new List<Production>();
            Terminals = new List<char>();
            Variables = new List<char>();
        }

        public void setAlphabet(string terminals, string variables)
        {
            Terminals = terminals.Split(',').Select(x=> char.Parse(x)).ToList();
            Variables = variables.Split(',').Select(x => char.Parse(x)).ToList();
            Terminals.Add('x');
        }

        public void setProductions(string productions)
        {
            var t = productions.Split( "\n".ToArray());
            for (int i = 0; i < t.Length; i ++)
            {
                Productions.Add(new Production(t[i][0], t[i].Substring(3)));
            }
            nonTerminals();
            nonReachable();
            anulables();
            unit();
            binaryOrTerm();
            print();
        }

        public bool isTerm(string c)
        {
            if (c.Length != 1)
            {
                return false;
            }
            else
            {
                return Terminals.Contains(char.Parse(c));
            }
        }

        public bool isVar(string c)
        {
            if (c.Length != 1)
            {
                return false;
            }
            else
            {
                return Variables.Contains(char.Parse(c));
            }
        }

        public void nonTerminals()
        {
            List<char> term = new List<char>();
            foreach(var a in Productions)
            {
                if(a.Body.Intersect(Terminals.Select(x=> x.ToString())).Count()!=0)
                {
                    term.Add(a.Head);
                }
            }
            List<char> term1 = new List<char>(term);
            do
            {
                term = new List<char>(term1);
                foreach (var a in Productions)
                {
                    if(a.Body.Any(x=> x.All(y=> term1.Union(Terminals).Contains(y)))&&!term1.Contains(a.Head))
                    {
                        term1.Add(a.Head);
                    }
                }
            } while (!term.SequenceEqual(term1));
            List<char> noTerm = Variables.Except(term1).ToList();
            for (int i = 0; i < Productions.Count; i++)
            {
                Production Prod = Productions[i];
                if (noTerm.Contains(Prod.Head))
                {
                    Productions.Remove(Prod);
                    i--;
                }
                else
                {
                    for (int j = 0; j < Prod.Body.Count; j++)
                    {
                        string body = Prod.Body[j];
                        if (body.Intersect(noTerm).Count() != 0)
                        {
                            Prod.Body.Remove(body);
                            j--;
                        }
                    }
                }
                
            }
        }

        public void nonReachable()
        {
            List<char> reach = new List<char>();
            reach.Add(Variables[0]);
            for (int i = 0; i < reach.Count; i++)
            {
                List<string> l = Productions.First(x => x.Head == reach[i]).Body;
                foreach(var body in l)
                {
                    reach.AddRange(body.Where(x => isVar(x+"")&&!reach.Contains(x)));
                }
            }
            List<char> nonReach = Variables.Except(reach).ToList();
            for (int i = 0; i < nonReach.Count; i++)
            {
                Productions.Remove(Productions.Find(x=> x.Head==nonReach[i]));
            }

        }

        public void print()
        {
            foreach(var p in Productions)
            {
                Console.WriteLine(p);
            }
        }

        public void anulables()
        {
            List<char> anul = new List<char>();
            foreach (var a in Productions)
            {
                if (a.Body.Contains("x"))
                {
                    a.Body.Remove("x");
                    anul.Add(a.Head);
                }
            }
            List<char> anul1 = new List<char>(anul);
            do
            {
                anul = new List<char>(anul1);
                foreach (var a in Productions)
                {
                    if (a.Body.Any(x => x.All(y=> anul1.Contains(y))) && !anul1.Contains(a.Head))
                    {
                        anul1.Add(a.Head);
                    }
                }
            } while (!anul.SequenceEqual(anul1));
            if (anul.Contains(Variables.First()))
            {
                Productions.First().Body.Add("x");
            }
            for (int i = 0; i < Productions.Count; i++)
            {
                Production prod = Productions[i];
                for (int j = 0; j < prod.Body.Count; j++)
                {
                    string body = prod.Body[j];
                    for (int k = 0; k < body.Length; k++)
                    {
                        char l = body[k];
                        if(anul.Contains(l))
                        {
                            List<char> unique = new List<char>(body.ToList());
                            unique.RemoveAt(k);
                            if (unique.Count() != 0)
                            {
                                string n = unique.Select(x => x + "").Aggregate((x, y) => x + y);
                                if (!prod.Body.Contains(n))
                                {
                                    prod.Body.Add(n);
                                }
                            }
                        }
                    }
                }
            }
            

        }

        public void unit()
        {
            List<List<char>> units = new List<List<char>>();
            for(int i = 0; i < Productions.Count; i++)
            {
                var a = Productions[i];
                units.Add(new List<char>());
                units[units.Count - 1].Add(a.Head);
                for (int j = 0; j < a.Body.Count; j++)
                {
                    var prod = a.Body[j];
                    if (isVar(prod))
                    {
                        units[units.Count - 1].Add(char.Parse(prod));
                        a.Body.Remove(prod);
                    }
                }
            }
            List<List<char>> units1 = new List<List<char>>(units);
            do
            {
                units = new List<List<char>>(units1);
                for (int i = 0; i < units1.Count; i++)
                {
                    List<char> uniti = units1[i];
                    for (int j = 1; j < uniti.Count; j++)
                    {
                        units1.First(x => x.First() == uniti[j]).ForEach(x =>
                        {
                            if (!uniti.Contains(x))
                            {
                                uniti.Add(x);
                            }
                        });
                    }
                }
            } while (!units.SequenceEqual(units1));
            foreach(var unit in units)
            {
               foreach(var c in unit)
               {
                    foreach (var prod in Productions.First(x => x.Head == c).Body)
                    {
                        if (!Productions.First(x => x.Head == unit.First()).Body.Contains(prod))
                        {
                            Productions.First(x => x.Head == unit.First()).Body.Add(prod);
                        }
                    }
               }
            }
            
        }

        public void binaryOrTerm()
        {
            Dictionary<char, char> termvars = new Dictionary<char, char>();
            Dictionary<string, char> binaryvars = new Dictionary<string, char>();
            foreach(var a in Terminals)
            {
                if(a!='x')
                {
                    termvars.Add(a, (char)(Variables.Last() + 1));
                    Variables.Add(termvars[a]);
                    Productions.Add(new Production(termvars[a], a.ToString()));
                }
            }
            for (int i = 0; i < Productions.Count; i++)
            {
                var prod = Productions[i];
                for (int j = 0; j < prod.Body.Count; j++)
                {
                    var body = prod.Body[j];
                    foreach(var a in Terminals)
                    {
                        if (a != 'x')
                        {
                            body = body.Replace(a, termvars[a]);
                        }
                    }
                    for (int k = 0; k < body.Length - 1; k++)
                    {
                        if (!binaryvars.ContainsKey(body[k].ToString() + body[k + 1].ToString()) && body.Length > 2)
                        {
                            binaryvars.Add(body[k].ToString() + body[k + 1].ToString(), (char)(Variables.Last() + 1));
                            Variables.Add((char)(Variables.Last() + 1));
                            Productions.Add(new Production(Variables.Last(), body[k].ToString() + body[k + 1].ToString()));
                        }
                        if (body.Length > 2)
                        {
                            body = body.Replace(body[k].ToString() + body[k + 1].ToString(), binaryvars[body[k].ToString() + body[k + 1].ToString()] + "");
                            k--;                            
                        }
                        prod.Body[j] = body;
                    }
                }
            }
        }

        public override string ToString()
        {
            string ret = "";
            foreach(var prod in Productions)
            {
                ret += prod.ToString() + "\n";
            }
            return ret;
        }


    }

}
