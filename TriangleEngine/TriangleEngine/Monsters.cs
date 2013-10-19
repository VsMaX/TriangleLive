using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleEngine;

namespace TriangleEngine
{
    public abstract class Monster
    {
        public int Size { get; set; }
        public Position Pos { get; set; }

        public Monster()
        {
            Size = 0;
        }

        public Direction Move()
        {
            Random r = new Random();
            int moveTo = r.Next(0, 3);
            return (Direction)moveTo;
        }

        

        public int Grow()
        {
            return ++this.Size;
        }

        public abstract bool Eats(Monster monster);
    }

    public class Carrot : Monster
    {
        public override bool Eats(Monster monster)
        {
            if(monster is Bear)
                return true;
            return false;
        }
    }

    public class Wolf : Monster
    {
        public override bool Eats(Monster monster)
        {
            if (monster is Rabbit)
                return true;
            return false;
        }
    }

    public class Bear : Monster
    {
        public override bool Eats(Monster monster)
        {
            if (monster is Wolf)
                return true;
            return false;
        }
    }

    public class Rabbit : Monster
    {
        public override bool Eats(Monster monster)
        {
            if (monster is Carrot)
                return true;
            return false;
        }
    }
}
