using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    class Hero
    {
        public Hero(int level)
        {
            Level = level;
            HeroPositionX = 0;
            HeroPositionY = 0;
        }
        int _level;
        internal int HeroPositionX { get; set; }
        internal int HeroPositionY { get; set; }
        internal int Level { get => _level; set => _level = value; }
    }
}
