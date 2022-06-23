using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Examen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            l_DocumentState.Text = " ";
            l_NotepadState.Text=" ";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Кочнев Георгий\nГруппа: ПР-20.102К");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            OpenFile.Title = "Open an Image File";
            if (OpenFile.ShowDialog() != DialogResult.Cancel)
            {
                GlobVal.path = OpenFile.FileName;
                l_NotepadState.Text = "Opening";
                string[] RF = File.ReadAllLines(OpenFile.FileName);
                richTextBox1.AppendText($"{RF[0]}");
                for (int i = 1; i < RF.Length; i++)
                {    
                    richTextBox1.AppendText($"\n{RF[i]}");
                }
            }
            l_DocumentState.Text = "Saved";
            l_NotepadState.Text = "Ready";
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l_NotepadState.Text = "Saving";
            using (StreamWriter f = new StreamWriter(GlobVal.path))
            {
                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    f.WriteLine(richTextBox1.Lines[i]);
                }
            }
            l_DocumentState.Text = "Saved";
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveToolStripMenuItem_Click(sender, e);
            }
            catch (System.ArgumentNullException) {}
            Form1 form1 = new Form1();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            exitToolStripMenuItem_Click(sender, e);
        }
    }
    public class GlobVal
    {
        static public string path;
    }
}