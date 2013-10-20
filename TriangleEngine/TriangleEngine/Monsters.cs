using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangleLive
{
    public abstract class Monster
    {
        protected static int LifeMax;
        protected static int EnergyMax;
        protected static int MoveSpeed;
        protected static int GetOlder;
        protected static int Perception;
        protected static float ImigrationProbability;
        protected static float BornProbabillity;
        protected static int MaxPopulation;
        protected const float SpriteRange = 1.0f;
        public int Life;
        protected int Energy;

        public TurnAction status;
        
        public Position Pos { get; set; }
        public Position PreviousPos { get; set; }
        public Monster(Position pos)
        {
            this.Pos = pos;
        }

        public Monster Move(List<Monster> neighbours)
        {
            var movingDirection = GetMoveDirection();
            this.Pos.X += movingDirection.X;
            this.Pos.Y += movingDirection.Y;
            foreach(var neighbour in neighbours)
            {
                if(IsNear(neighbour))
                {
                    if(Eats(neighbour))
                        Eat(neighbour);
                    if (IsTheSameAs(neighbour))
                        return Breed(neighbour, this);
                }
            }
            return null;
        }
        public abstract bool Eats(Monster monster);


        public Monster Breed(Monster mother, Monster father)
        {
            Position pos = new Position(mother.Pos.X, mother.Pos.Y + SpriteRange);
            Monster monster;
            if(mother is Wolf)
            {
                monster = new Wolf(mother.Pos.X, mother.Pos.Y + SpriteRange);
            }
            if(mother is Bear)
            {
                monster = new Wolf(mother.Pos.X, mother.Pos.Y + SpriteRange);
            }
            if(mother is Rabbit)
            {
                monster = new Wolf(mother.Pos.X, mother.Pos.Y + SpriteRange);
            }
            return null;
        }
        public bool IsTheSameAs(Monster monster)
        {
            if(monster.GetType() == this.GetType())
                return true;
            return false;
        }
        public bool IsNear(Monster monster)
        {
            return Position.IsInCloseRange(monster.Pos, this.Pos);
        }

        public bool IsSeen(Monster monster)
        {
            return Position.IsInRange(monster.Pos, this.Pos, Perception);
        }

        public void Eat(Monster monster)
        {
            monster.Kill();
        }

        public void Kill()
        {
            this.Life = -1;
        }

        protected abstract bool IsRested();

        public bool IsMoving()
        {
            if (this is Carrot)
                return false;
            if (this.Energy == 0 || (this.status == TurnAction.Rest && !this.IsRested()))
            {
                this.status = TurnAction.Rest;
                return false;
            }
            this.status = TurnAction.Move;
            return true;
        }

        public Direction GetMoveDirection()
        {
            Random r = new Random(19474);
            float directionX = (float)(r.NextDouble() - 0.5f);
            float directionY = (float)(r.NextDouble() - 0.5f);
            Direction d = new Direction();
            d.X = directionX + MoveSpeed;
            d.Y = directionY + MoveSpeed;
            return d;
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


        protected override bool IsRested()
        {
            return (this.Energy < Carrot.EnergyMax) ? true : false;
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

          public Wolf(float x, float y): base(new Position(x,y))
        {
          
        } 
        public override bool Eats(Monster monster)
        {
            if (monster is Rabbit)
                return true;
            return false;
        }

        protected override bool IsRested()
        {
            return (this.Energy < Wolf.EnergyMax) ? true : false;
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

        protected override bool IsRested()
        {
            return (this.Energy < Bear.EnergyMax) ? true : false;
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

        protected override bool IsRested()
        {
            return (this.Energy < Rabbit.EnergyMax) ? true : false;
        }
    }


}
