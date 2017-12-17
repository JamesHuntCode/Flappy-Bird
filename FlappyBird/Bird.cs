using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    class Bird
    {
        // Properties 
        int size;
        double posX;
        double posY;

        // Mechanics behind bird flight
        double vel = 0;
        double gravity = 2;
        double upthrust = -25;

        // Constructor:
        public Bird(int s, int x, int y)
        {
            this.size = s;
            this.posX = x;
            this.posY = y;
        }

        // Setter Methods:
        public void SetS(int s)
        {
            this.size = s;
        }

        public void SetX(int x)
        {
            this.posX = x;
        }

        public void SetY(int y)
        {
            this.posY = y;
        }

        // Getter Methods:
        public int GetSize()
        {
            return this.size;
        }

        public double GetX()
        {
            return this.posX;
        }

        public double GetY()
        {
            return this.posY;
        }

        // Custom Methods:
        public void Fly(int height)
        {
            this.vel += this.gravity;
            this.vel *= 0.9;
            this.posY += this.vel;

            if (this.posY > height)
            {
                this.posY = height;
                this.vel = 0;
            }
        }

        public void Jump()
        {
            this.vel += this.upthrust;
        }
    }
}
