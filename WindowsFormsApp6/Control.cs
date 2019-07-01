using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    class Control
    {
        public static int HERO_LEVEL = 25;
        static Hero _hero;
        static Labyrinth _labyrinth;

        static internal void InitializeControl()
        {
            _hero = new Hero(HERO_LEVEL); 
            _labyrinth = new Labyrinth(_hero.Level);
            Draw.RedrawMainImage();
            Draw.DrawBackgroundImage(_labyrinth, _hero.Level);
            Draw.ReDrawHero(_hero.HeroPositionX, _hero.HeroPositionY, _hero.HeroPositionX, _hero.HeroPositionY, _hero.Level);

        }

        static internal void DoMove(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    {
                        if (_hero.HeroPositionY > 0 && _labyrinth.GeneratedLabirint()[_hero.HeroPositionX, _hero.HeroPositionY - 1] != CellType.wall)
                        {
                            Draw.ReDrawHero(_hero.HeroPositionX, _hero.HeroPositionY, _hero.HeroPositionX, --_hero.HeroPositionY, _hero.Level);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (_hero.HeroPositionY < _hero.Level * 2 - 2 &&
                            _labyrinth.GeneratedLabirint()[_hero.HeroPositionX, _hero.HeroPositionY + 1] != CellType.wall)
                        {
                            Draw.ReDrawHero(_hero.HeroPositionX, _hero.HeroPositionY, _hero.HeroPositionX, ++_hero.HeroPositionY, _hero.Level);
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (_hero.HeroPositionX < _hero.Level * 2 - 2 &&
                            _labyrinth.GeneratedLabirint()[_hero.HeroPositionX + 1, _hero.HeroPositionY] != CellType.wall)
                        {
                            Draw.ReDrawHero(_hero.HeroPositionX, _hero.HeroPositionY, ++_hero.HeroPositionX, _hero.HeroPositionY, _hero.Level);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (_hero.HeroPositionX > 0 &&
                            _labyrinth.GeneratedLabirint()[_hero.HeroPositionX - 1, _hero.HeroPositionY] != CellType.wall)
                        {
                            Draw.ReDrawHero(_hero.HeroPositionX, _hero.HeroPositionY, --_hero.HeroPositionX, _hero.HeroPositionY, _hero.Level);
                        }
                        break;
                    }
            }

            if ((_hero.HeroPositionX == _labyrinth.GetFinish().X) & (_hero.HeroPositionY == _labyrinth.GetFinish().Y))
            { 
                MessageBox.Show("Поздравляю, Вы победили. \n Наджмите \"ОК\" чтобы начать следующий уровень" , "Победа");

                HERO_LEVEL++;
                InitializeControl();
            }

        }
    }
}
