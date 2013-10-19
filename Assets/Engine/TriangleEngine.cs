/*
using System;
using TriangleEngine;

namespace Application
{

    public class TriangleEngine
    {
        public Monster[,] Board;
        public const int BoardSize = 10;
        public TriangleEngine()
        {
            Board = new Monster[BoardSize, BoardSize];

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
            for (int i = 0; i < BoardSize; i++)
            {
                for(int j = 0; j < BoardSize; j++)
                {
                    Monster monster = Board[i, j];
                    if(monster != null)
                    {
                        Direction d = monster.Move();
                        switch(d)
                        {
                            case Direction.Up:
                                Monster monsterAbove = Board[i, j + 1];
                                if(monster.Eats(monsterAbove))
                                    
                                break;
                            case Direction.Right:
                                break;
                            case Direction.Down:
                                break;
                            case Direction.Left:
                                break;

                        }
                    }
                }
            }
        }

        private Monster LeftMonster(int x, int y)
        {
            
        }

        public void PutMonsterOnBoard(Monster monster, int x, int y)
        {
            if (x < 0 || x > 9 || y < 0 || y > 10)
                throw new Exception("Board indexes out of range");

            Board[x, y] = monster;

        }

        public void StartGame()
        {

        }

        public void StopGame()
        {

        }
    }    
}

 */