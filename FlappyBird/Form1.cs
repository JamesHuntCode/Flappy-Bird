using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        #region classes and objects used

        private Bird playerIcon;
        private List<Pipe> pipes = new List<Pipe>();
        private double scoreCount = 0;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Flappy Bird - James Hunt";

            this.Height = 640;
            this.Width = 600;

            this.picFlappyBird.Height = 600;
            this.picFlappyBird.Width = 600;
            this.picFlappyBird.Location = new Point(0, 0);

            this.lblScoreCount.BackColor = ColorTranslator.FromHtml("#333");
            this.lblScoreCount.Text = scoreCount.ToString();

            this.KeyDown += this.Form1_KeyDown;
        }

        #endregion

        #region initiate game and start timer

        private void Form1_Load(object sender, EventArgs e)
        {
            this.initGame();
        }

        private void initGame()
        {
            // Add pipes   
            Random rnd = new Random();
           
            int xOffset = 0;

            for (int i = 0; i < 200; i++) 
            {
                int pipeHeight = rnd.Next(0, this.picFlappyBird.Height);

                // Check player can fit through gap
                while ((pipeHeight + 100 > this.picFlappyBird.Height) || (pipeHeight - 100 < 0))
                {
                    pipeHeight = rnd.Next(0, this.picFlappyBird.Height);
                }
                // Pipe from top
                this.addPipe(xOffset, pipeHeight, true);

                // Pipe from bottom
                this.addPipe(xOffset, pipeHeight + 100, false);
                
                // horizontal space between pipes
                xOffset += 200;
            }

            // Add bird 
            this.playerIcon = new Bird(20, (this.picFlappyBird.Width / 2), (this.picFlappyBird.Height / 2));

            // Refresh game
            Timer refresh = new Timer();
            refresh.Interval = 20;
            refresh.Tick += new EventHandler(this.refreshGame);
            refresh.Start();
        }

        private void addPipe(int offsetVal, int randomHeight, bool fromTop)
        {
            if (fromTop)
            {
                this.pipes.Add(new Pipe(randomHeight, 50, (this.picFlappyBird.Width) + offsetVal, 0, true, true));
            }
            else
            {
                this.pipes.Add(new Pipe(randomHeight, 50, this.picFlappyBird.Width + offsetVal, randomHeight, false, true));
            }
        }

        private void refreshGame(object sender, EventArgs e)
        {
            this.draw();
        }
        
        #endregion

        #region draw method (play game)

        private void draw()
        {
            // Create canvas
            Graphics FlappyBird = this.picFlappyBird.CreateGraphics();
            FlappyBird.Clear(ColorTranslator.FromHtml("#333"));

            // Draw pipes
            SolidBrush pipeBrush = new SolidBrush(Color.Green);

            for (int i = 0; i < this.pipes.Count; i++)
            {
                if (this.pipes[i].GetStatus())
                {
                    FlappyBird.FillRectangle(pipeBrush, pipes[i].GetX(), 0, pipes[i].GetW(), pipes[i].GetH());
                }
                else
                {
                    FlappyBird.FillRectangle(pipeBrush, pipes[i].GetX(), pipes[i].GetH(), pipes[i].GetW(), this.picFlappyBird.Height - pipes[i].GetH());
                }

                // Move pipe accross screen
                this.pipes[i].Move();

                // Check if pipe has hit player
                if (this.pipes[i].HitsPlayer(this.playerIcon))
                {
                    Application.Restart();
                    Environment.Exit(0);
                }

                // Pipe is off the screen
                if (this.pipes[i].GetX() + this.pipes[i].GetW() < 0)
                {
                    this.pipes.Remove(this.pipes[i]);
                }

                // Update score
                if (this.pipes[i].GetX() < this.picFlappyBird.Width / 2 && this.pipes[i].GetActive())
                {
                    this.scoreCount += 0.5;
                    this.pipes[i].SetActive(false);
                }

                this.lblScoreCount.Text = this.scoreCount.ToString();
            }

            // Draw player icon
            SolidBrush playerBrush = new SolidBrush(Color.White);
            FlappyBird.FillEllipse(playerBrush, Convert.ToInt32(this.playerIcon.GetX()), Convert.ToInt32(this.playerIcon.GetY()), this.playerIcon.GetSize(), this.playerIcon.GetSize());

            this.playerIcon.Fly(this.picFlappyBird.Height - this.playerIcon.GetSize());
        }

        #endregion

        #region manage player movement

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                this.playerIcon.Jump();
            }
        }

        #endregion
    }
}
