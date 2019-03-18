using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace dipl_01
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEval_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 20; i++)
            //{
            //    ISolution a = new Solution(i, 4);
            //    this.logBox.Text += String.Format("Sol({0})={1}\n", i, a.Print());
            //}
            this.logBox.Text += "Calculated res: " + CalculationManager.GetInstance().alg.GetProblem().Eval(
                CalculationManager.GetInstance().alg.GetProblem().GetBestSol()) + "\n";
            this.logBox.Text += "Eval count: " + CalculationManager.GetInstance().alg.GetProblem().GetEvalCount() + "\n";
            this.logBox.Text += "Factorial(" + CalculationManager.GetInstance().alg.GetProblem().GetSize() + "): "
                + MyMath.Factorial(CalculationManager.GetInstance().alg.GetProblem().GetSize()) + "\n";
        }

        private void buttonLoadProblem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    ShuffleProblem temp = JsonConvert.DeserializeObject<ShuffleProblem>(text);

                    CalculationManager.GetInstance().prb = JsonConvert.DeserializeObject<ShuffleProblem>(text);
                    //CalculationManager.GetInstance().alg = new SecondDiplomAlgorithm(4);
                    //CalculationManager.GetInstance().alg.Init(temp);

                    logBox.Text += temp.Print();
                    temp.SetBestSol(new Solution(temp.solution));
                    logBox.Text += "Calculated res: " + temp.Eval(temp.best_solution) + "\n";

                    CalculationManager.GetInstance().prb = temp;
                }
                catch (IOException)
                {
                }
            }

        }

        private void buttonCross_Click(object sender, EventArgs e)
        //{
        //    CalculationManager.GetInstance().alg = new DiplomAlgorithm();
        //    //CalculationManager.GetInstance().alg.Init(new ShuffleProblem());
        //    ISolution aa = new Solution(0, 4);
        //    List<ISolution> heap = CalculationManager.GetInstance().alg.Neibours(aa);
        //    this.logBox.Text += "All neibh to " + aa.Print() + "\n";
        //    for (int i = 0; i < heap.Count; i++)
        //    {
        //        this.logBox.Text += i + ": " + heap[i].Print() + "\n";
        //    }
        //}
        //{
        //    CalculationManager.GetInstance().alg = new DiplomAlgorithm();
        //    ISolution aa = new Solution(0, 7);
        //    ISolution ab = new Solution(5039, 7);
        //    List<ISolution> heap = CalculationManager.GetInstance().alg.BuildPath(aa,ab);
        //    this.logBox.Text += "Path from " + aa.Print() + "to " + ab.Print() + "\n";
        //    for (int i = 0; i < heap.Count; i++)
        //    {
        //        this.logBox.Text += i + ": " + heap[i].Print() + "\n";
        //    }
        //}
        {
            ISolution tmp = CalculationManager.GetInstance().alg.Cross(CalculationManager.GetInstance().pool);
            this.logBox.Text += "Answer:\n";
            this.logBox.Text += CalculationManager.GetInstance().alg.GetProblem().SolPrint(tmp) + "\n";
        }

        private void buttonInitList_Click(object sender, EventArgs e)
        {
            CalculationManager.GetInstance().pool = CalculationManager.GetInstance().alg.GenerateInitial();

            this.logBox.Text += "Init:\n";
            foreach (ISolution a in CalculationManager.GetInstance().pool)
                this.logBox.Text += CalculationManager.GetInstance().alg.GetProblem().SolPrint(a) + "\n";

        }

        private void buttonHC_Click(object sender, EventArgs e)
        {
            List<ISolution> p = CalculationManager.GetInstance().pool;
            for (int i=0; i< p.Count; i++)
            {
                ISolution t;
                do
                {
                    t = p[i];
                    p[i] = CalculationManager.GetInstance().alg.HillClimbing(p[i]);
                } while (t.GetId() != p[i].GetId());
            }

            //this.logBox.Text += "HC:\n";
            //foreach (ISolution a in CalculationManager.GetInstance().pool)
            //    this.logBox.Text += CalculationManager.GetInstance().alg.GetProblem().SolPrint(a) + "\n";
        }

        private void buttonMutate_Click(object sender, EventArgs e)
        {
            CalculationManager cm = CalculationManager.GetInstance();
            cm.pool = cm.alg.Mutate(cm.pool);

            //this.logBox.Text += "Mutation:\n";
            //foreach (ISolution a in CalculationManager.GetInstance().pool)
            //    this.logBox.Text += CalculationManager.GetInstance().alg.GetProblem().SolPrint(a) + "\n";
        }

        private void logBox_TextChanged(object sender, EventArgs e)
        {
            this.logBox.SelectionStart = this.logBox.Text.Length;
            this.logBox.ScrollToCaret();
        }

        private void buttonAutoCalculate_Click(object sender, EventArgs e)
        {
            //CalculationManager.ScrapAndCreateNew();
            if (CalculationManager.GetInstance().alg != null)
            {
                ShuffleProblem t = CalculationManager.GetInstance().alg.GetProblem() as ShuffleProblem;
                if (t != null) t.ClearMemento();
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();

            buttonInitAlg_Click(sender, e);
            buttonInitList_Click(sender, e);

            int old_core_count = CalculationManager.GetInstance().alg.GetProblem().GetEvalCount();
            do
            {
                buttonHC_Click(sender, e);
                buttonMutate_Click(sender, e);
                if (CalculationManager.GetInstance().alg.GetProblem().GetEvalCount() == old_core_count) break;
                old_core_count = CalculationManager.GetInstance().alg.GetProblem().GetEvalCount();
                CalculationManager.GetInstance().pool = CalculationManager.GetInstance().pool.Distinct().ToList();
                if (CalculationManager.GetInstance().pool.Count == 1) break;
            }
            while (true);

            watch.Stop();

            this.logBox.Text += "Eval count: " + CalculationManager.GetInstance().alg.GetProblem().GetEvalCount() + "\n";
            this.logBox.Text += "Calculated res: " + CalculationManager.GetInstance().alg.GetProblem().Eval(
                CalculationManager.GetInstance().alg.GetProblem().GetBestSol()) + "\n";
            this.logBox.Text += "Elepsed time: " + watch.ElapsedMilliseconds;

        }

        private void buttonInitAlg_Click(object sender, EventArgs e)
        {
            CalculationManager.GetInstance().alg = new OldDiplomAlgorithm(Int32.Parse(textBox1.Text));
            CalculationManager.GetInstance().alg.Init(CalculationManager.GetInstance().prb);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
