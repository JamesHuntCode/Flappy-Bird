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
        //private List<Pipe> pipes = new List<Pipe>();

        public Form1()
        {
            InitializeComponent();

            this.Text = "Flappy Bird - James Hunt";

            this.Height = 640; // 640
            this.Width = 600;

            this.picFlappyBird.Height = 600;
            this.picFlappyBird.Width = 600;
            this.picFlappyBird.Location = new Point(0, 0);

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


            // Add bird 
            this.playerIcon = new Bird(20, (this.picFlappyBird.Width / 2), (this.picFlappyBird.Height / 2));

            // Refresh game
            Timer refresh = new Timer();
            refresh.Interval = 20;
            refresh.Tick += new EventHandler(this.refreshGame);
            refresh.Start();
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
