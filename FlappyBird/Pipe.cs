using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    class Pipe
    {
        // Properties:
        int height;
        int width;
        int posX;
        int posY;
        bool fromTop;
        int velocity = 3;

        // Constructor:
        public Pipe(int h, int w, int x, int y, bool fromT)
        {
            this.height = h;
            this.width = w;
            this.posX = x;
            this.posY = y;
            this.fromTop = fromT;
        }

        // Setter Methods:
        public void SetH(int h)
        {
            this.height = h;
        }

        public void SetW(int w)
        {
            this.width = w;
        }

        public void SetX(int x)
        {
            this.posX = x;
        }

        public void SetY(int y)
        {
            this.posY = y;
        }

        public void SetStatus(bool condition)
        {
            this.fromTop = condition;
        }

        // Getter Methods:
        public int GetH()
        {
            return this.height;
        }

        public int GetW()
        {
            return this.width;
        }

        public int GetX()
        {
            return this.posX;
        }

        public int GetY()
        {
            return this.posY;
        }

        public bool GetStatus()
        {
            return this.fromTop;
        }

        // Custom Methods:

        // Move pipe left accross the screen
        public void Move()
        {
            this.posX -= this.velocity;
        }

        // Check if player has hit a pipe
        public bool HitsPlayer(Bird that)
        {
            return !(this.posX > (that.GetX() + that.GetSize()) ||
                this.posX + this.width < that.GetX() ||
                this.posY > that.GetY() + that.GetSize() ||
                this.posY + this.height < that.GetY()); 
        }
    }
}
