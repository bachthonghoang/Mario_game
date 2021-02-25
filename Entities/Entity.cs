using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FinalExam.Entities
{
    public abstract class Entity
    {
        protected int row;
        protected int column;

        protected Entity(int row, int colum) {
            this.row = row;
            this.column = colum;
        }
        protected Entity()
        {
            
        }
        public abstract void Draw(Graphics g);
    }
}
