using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FinalExam.Entities
{
    public class Weapon : Entity
    {
        static Image image = Image.FromFile("../../Resources/Weapon.png");

        public Weapon(int row, int colum) : base(row, colum){ }

        public override void Draw(Graphics g)
        {
            int size = Maze.cellSize;

            Rectangle bounds = new Rectangle(this.column * size, this.row * size, size, size);
            g.DrawImage(image, bounds);
        }
    }
}
