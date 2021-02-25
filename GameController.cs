using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FinalExam.Entities;

namespace FinalExam
{
    public static class GameController
    {
        public static Mario mario = null;
        public static int number_enemies = 0;
        public static void StartGame()
        {
            mario = new Mario(0, 9);
            number_enemies = Maze.LoadMapData();
        }  

        public static void GameOver() 
        {
            GameOverForm form = new GameOverForm();
            form.Show();
        }
        public static void GameWinner()
        {
            if (number_enemies <= 0) {
                WinnerForm form = new WinnerForm();
                form.Show();
            }          
        }
        
        public static void Draw(Graphics g) {
            foreach (Entity entity in Maze.EntityData) {
                if (entity != null) {
                  entity.Draw(g);  
                } 
            }
            mario.Draw(g);
        }
    }
}
