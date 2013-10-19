using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangleLive
{
    public abstract class Monster
    {
        public int Size { get; set; }
        protected static int LifeMax;
        protected static int EnergyMax;
        protected static int MoveSpeed;
        protected static int GetOlder;
        protected static int Perception;
        protected static float ImigrationProbability;
        protected static float BornProbabillity;
        protected static int MaxPopulation;

        protected int Life;
        protected int Energy;

        public TurnAction status;
        
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

        public bool IsNear(Monster monster)
        {
            if (Math.Abs(this.Pos.X - monster.Pos.X) == 1)
                return true;
            if (Math.Abs(this.Pos.X - monster.Pos.X) == 1)
                return true;
            return false;
        }
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
