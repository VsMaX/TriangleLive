using System;
using System.Collections.Generic;

namespace TriangleLive
{
    public delegate void MonsterEatenEventHandler(object sender, Monster monster);
    public delegate void MonsterBornEventHandler(object sender, Monster monster);
    public class TriangleEngine
    {
        public List<Monster> Monsters;
        
        public event MonsterEatenEventHandler MonsterEaten;
        public event MonsterBornEventHandler MonsterBorn;
        public TriangleEngine()
        {
            Monsters = new List<Monster>();
        }

        public void Turn()
        {
            MoveAndActOnAll();
            KillAll();
        }

        private void KillAll()
        {
            Monsters.RemoveAll(x => x.Life < 0);
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
            foreach(var monster in Monsters)
            {
                //switch(monster.status)
                //{
                    //case TurnAction.Move:
                        monster.Move();
                        //var child = monster.Move();
                        //if (child != null)
                        //    Monsters.Add(child);
                    //    break;
                    //case TurnAction.Rest:

                    //    break;
                    //default:
                    //    break;
                //}
            }
            //List<Monster> toRemove = new List<Monster>();
            //foreach(Monster currentMonster in Monsters)
            //{
            //    if (toRemove.Contains(currentMonster))
            //        continue;
            //    if (currentMonster.status == TurnAction.Rest)
            //        return;
            //    Direction direction = currentMonster.Move();
            //    Position newPosition = new Position(direction, currentMonster.Pos);
            //    if (CanMove(newPosition))
            //    {
            //        currentMonster.Pos = newPosition;
            //        foreach (Monster monster in Monsters)
            //        {
            //            if (monster == currentMonster)
            //                continue;
            //            if (currentMonster.IsNear(monster))
            //            {
            //                if (currentMonster.Eats(monster))
            //                {
            //                    toRemove.Add(monster);
            //                }
            //                if (currentMonster.GetType() == monster.GetType())
            //                    Breed(currentMonster, monster);
            //            }
            //        }
            //    }
            //}
            //foreach(Monster monsterToRemove in toRemove)
            //{
            //    Monsters.Remove(monsterToRemove);
            //}
        }

        public List<Monster> GetNeighbours(Monster monster)
        {
            return Monsters.FindAll(x => monster.IsNear(x));
        }

        public bool PutMonsterOnBoard(Monster monster)
        {
            //foreach (Monster m in Monsters)
            //{
            //    if (monster.Pos == m.Pos)
            //        return false;
            //}
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