using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _66840_Mehmet_Said_Unlu_T5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            int min = int.Parse(textBox1.Text);
            int max = int.Parse(textBox2.Text);
            string item = comboBox1.SelectedItem.ToString();

            switch (item)
            {
                case "Easy":
                    Game.TimeLimit = 90;
                    break;
                case "Medium":
                    Game.TimeLimit = 60;
                    break;
                case "Hard":
                    Game.TimeLimit = 40;
                    break;
            }

            Game.MinNumber = min;
            Game.MaxNumber = max;

            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
