using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _66840_Mehmet_Said_Unlu_T5
{
    public partial class Form2 : Form
    {
        private bool isGameStarted = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateTimeLabel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isGameStarted)
            {
                int min = Game.MinNumber;
                int max = Game.MaxNumber;

                Random rnd = new Random();
                Game.GoalNumber = rnd.Next(min, max + 1);

                StartGame();
            }
            else
            {
                ProcessGuess();
            }
        }

        private void StartGame()
        {
            isGameStarted = true;
            button1.Text = "Guess!";
            timer1.Start();
        }

        private void ProcessGuess()
        {
            int guess;

            if (int.TryParse(textBox1.Text, out guess))
            {
                if (guess > Game.GoalNumber)
                {
                    label2.Text = ("Guess lower!");
                }
                else if (guess < Game.GoalNumber)
                {
                    label2.Text = ("Guess higher!");
                }
                else
                {
                    MessageBox.Show("Congratulations! You won!");
                    timer1.Stop();
                }
            }
            else
            {
                label2.Text = ("Please enter a valid number!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Game.TimeLimit--;
            UpdateTimeLabel();

            if (Game.TimeLimit <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Time's up! You lost.");
            }
        }

        private void UpdateTimeLabel()
        {
            label3.Text = $"Time Left: {Game.TimeLimit} seconds";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }
    }
}