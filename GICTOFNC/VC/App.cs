using Chomskiador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GICTOFNC
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {

        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            Console.WriteLine("==Forma Normal de Chomsky==");

            Grammar gr = Utils.LoadFile(txtGrammar.Text);

            Console.WriteLine("\nG:");
            Console.WriteLine(gr.ToString());

            gr.Start();

            Console.WriteLine("\nSTART G:");
            Console.WriteLine(gr.ToString());

            gr.Term1();

            Console.WriteLine("\nTERM1 G:");
            Console.WriteLine(gr.ToString());

            gr.Term2();

            Console.WriteLine("\nTERM2 G:");
            Console.WriteLine(gr.ToString());

            gr.Bin();

            Console.WriteLine("\nBIN G:");
            Console.WriteLine(gr.ToString());

            gr.Del();

            Console.WriteLine("\nDEL G:");
            Console.WriteLine(gr.ToString());

            gr.Unit();

            Console.WriteLine("\nUNIT G:");
            Console.WriteLine(gr.ToString());

            Console.ReadLine();

            txtGrammar.Text = gr.ToString();
        }
    }
}
