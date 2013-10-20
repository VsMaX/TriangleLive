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

    public class Direction
    {
        public float X
        {
            get { return X; }
            set
            {
                X = value;
                this.Normalise();
            }
        }
        public float Y
        {
            get { return X; }
            set
            {
                Y = value;
                this.Normalise();
            }
        }
        private void Normalise()
        {
            float l2 = X * X + Y * Y;
            float len = (float)Math.Sqrt(l2);
            X = X / len;
            Y = Y / len;
        }
    }

    public class Position
    {
        public Position(float x, float y)
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
            X = (float) Math.Min(Math.Max(oldPosition.X + d.X, -14), 14);
            Y = (float) Math.Min(Math.Max(oldPosition.Y + d.Y, -14), 14);
        }
        public float X { get; set; }
        public float Y { get; set; }

        public static bool operator==(Position pos1, Position pos2)
        {
            return IsInRange(pos1, pos2, 0.3f);
        }
        public static bool operator!=(Position pos1, Position pos2)
        {
            return !(pos1.X == pos2.X && pos1.Y == pos2.Y);
        }
        public static float Distance(Position pos1, Position pos2)
        {
            return (float) Math.Sqrt(Math.Pow(pos1.X - pos2.X, 2) + Math.Pow(pos1.Y - pos2.Y, 2));
	    }
        public static bool IsInCloseRange(Position pos1, Position pos2)
        {
            return Distance(pos1, pos2) < 1;
        }
        public static bool IsInRange(Position pos1, Position pos2, float range)
        {
            return Distance(pos1, pos2) < range;
        }
    }
}
