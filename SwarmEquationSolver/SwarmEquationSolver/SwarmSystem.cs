using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwarmEquationSolver
{
    class SwarmSystem
    {
        public SwarmSystem(int snum)
        {
            this.swamnumb = snum;
        }

        int swamnumb;
        public int SwamNum
        {
            get { return swamnumb; }
        }
        public double funcValue;

        public List<Particle> PList = new List<Particle>();

        public double Px { get; set; }
        public double Py { get; set; }
        public double Gx { get; set; }
        public double Gy { get; set; }

        public void Initialize()
        {
            // create some particles and initialize them randomly
            Random ran = new Random();

            for (int i = 0; i < 50; i++)
            {
                Particle p1 = new Particle();
                p1.W = 0.73;
                p1.C1 = 1.4;
                p1.C2 = 1.5;
                p1.Xx = ran.NextDouble() * 20;
                p1.Xy = ran.NextDouble() * 20;
                double num = ran.NextDouble();
                if (num > 0.5)
                {
                    p1.Xx = -1 * p1.Xx;
                    p1.Xy = -1 * p1.Xy;
                }

                p1.Vx = ran.NextDouble() * 5;
                p1.Vy = ran.NextDouble() * 5;

                num = ran.NextDouble();
                p1.Vx = ran.NextDouble() * 5;
                p1.Vy = ran.NextDouble() * 5;
                num = ran.NextDouble();
                if (num > 0.5)
                {
                    p1.Vx = -1 * p1.Vx;
                    p1.Vy = -1 * p1.Vy;
                }
                PList.Add(p1);
            }
        }

        public SwarmResult DoPSO()
        {

            Gx = PList[0].Xx;
            Gy = PList[0].Xy;

            for (int i = 0; i < 1000; i++)
            {
                // find best position in the swarm
                Px = PList[0].Xx;
                Py = PList[0].Xy;
                foreach (Particle pt in PList)
                {
                    if (Math.Abs(FunctionValue(pt.Xx, pt.Xy)) <
                        Math.Abs(FunctionValue(Px, Py)))
                    {
                        Px = pt.Xx;
                        Py = pt.Xy;
                    }
                }
                if (Math.Abs(FunctionValue(Px, Py)) < Math.Abs(FunctionValue(Gx,Gy)))
                {
                    Gx = Px;
                    Gy = Py;
                    Console.WriteLine("Gx & Gy = "+ FunctionValue(Gx,Gy).ToString());
                }

                foreach (Particle pt in PList)
                {
                    pt.UpdateVelocity(Px, Py,Gx, Gy);
                    pt.UpdatePosition();
                }
            }

            SwarmResult sr = new SwarmResult
            {
                swarmId = swamnumb,
                X = Gx,
                Y = Gy,
                funcValue = FunctionValue(Gx, Gy)
            };
            return sr;
            //MessageBox.Show("Root = " + G.ToString() + " function value = " + FunctionValue(G).ToString());
            
        }

        public double FunctionValue(double x, double y)
        {
            // y = x^5 + 3x^4 - 27 x^2 + 2.5 x + 35
            //  double res = Math.Pow(x, 5) + 3 * Math.Pow(x, 4) -
            //      27 * x * x + 2.5 * x + 35;
            //  return res;

            //Rosenbrock Func
            double res = (1 - x) * (1 - x) + 100 *
                (y - (x * x)) * (y - (x * x));
            return res;
        }
    }
}
