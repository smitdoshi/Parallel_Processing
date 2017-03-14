using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwarmEquationSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSolveBySwarm_Click(object sender, EventArgs e)
        {
            SwarmSystem ss = new SwarmSystem(0);
            ss.Initialize();
            SwarmResult sr = ss.DoPSO();
           //txtGValue.Text = ss.funcValue.ToString();
            lblResult.Text = sr.ToString();
            //double res = ss.FunctionValue(-1.14);
            //MessageBox.Show(res.ToString());

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnParallelSwarms_Click(object sender, EventArgs e)
        {
            int launchSwams = 10;
            // An Array of List
            Task<SwarmResult>[] arrTask = new Task<SwarmResult>[launchSwams];

            // for loop
            for(int i=0; i < arrTask.Length; i++)
            {
                arrTask[i] = Task.Factory.StartNew<SwarmResult>((obj) =>
                {
                    SwarmSystem ss = new SwarmSystem((int)obj);
                    ss.Initialize();
                    SwarmResult sr = ss.DoPSO();
                    return sr;
                }, i);
            }
            List<SwarmResult> resultList = new List<SwarmResult>();

            Task finalTask = Task.Factory.ContinueWhenAll(arrTask, (tks) =>
             {
                 Console.WriteLine(tks.Length.ToString() + " tasks");
                 for (int i = 0; i < tks.Length; i++)
                     resultList.Add(tks[i].Result);
             });
            finalTask.Wait();
            resultList.Sort();
            dataGridView1.DataSource = resultList;
            dataGridView1.Refresh();
            lblResult.Text = resultList[0].ToString();
        }
    }
}
