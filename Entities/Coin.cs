using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FinalExam.Entities
{

    public class Coin : Entity
    {
        static Image image = Image.FromFile("../../Resources/Coin.png");
    
        public Coin(int row, int colum) : base(row, colum)
        {
            
        }

        public override void Draw(Graphics g)
        {
            int size = Maze.cellSize/2;
            Rectangle bounds = new Rectangle(this.column * size * 2 + (size /2), this.row * size * 2 + (size / 2), size, size);
            g.DrawImage(image, bounds);
        }
    }
}
