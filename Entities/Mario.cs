using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalExam.State;

namespace FinalExam.Entities
{
    public enum Direction { NONE, UP, DOWN, LEFT, RIGHT }
  
    public class Mario : Fighter
    {
        static Image image = Image.FromFile("../../Resources/MarioSmall.png");
    
        public Direction Current_Direction { get; set; }
        public int ExperiencePoints { get ; set ; }
        private IState state;

        private int lives;

        public int Lives { get => lives; }
        public IState State { get => state; set => state = value; }

        public Mario(int row, int colum) : base(50, row, colum)
        {
            //this.state = Normal_State.Get_Instance();
            this.Current_Direction = Direction.NONE;
            this.lives = 3;
        }
        public void Heal()
        {
            //TODO: 
        }
        public void Gain_Experience() {
            this.ExperiencePoints++;
            if (this.ExperiencePoints >= 3) {
                this.ExperiencePoints -= 3;
                this.lives++;
            }
        }
        public void Loose_Life() {
            this.lives --;
            if (this.lives <= 0)
            {
                GameController.GameOver();
            }
        }
       
        public void Move()
        {
            Point velocity = GetVelocity();
            int next_Row = this.row + velocity.Y;
            int next_Column = this.column + velocity.X;

            if (Maze.CheckMazeBounds(next_Row, next_Column))
            {
                Entity next_Entity = Maze.EntityData[next_Row, next_Column];
                if (this.CanPassThrough(next_Entity))
                {
                    this.row = next_Row;
                    this.column = next_Column;
                    if (this.row == 16 && this.column == 9) 
                    {
                        GameController.GameWinner();
                    }
                    if (next_Entity is Coin)
                    {
                        //this.state.GetCoin(this);
                        Maze.Remove_Entity(this.row, this.column);
                    }
                    else if (next_Entity is Weapon)
                    {
                        //this.state.GetWeapon(this);
                        Maze.Remove_Entity(this.row, this.column);
                    }
                    else if (next_Entity is Enemy)
                    {
                        //this.state.MeetEnemy(this, (Enemy) next_Entity);
                    }
                }
            }
        }

        public bool CanPassThrough(Entity entity)
        {
            return !(entity is Wall);
        }
        public override void Draw(Graphics g)
        {
            int size = Maze.cellSize;
            Rectangle bounds = new Rectangle(this.column * size, this.row * size, size, size);
            g.DrawImage(image, bounds);
        }
        public Point GetVelocity()
        {
            switch (this.Current_Direction)
            {
                case Direction.UP: return new Point(0, -1);
                case Direction.DOWN: return new Point(0, 1);
                case Direction.LEFT: return new Point(-1, 0);
                case Direction.RIGHT: return new Point(1, 0);
                default: return new Point(0, 0);
            }
        }
        public string GetDirection()
        {
            switch (this.Current_Direction)
            {
                case Direction.UP: return "UP";
                case Direction.DOWN: return "DOWN";
                case Direction.LEFT: return "LEFT";
                case Direction.RIGHT: return "RIGHT";
                default: return "NONE";
            }
        }
    }
}
