using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbFSource.AppendText("adc:=[000101110]" + "\r\n");
            int n = tbFSource.Lines.Length;
        }

        private void btnFStart_Click(object sender, EventArgs e)
        {
            tbFMessage.Clear();
            uSyntAnalyzer Synt = new uSyntAnalyzer();
            Synt.Lex.strPSource = tbFSource.Lines;
            Synt.Lex.strPMessage = tbFMessage.Lines;
            Synt.Lex.enumPState = TState.Start;
            try
            {
                Synt.Lex.NextToken();
                Synt.S();
                throw new Exception("Текст верный");
            }
            catch (Exception exc)
            {
                tbFMessage.Text += exc.Message;
                tbFSource.Select();
                tbFSource.SelectionStart = 0;
                int n = 0;
                for (int i = 0; i < Synt.Lex.intPSourceRowSelection; i++) n += tbFSource.Lines[i].Length + 2;
                n += Synt.Lex.intPSourceColSelection;
                tbFSource.SelectionLength = n;


            }
        }

     

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

