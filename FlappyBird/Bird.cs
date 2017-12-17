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
        int posX;
        int posY;

        // Mechanics behind bird flight
        int gravity = 10;
        int upthrust = 20;

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

        public int GetX()
        {
            return this.posX;
        }

        public int GetY()
        {
            return this.posY;
        }

        // Custom Methods:
        public void Fly()
        {

        }
    }
}
