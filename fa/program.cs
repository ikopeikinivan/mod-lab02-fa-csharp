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


  public class FA1
  {
    public bool? Run(IEnumerable<char> s)
    {
      return false;
    }
  }

  public class FA2
  {
    public bool? Run(IEnumerable<char> s)
    {
      return false;
    }
  }
  
  public class FA3
  {
    public bool? Run(IEnumerable<char> s)
    {
      return false;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
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