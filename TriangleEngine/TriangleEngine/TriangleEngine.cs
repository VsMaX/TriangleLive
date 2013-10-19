using System;
using System.Collections.Generic;
using TriangleEngine;

namespace Application
{

    public class TriangleEngine
    {
        public List<Monster> Actors;
        public const int BoardSize = 10;
        public TriangleEngine()
        {
            Actors = new List<Monster>();

        }

        public void Turn()
        {
            MoveAll();
            CheckConflicts();
            GrowCarrot();
            MatchPairs();
            ActOnAll();
        }

        private void ActOnAll()
        {
            throw new NotImplementedException();
        }

        private void MatchPairs()
        {
            throw new NotImplementedException();
        }

        private void GrowCarrot()
        {
            throw new NotImplementedException();
        }

        private void CheckConflicts()
        {
            throw new NotImplementedException();
        }

        private void MoveAll()
        {
            
            //foreach( Monster monster in Actors)
            //{
            //            Direction d = monster.Move();
            //            Position pos= monster.Pos;            
            //            switch(d)
            //            {

            //                case Direction.Up:
                                
            //                    if (monster.Eats(monsterAbove))
            //                    {
            //                        //remove monster above
            //                    }
                                    
            //                    break;
            //                case Direction.Right:
            //                    break;
            //                case Direction.Down:
            //                    break;
            //                case Direction.Left:
            //                    break;

            //            }
            //        }
        }

        private Monster LeftMonster(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void PutMonsterOnBoard(Monster monster, int x, int y)
        {
            if (x < 0 || x > 9 || y < 0 || y > 10)
                throw new Exception("Board indexes out of range");

          //  Board[x, y] = monster;

        }

        public void StartGame()
        {

        }

        public void StopGame()
        {

        }
    }    
}

