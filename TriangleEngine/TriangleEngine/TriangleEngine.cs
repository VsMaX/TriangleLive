using System;
using System.Collections.Generic;

namespace TriangleLive
{
    public delegate void MonsterEatenEventHandler(object sender, Monster monster);
    public delegate void MonsterBornEventHandler(object sender, Monster monster);
    public class TriangleEngine
    {
        public List<Monster> Monsters;
        public const int BoardSize = 10;
        public event MonsterEatenEventHandler MonsterEaten;
        public event MonsterBornEventHandler MonsterBorn;
        public TriangleEngine()
        {
            Monsters = new List<Monster>();
        }

        public void Turn()
        {
            MoveAndActOnAll();
        }

        private void GrowCarrot()
        {
            throw new NotImplementedException();
        }

        private void CheckActions(Monster currentMonster)
        {
            
        }

        private void MoveAndActOnAll()
        {
            List<Monster> toRemove = new List<Monster>();
            foreach(Monster currentMonster in Monsters)
            {
                if (toRemove.Contains(currentMonster))
                    continue;
                if (currentMonster.status == TurnAction.Rest)
                    return;
                Direction direction = currentMonster.Move();
                Position newPosition = new Position(direction, currentMonster.Pos);
                if (CanMove(newPosition))
                {
                    currentMonster.Pos = newPosition;
                    foreach (Monster monster in Monsters)
                    {
                        if (monster == currentMonster)
                            continue;
                        if (currentMonster.IsNear(monster))
                        {
                            if (currentMonster.Eats(monster))
                            {
                                toRemove.Add(monster);
                            }
                            if (currentMonster.GetType() == monster.GetType())
                                Breed(currentMonster, monster);
                        }
                    } 
                }
            }
            foreach(Monster monsterToRemove in toRemove)
            {
                Monsters.Remove(monsterToRemove);
            }
        }

        private void Breed(Monster currentMonster, Monster monster)
        {
            Monster m = (Monster)Activator.CreateInstance(monster.GetType());
            var possibleMoves = PossibleMoves(monster);
            possibleMoves.AddRange(PossibleMoves(currentMonster));
            Random r = new Random();
            int randomBreedField = r.Next(0, possibleMoves.Count);
            Position newBreedPos = possibleMoves[randomBreedField];
            m.Pos.X = newBreedPos.X;
            m.Pos.Y = newBreedPos.Y;
            Monsters.Add(m);
        }

        private List<Position> PossibleMoves(Monster monster)
        {
            List<Position> possibleMoves = new List<Position>();
            for(int i = 0; i < 4; i++)
            {
                Direction d = (Direction) i;
                Position pos = new Position(d, monster.Pos);
                if (CanMove(pos))
                    possibleMoves.Add(pos);
            }
            return possibleMoves;
        }

        private bool CanMove(Position position)
        {
            foreach (var m in Monsters)
            {
                if (m.Pos == position)
                    return false;
            }
            return true;
        }

        public bool PutMonsterOnBoard(Monster monster)
        {
            foreach (Monster m in Monsters)
            {
                if (monster.Pos == m.Pos)
                    return false;
            }
            Monsters.Add(monster);
            return true;
        }

        public void StartGame()
        {

        }

        public void StopGame()
        {

        }
    }
}