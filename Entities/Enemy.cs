using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FinalExam.State;

namespace FinalExam.Entities
{
    public class Enemy :Fighter
    {
        
        public Image image = Image.FromFile("../../Resources/monster.png");

        
        public Enemy(int hp, int row, int colum) : base(hp, row, colum)
        {
            
        }

        public override void Draw(Graphics g)
        {
            int size = Maze.cellSize;
            Rectangle bounds = new Rectangle(this.column * size, this.row * size, size, size);
            g.DrawImage(image, bounds);
        }
        
        public void Attack(Mario mario)
        {
            //TODO
        }

        public void Die() {
            //TODO
        }
    }

}
