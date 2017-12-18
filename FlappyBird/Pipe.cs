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

        // Constructor:
        public Pipe(int h, int w, int x, int y)
        {
            this.height = h;
            this.width = w;
            this.posX = x;
            this.posY = y;
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

        // Custom Methods:
        public void HitsPlayer(Bird that)
        {

        }
    }
}
