using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalExam.Entities;

namespace FinalExam
{
    public partial class MainGame : Form
    {
        public MainGame()
        {
            InitializeComponent();
            GameController.StartGame();

            int max_row = Maze.EntityData.GetUpperBound(0) + 1;
            int max_col = Maze.EntityData.GetUpperBound(1) + 1;
            this.Size = new Size(max_col * Maze.cellSize, max_row* Maze.cellSize+ 70);
            this.pictureBox1.Size = new Size(max_col * Maze.cellSize, max_row * Maze.cellSize);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            GameController.Draw(e.Graphics);
            label_Lives.Text = GameController.mario.Lives.ToString();
            label_Score.Text = GameController.mario.ExperiencePoints.ToString();
            //this.label_HP.Text = GameController.mario.Hit_Points.ToString();
            //label_State.Text = GameController.mario.State.ToString();
            label_Direction.Text = GameController.mario.GetDirection();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.Up: GameController.mario.Current_Direction = Direction.UP;
                    break;
                case Keys.Down: GameController.mario.Current_Direction = Direction.DOWN;
                    break;
                case Keys.Left:
                    GameController.mario.Current_Direction = Direction.LEFT;
                    break;
                case Keys.Right:
                    GameController.mario.Current_Direction = Direction.RIGHT;
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    GameController.mario.Current_Direction = Direction.NONE;
                    break;
            }
            GameController.mario.Move();
            this.pictureBox1.Refresh();
        }

    }
}
