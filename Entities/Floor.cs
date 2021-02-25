using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Entities
{
    public class Floor: Entity
    {
        public Floor(int row, int colum) : base(row, colum)
        {

        }

        public override void Draw(Graphics g)
        {
            int size = Maze.cellSize / 2;
            Rectangle bounds = new Rectangle(this.column * size * 2 + (size / 2), this.row * size * 2 + (size / 2), size, size);
            Brush brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, bounds);
            brush.Dispose();
        }
    }
}
