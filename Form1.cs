using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappy_bird_wf_game
{
    public partial class Form1 : Form

    {
        int pipeSpeed = 8;
        int gravity = 20;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            //scoreText.Text = score.ToString();
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -200)
            {
                pipeBottom.Left = 950;
                score++;
            }

            if (pipeTop.Left < -220)
            {
                pipeTop.Left = 990;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25)
            {
                EndGame();
            }

            //if (flappyBird.Top < -25)
            //{
            //    EndGame();
            //}

            if (score > 5)
            {
                pipeSpeed = 15;
            }



        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 20;
            }

        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -20;
            }
        }

        private void EndGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game over!!!";
        }
    }
}
