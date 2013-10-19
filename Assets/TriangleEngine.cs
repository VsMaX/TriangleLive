using UnityEngine;
using System;

/*
namespace Applications
{

    public class TriangleEngine
    {
        public Monster[,] Board;
        public const int BoardSize = 10;
        public TriangleEngine()
        {
            Board = new Monster[BoardSize, BoardSize];

            while (true)
            {
                MoveAll();
                CheckConflicts();
                GrowCarrot();
                MatchPairs();
                ActOnAll();
            }
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
            for (int i = 0; i < BoardSizel; i++)
            {
                for(int j = 0; j < BoardSize; j++)
                {
                    if(Board[i,j] != null)
                    {
                        Monster monster = Board[i, j];
                        direction d = monster.Move();

                    }
                }
            }
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

    public abstract class Monster
    {
        public int Size;

        public Monster()
        {
            Size = 0;
        }

        public direction Move()
        {
            Random r = new Random();
            int moveTo = r.Next(0, 3);
            return (direction)moveTo;
        }

        public int Grow()
        {
            return;
        }
    }

    public enum TurnAction
    {
        Move,
        Grow
    }

    public enum direction
    {
        Top,
        Left,
        Bottom,
        Right
    }
}
*/