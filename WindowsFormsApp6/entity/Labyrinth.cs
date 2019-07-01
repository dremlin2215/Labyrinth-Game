using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    class Labyrinth
    {
        private CellType[,] _labirinth { get; set; }
        public int level { get; set; }
        public Point Finish { get; set; }

        Random random = new Random();

        public Labyrinth(int Level)
        {
            this.level = Level;
            _labirinth = new CellType[level * 2 - 1, level * 2 - 1];
            InitializeLabirinth(level);
            GenerateWays(level);
            GenerateFinish(level);
        }
        public Point GetFinish() {
            return Finish;
        }

        public CellType[,] GeneratedLabirint()
        {
            return _labirinth;
        }

        private void InitializeLabirinth(int Level) // Generate net of walls
        {
            for (int x = 0; x < Level * 2 - 1; x++)
            {
                for (int y = 0; y < Level * 2 - 1; y++)
                {
                    if (x % 2 == 0 && y % 2 == 0)
                    {
                        _labirinth[x, y] = CellType.voidCell;
                    }
                    else
                    {
                        _labirinth[x, y] = CellType.wall;
                    }
                }
            }
        }

        private void GenerateWays(int Level) // почему стэк - возврат пути
        {
            int Lenght = Level * 2 - 1;
            Stack<Point> cells = new Stack<Point>();
            _labirinth[0, 0] = CellType.visitedCell;
            cells.Push(new Point(0, 0));
            while (cells.Count > 0)
            {
                Point currentCell = cells.Peek();
                Point nextCell = NextRandomCell(currentCell, Lenght);
                if (nextCell != null)
                {
                    cells.Push(nextCell);
                    _labirinth[nextCell.X, nextCell.Y] = CellType.visitedCell;
                    _labirinth[(nextCell.X - currentCell.X) / 2 + currentCell.X, (nextCell.Y - currentCell.Y) / 2 + currentCell.Y] = CellType.visitedCell;
                }
                else
                {
                    cells.Pop();
                }
            }
        }

        void GenerateFinish(int Level)
        {
            int lenght = Level * 2 - 1;

            int x, y;

            do
            {
                x = 1 + random.Next(lenght-1);
                y = 1 + random.Next(lenght-1);

                Finish = new Point(x, y);
               
            } while (_labirinth[x, y] == CellType.wall);

        }

        private Point NextRandomCell(Point cell, int lenght)
        {
            List<Point> points = new List<Point>();
            if (cell.X > 1 && _labirinth[cell.X - 2, cell.Y] == CellType.voidCell)
            {
                points.Add(new Point(cell.X - 2, cell.Y));
            }
            if (cell.X < lenght - 1 && _labirinth[cell.X + 2, cell.Y] == CellType.voidCell)
            {
                points.Add(new Point(cell.X + 2, cell.Y));
            }
            if (cell.Y > 1 && _labirinth[cell.X, cell.Y - 2] == CellType.voidCell)
            {
                points.Add(new Point(cell.X, cell.Y - 2));
            }
            if (cell.Y < lenght - 1 && _labirinth[cell.X, cell.Y + 2] == CellType.voidCell)
            {
                points.Add(new Point(cell.X, cell.Y + 2));
            }
            if (points.Count != 0)
            {
                return points[random.Next(points.Count)];
            }
            else
            {
                return null;
            }
        }
    }
}
