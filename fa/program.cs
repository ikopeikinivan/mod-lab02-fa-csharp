using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }
  public class FA
  {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA()
        {
           a.Transitions['0'] = a;
           a.Transitions['1'] = b;
           b.Transitions['0'] = c;
           b.Transitions['1'] = a;
           c.Transitions['0'] = b;
           c.Transitions['1'] = c;            
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
  }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "0000010111";
      FA fa = new FA();
      bool? result = fa.Run(s);
      Console.WriteLine(result);
    }
  }

  public class FA1
  {
      private State S0;
      private State S1;
      private State S2;
      private State S_err;

      private State InitialState;

      public FA1()
      {
          S0 = new State() { Name = "S0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
          S1 = new State() { Name = "S1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
          S2 = new State() { Name = "S2", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
          S_err = new State() { Name = "S_err", IsAcceptState = false, Transitions = new Dictionary<char, State>() };

          S0.Transitions['0'] = S1;
          S0.Transitions['1'] = S0;

          S1.Transitions['0'] = S_err;
          S1.Transitions['1'] = S2;

          S2.Transitions['0'] = S_err;
          S2.Transitions['1'] = S2;

          S_err.Transitions['0'] = S_err;
          S_err.Transitions['1'] = S_err;

          InitialState = S0;
      }

      public bool? Run(IEnumerable<char> s)
      {
          State current = InitialState;
          foreach (char c in s)
          {
              if (!current.Transitions.ContainsKey(c))
                  return null;
              current = current.Transitions[c];
          }
          return current.IsAcceptState;
      }
  }

  public class FA2
  {
      private State S00;
      private State S01;
      private State S10;
      private State S11;

      private State InitialState;

      public FA2()
      {
          S00 = new State() { Name = "S00", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
          S01 = new State() { Name = "S01", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
          S10 = new State() { Name = "S10", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
          S11 = new State() { Name = "S11", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

          S00.Transitions['0'] = S10;
          S01.Transitions['0'] = S11;
          S10.Transitions['0'] = S00;
          S11.Transitions['0'] = S01;

          S00.Transitions['1'] = S01;
          S01.Transitions['1'] = S00;
          S10.Transitions['1'] = S11;
          S11.Transitions['1'] = S10;

          InitialState = S00;
      }

      public bool? Run(IEnumerable<char> s)
      {
          State current = InitialState;
          foreach (char c in s)
          {
              if (!current.Transitions.ContainsKey(c))
                  return null;
              current = current.Transitions[c];
          }
          return current.IsAcceptState;
      }
  }

  public class FA3
  {
      private State S0;
      private State S1;
      private State S2;

      private State InitialState;

      public FA3()
      {
          S0 = new State() { Name = "S0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
          S1 = new State() { Name = "S1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
          S2 = new State() { Name = "S2", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

          S0.Transitions['0'] = S0;
          S0.Transitions['1'] = S1;

          S1.Transitions['0'] = S0;
          S1.Transitions['1'] = S2;

          S2.Transitions['0'] = S2;
          S2.Transitions['1'] = S2;

          InitialState = S0;
      }

      public bool? Run(IEnumerable<char> s)
      {
          State current = InitialState;
          foreach (char c in s)
          {
              if (!current.Transitions.ContainsKey(c))
                  return null;
              current = current.Transitions[c];
          }
          return current.IsAcceptState;
      }
  }
}