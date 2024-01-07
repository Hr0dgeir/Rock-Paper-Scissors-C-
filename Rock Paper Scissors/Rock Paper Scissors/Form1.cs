using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rock_Paper_Scissors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            Score_label.Hide();
            Lap_label.Hide();
        }

        private void GameExit(object sender, KeyEventArgs e)
        {

        }

        private void Game_exit_Tick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Game_Start_Tick(object sender, EventArgs e)
        {
            label1.Hide();
            label3.Hide();
            Hello_player.Hide();
            pictureBox1.Show();
            pictureBox2.Show();
            pictureBox3.Show();
            label7.Show();
            label8.Show();
            label9.Show();
            Lap_label.Show();
            Score_label.Show() ;
        }

        private void GamePress(object sender, KeyEventArgs e)
        {
            string player;
            switch (e.KeyCode)
            {
                case Keys.Q:
                    Game_exit.Start();
                    break;
                case Keys.Enter:
                    Game_Start.Start();
                    break;
                case Keys.NumPad1:
                case Keys.D1:
                    player = "Rock";
                    player_choise = player;
                    Player_ready();
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    player = "Paper";
                    player_choise = player;
                    Player_ready();
                    break;
                case Keys.NumPad3:
                case Keys.D3:                  
                    player = "Scissors";
                    player_choise = player;
                    Player_ready();
                    break;               
            }
        }
        string Ai_choise;
        string player_choise;
        public void AI()
        {
            string ai_choise;
            Random rnd = new Random();
            int Ai = rnd.Next(1,4);
            if (Ai == 1)
            {
                ai_choise = "Rock";
                Ai_choise = ai_choise;
                label13.Text = Ai_choise;
            }
            if (Ai == 2)
            {
                ai_choise = "Paper";
                Ai_choise = ai_choise;
                label13.Text = Ai_choise;
            }
            if (Ai == 3)
            {
                ai_choise = "Scissors";
                Ai_choise = ai_choise;
                label13.Text = Ai_choise;                
            }
        }
        int lap = 0;
        int player_win = 0;
        public void Winner()
        {      
            label12.Text = player_choise;
            label13.Text = Ai_choise;
            if (label12.Text =="Rock"&& label13.Text == "Rock")
            {
                MessageBox.Show("Tie!!!");
                lap += 1;
                global_lap = lap;
                play_again();
            }
            if (label12.Text == "Rock" && label13.Text == "Paper")
            {
                MessageBox.Show("AI Win!!!");
                lap += 1;
                global_lap = lap;
                play_again();
            }
            if (label12.Text == "Rock" && label13.Text == "Scissors")
            {
                MessageBox.Show("Player Win!!!");
                lap += 1;
                player_win += 1;
                global_lap = lap;
                global_score = player_win;
                play_again();
            }
            if (label12.Text == "Paper" && label13.Text == "Paper")
            {
                MessageBox.Show("Tie!!!");
                lap += 1;
                global_lap = lap;
                play_again();
            }
            if (label12.Text == "Paper" && label13.Text == "Rock")
            {
                MessageBox.Show("Player Win!!!");
                lap += 1;
                player_win += 1;
                global_lap = lap;
                global_score = player_win;
                play_again();
            }
            if (label12.Text == "Paper" && label13.Text == "Scissors")
            {
                MessageBox.Show("AI Win!!");
                lap += 1;
                global_lap = lap;
                play_again();
            }
            if (label12.Text == "Scissors" && label13.Text == "Scissors")
            {
                MessageBox.Show("Tie!!");
                lap += 1;
                global_lap = lap;
                play_again();
            }
            if (label12.Text == "Scissors" && label13.Text == "Paper")
            {
                MessageBox.Show("Player Win!!!");
                lap += 1;
                player_win += 1;
                global_lap = lap;
                global_score = player_win;
                play_again();
            }
            if (label12.Text == "Scissors" && label13.Text == "Rock")
            {
                MessageBox.Show("AI Win!!!");
                lap += 1;
                global_lap = lap;
                play_again();
            }
        }
        int global_lap;
        int global_score;
        public void round_score()
        {
            Lap_label.Text = "Lap = " + global_lap.ToString();
            Score_label.Text = "Score = " + global_score.ToString();
        }
        public void play_again()
        {
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            pictureBox1.Show();
            pictureBox2.Show();
            pictureBox3.Show();
            label7.Show();
            label8.Show();
            label9.Show();
        }
        public void Player_ready()
        {
            AI();          
            label12.Text = player_choise;
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            Game_Start.Stop();
            label10.Show();
            label11.Show();
            label12.Show();
            label13.Show();
            Winner();
            round_score();
        }
    }
}
