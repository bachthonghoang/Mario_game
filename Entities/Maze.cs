using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace FinalExam.Entities
{
    public class Maze
    {
        public static Entity[,] EntityData = null;
        public static int cellSize = 40;
        public static int LoadMapData()
        {
            int enemies_count = 0;
            string[] fileLines = File.ReadAllLines("../../Resources/Maze.txt");
            int nbrRows = fileLines.Length;
            int nbrCols = fileLines[0].Length;

            //Initialize the static variables with empty Matrices
            EntityData = new Entity[nbrRows, nbrCols];

            //Parse the Text File
            int row = 0;

            foreach (string line in fileLines)
            {
                char[] chars = line.ToCharArray();
                int col = 0;

                foreach (char aChar in chars)
                {
                    switch (aChar)
                    {
                        case 'A': //Floor
                            EntityData[row, col] = new Floor(row, col);
                            Console.WriteLine("row = "+row+" , col = "+ col);
                            break;
                        case '.': //Floor
                            EntityData[row, col] = new Floor(row, col);
                            break;
                        case 'C': //Coin
                            EntityData[row, col] = new Coin(row, col);
                            break;
                        case 'E': //Enemy
                            int hp = Dice.Get_Instance().Next(20, 50);
                            EntityData[row, col] = new Enemy(hp, row, col);
                            enemies_count++;
                            break;
                        case 'W': //Weapon
                            EntityData[row, col] = new Weapon(row, col);
                            break;
                        case '#': //Wall
                            EntityData[row, col] = new Wall(row, col);
                            break;
                    }
                    col++;
                }
                row++;
            }
            return enemies_count;
        }
        public static void Remove_Entity(int row, int col) {
            Entity entity = EntityData[row, col];
            if (entity is Enemy) {
                GameController.number_enemies--;
            }
            EntityData[row, col] = new Floor(row, col);
        }
        public static bool CheckMazeBounds(int row, int col)
        {

            int max_row = EntityData.GetUpperBound(0);
            int max_col = EntityData.GetUpperBound(1);

            if (row < 0 || row > max_row)
            {
                return false;
            }
            if (col < 0 || col > max_col)
            {
                return false;
            }
            return true;

        }
    }
}
