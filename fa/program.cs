using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name = "";
        public Dictionary<char, State> Transitions = new Dictionary<char, State>();
        public bool IsAcceptState;
    }

    public class FA1
{
    private State start;
    private State only0;
    private State only1;
    private State accept;

    public FA1()
    {
        start = new State { Name = "start", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        only0 = new State { Name = "only0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        only1 = new State { Name = "only1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        accept = new State { Name = "accept", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

        // start
        start.Transitions['0'] = only0;
        start.Transitions['1'] = only1;

        // только нули
        only0.Transitions['0'] = only0;
        only0.Transitions['1'] = accept;

        // только единицы
        only1.Transitions['1'] = only1;
        only1.Transitions['0'] = accept;

        // есть и 0 и 1
        accept.Transitions['0'] = accept;
        accept.Transitions['1'] = accept;
    }

    public bool Run(IEnumerable<char> input)
    {
        State current = start;

        foreach (char symbol in input)
        {
            if (!current.Transitions.TryGetValue(symbol, out State next))
                return false;

            current = next;
        }

        return current.IsAcceptState;
    }

    public class FA2
    {
        private State q00;
        private State q01;
        private State q10;
        private State q11;
        private State active;

        public FA2()
        {
            q00 = new State { Name = "q00", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            q01 = new State { Name = "q01", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            q10 = new State { Name = "q10", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            q11 = new State { Name = "q11", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

            q00.Transitions['0'] = q10;
            q00.Transitions['1'] = q01;

            q01.Transitions['0'] = q11;
            q01.Transitions['1'] = q00;

            q10.Transitions['0'] = q00;
            q10.Transitions['1'] = q11;

            q11.Transitions['0'] = q01;
            q11.Transitions['1'] = q10;

            active = q00;
        }

        public bool Run(IEnumerable<char> input)
        {
            active = q00;

            State current = active;
            foreach (char symbol in input)
            {
                if (!current.Transitions.ContainsKey(symbol))
                    return false;;

                current = current.Transitions[symbol];
            }

            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        private State A;
        private State B;
        private State C;
        private State current;

        public FA3()
        {
            A = new State { Name = "A", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            B = new State { Name = "B", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            C = new State { Name = "C", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

            A.Transitions['0'] = A;
            A.Transitions['1'] = B;

            B.Transitions['0'] = A;
            B.Transitions['1'] = C;

            C.Transitions['0'] = C;
            C.Transitions['1'] = C;

            current = A;
        }

        public bool Run(IEnumerable<char> input)
        {
            current = A;

            State activeState = current;
            foreach (char ch in input)
            {
                if (activeState.Transitions.TryGetValue(ch, out State nextState))
                    activeState = nextState;
                else
                    return false;;
            }

            return activeState.IsAcceptState;
        }
    }
}