using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FinalExam.Entities
{
    public class Wall : Entity
    {
       
        public Wall(int row, int colum) : base(row, colum){ }
        public override void Draw(Graphics g)
        {
            int size = Maze.cellSize / 2;
            Rectangle bounds = new Rectangle(this.column * size * 2 + (size / 2), this.row * size * 2 + (size / 2), size, size);
            Brush brush = new SolidBrush(Color.BlanchedAlmond);
            g.FillRectangle(brush, bounds);
            brush.Dispose();
        }
    }
}
