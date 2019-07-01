using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    class Draw
    {
        public static int LAB_SIZE = 500; // Менять размер лабиринта
        static Bitmap backgroundBitmap = new Bitmap(LAB_SIZE, LAB_SIZE);
        static Bitmap mainBitmap = new Bitmap(LAB_SIZE, LAB_SIZE);
        static PictureBox _pictureBox = new PictureBox() { Width = LAB_SIZE, Height = LAB_SIZE, Location = new System.Drawing.Point(10, 10), BackgroundImage = backgroundBitmap, Image = mainBitmap };

        static internal PictureBox GetNewPictureBox()
        {
            backgroundBitmap = new Bitmap(LAB_SIZE, LAB_SIZE);
            mainBitmap = new Bitmap(LAB_SIZE, LAB_SIZE);
            _pictureBox = new PictureBox() { Width = LAB_SIZE, Height = LAB_SIZE, Location = new System.Drawing.Point(10, 10), BackgroundImage = backgroundBitmap, Image = mainBitmap };
            return _pictureBox;
        }

        static internal void ReDrawHero(int HeroOldPositionX, int HeroOldPositionY, int HeroNewositionX, int HeroNewPositionY,
            int HeroLevel)
        {
            float cellWeight = (float)LAB_SIZE / ((float)HeroLevel * 2.0f - 1.0f);

            Graphics graphics = Graphics.FromImage(mainBitmap);

            graphics.FillRectangle(Brushes.Yellow, HeroOldPositionX * cellWeight, HeroOldPositionY * cellWeight,cellWeight, cellWeight);
            graphics.FillRectangle(Brushes.Red, HeroNewositionX * cellWeight, HeroNewPositionY * cellWeight, cellWeight,
                cellWeight);
            _pictureBox.Invalidate();
        }

        internal static void DrawBackgroundImage(Labyrinth labyrinth, int Level)
        {
            Graphics g = Graphics.FromImage(backgroundBitmap);



            g.FillRectangle(Brushes.White, 0, 0, LAB_SIZE, LAB_SIZE);
            g.DrawRectangle(new Pen(Color.Red, 1.0f), 0, 0, (LAB_SIZE - 1), (LAB_SIZE - 1));
            float cellWeight = (float)LAB_SIZE / ((float)Level * 2.0f - 1.0f);
            g.FillRectangle(Brushes.Blue, cellWeight * labyrinth.Finish.X, cellWeight * labyrinth.Finish.Y, cellWeight, cellWeight);


            DrawGeneratedLabirinth(labyrinth.GeneratedLabirint(), g, Level);
        }

        private static void DrawGeneratedLabirinth(CellType[,] cells, Graphics graphics, int level)
        {
            float cellWeight = (float)LAB_SIZE / ((float)level * 2.0f - 1.0f);
            for (int x = 0; x < level * 2 - 1; x++)
            {
                for (int y = 0; y < level * 2 - 1; y++)
                {
                    if (cells[x, y] != CellType.visitedCell)
                        graphics.FillRectangle(Brushes.Black, (float)x * cellWeight, (float)y * cellWeight, cellWeight, cellWeight);
                }
            }
        }

        public static void RedrawMainImage()
        {
            Bitmap b = new Bitmap(LAB_SIZE, LAB_SIZE);
            using (Graphics g = Graphics.FromImage(b))
            {
                Brush brush = new SolidBrush(Color.FromArgb(30, 0, 80, 0));
                g.FillRectangle(brush, 0, 0, LAB_SIZE, LAB_SIZE);
                
            }
            mainBitmap = b;
            _pictureBox.Image = b;
        }
    }
}
