using GICTOFNC.Model;
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

            Grammar g = new Grammar();
            g.setAlphabet(txtTerms.Text, textVars.Text);
            g.setProductions(txtGrammar.Text);
            newGrammar.Text = g.ToString();
        }

        private void txtGrammar_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }
}
