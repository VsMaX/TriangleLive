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

        public Monster(Position pos)
        {
            this.Pos = pos;
        }

        public Direction Move()
        {
            Random r = new Random();
            int moveTo = r.Next(0, 3);
            return (Direction)moveTo;
        }

        public Direction Move(int val)
        {
            return (Direction)val;
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
        private static int LifeMax = 10;
        private static int EnergyMax =0;
        private static int MoveSpeed =0;
        private static int GetOlder =0;
        private static int Perception =0;
        private static float ImigrationProbability =0.05f;
        private static float BornProbabillity = 0.3f;
        private static int MaxPopulation= 10;


        public Carrot(int x, int y):base(new Position(x,y))
       {
        } 
        public override bool Eats(Monster monster)
        {
            if(monster is Bear)
                return true;
            return false;
        }
    }

    public class Wolf : Monster
    {
        private static int LifeMax = 50;
        private static int EnergyMax = 10;
        private static int MoveSpeed = 2;
        private static int GetOlder = 1;
        private static int Perception = 15;
        private static float ImigrationProbability = 0.05f;
        private static float BornProbabillity = 0.2f;
        private static int MaxPopulation = 30;

          public Wolf(int x, int y): base(new Position(x,y))
        {
          
        } 
        public override bool Eats(Monster monster)
        {
            if (monster is Rabbit)
                return true;
            return false;
        }
    }

    public class Bear : Monster
    {
        private static int LifeMax = 100;
        private static int EnergyMax = 30;
        private static int MoveSpeed = 1;
        private static int GetOlder = 1;
        private static int Perception =20;
        private static float ImigrationProbability = 0.01f;
        private static float BornProbabillity = 0.1f;
        private static int MaxPopulation = 20;

          public Bear(int x, int y):
           base(new Position(x,y)){} 
        public override bool Eats(Monster monster)
        {
            if (monster is Wolf)
                return true;
            return false;
        }
    }

    public class Rabbit : Monster
    {
        private static int LifeMax = 20;
        private static int EnergyMax = 10;
        private static int MoveSpeed =  0;
        private static int GetOlder = 0;
        private static int Perception = 0;
        private static float ImigrationProbability = 0.05f;
        private static float BornProbabillity = 0.3f;
        private static int MaxPopulation = 10;

          public Rabbit(int x, int y):
           base(new Position(x,y)){
        } 
        public override bool Eats(Monster monster)
        {
            if (monster is Carrot)
                return true;
            return false;
        }
    }


}
