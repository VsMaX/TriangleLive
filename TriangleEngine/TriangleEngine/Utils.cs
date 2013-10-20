using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangleLive
{
    public enum TurnAction
    {
        Move,
        Rest,
    }

    public enum Direction
    {
        Up,
        Left,
        Down,
        Right
    }

    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
            if (x > 9)
                X = 9;
            if (x < 0)
                X = 0;
            if (y > 9)
                Y = 9;
            if (y < 0)
                Y = 0;
        }
        public Position(Direction d, Position oldPosition)
        {
            X = oldPosition.X;
            Y = oldPosition.Y;
            switch(d)
            {
                case Direction.Up:
                    if (oldPosition.Y < 9)
                        Y++;
                    break;
                case Direction.Right:
                    if (oldPosition.X < 9)
                        X++;
                    break;
                case Direction.Down:
                    if (oldPosition.Y > 0)
                        Y--;
                    break;
                case Direction.Left:
                    if (oldPosition.X > 0)
                        X--;
                    break;
            }
        }
        public int X { get; set; }
        public int Y { get; set; }

        public static bool operator==(Position pos1, Position pos2)
        {
            return pos1.X == pos2.X && pos1.Y == pos2.Y;
        }

        public static bool operator!=(Position pos1, Position pos2)
        {
            return !(pos1.X == pos2.X && pos1.Y == pos2.Y);
        }
    }
}
