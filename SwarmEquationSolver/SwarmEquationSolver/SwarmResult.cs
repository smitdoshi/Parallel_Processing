using System;

namespace SwarmEquationSolver
{
    class SwarmResult : IComparable<SwarmResult>
    {
        public int swarmId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double funcValue { get; set; }

        public override string ToString()
        {
            return "SWARM_Id:" + swarmId.ToString() +
                " X=" + X.ToString() +
                " Y=" + Y.ToString() +
                "Function Value=" + funcValue.ToString();
        }

        public int CompareTo(SwarmResult other)
        {
            return this.funcValue.CompareTo(other.funcValue);
        }
    }
}