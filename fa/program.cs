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
    private State S_start;
    private State S_haveZero_noOne;
    private State S_haveZero_haveOne;
    private State S_error;
    private State InitialState;

    public FA1()
    {
        S_start = new State() { Name = "S_start", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        S_haveZero_noOne = new State() { Name = "S_haveZero_noOne", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        S_haveZero_haveOne = new State() { Name = "S_haveZero_haveOne", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
        S_error = new State() { Name = "S_error", IsAcceptState = false, Transitions = new Dictionary<char, State>() };

        S_start.Transitions['0'] = S_haveZero_noOne;
        S_start.Transitions['1'] = S_start;

        S_haveZero_noOne.Transitions['0'] = S_error;
        S_haveZero_noOne.Transitions['1'] = S_haveZero_haveOne;

        S_haveZero_haveOne.Transitions['0'] = S_error;
        S_haveZero_haveOne.Transitions['1'] = S_haveZero_haveOne;

        S_error.Transitions['0'] = S_error;
        S_error.Transitions['1'] = S_error;

        InitialState = S_start;
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
    private State S_even0_even1;
    private State S_even0_odd1;
    private State S_odd0_even1;
    private State S_odd0_odd1;
    private State InitialState;

    public FA2()
    {
        S_even0_even1 = new State() { Name = "S_even0_even1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        S_even0_odd1 = new State() { Name = "S_even0_odd1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        S_odd0_even1 = new State() { Name = "S_odd0_even1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        S_odd0_odd1 = new State() { Name = "S_odd0_odd1", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

        S_even0_even1.Transitions['0'] = S_odd0_even1;
        S_even0_even1.Transitions['1'] = S_even0_odd1;

        S_even0_odd1.Transitions['0'] = S_odd0_odd1;
        S_even0_odd1.Transitions['1'] = S_even0_even1;

        S_odd0_even1.Transitions['0'] = S_even0_even1;
        S_odd0_even1.Transitions['1'] = S_odd0_odd1;

        S_odd0_odd1.Transitions['0'] = S_even0_odd1;
        S_odd0_odd1.Transitions['1'] = S_odd0_even1;

        InitialState = S_even0_even1;
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