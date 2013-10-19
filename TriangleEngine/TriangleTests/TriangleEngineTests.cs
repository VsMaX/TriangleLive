using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleLive;
using System.Linq;

namespace TriangleTests
{
    [TestClass]
    public class TriangleEngineTests
    {
        [TestMethod]
        public void MoveMonsterToNextEmptyField()
        {
            TriangleEngine engine = new TriangleEngine();
            engine.PutMonsterOnBoard(new Bear(1, 1));
            engine.Turn();
            Bear b = (Bear) engine.Monsters.First();
            Assert.IsTrue(b.Pos.X == 0 || b.Pos.X == 2 || b.Pos.Y == 0 || b.Pos.Y == 2);
        }
        [TestMethod]
        public void NoMovementOpportunity()
        {
            TriangleEngine engine = new TriangleEngine();
            engine.PutMonsterOnBoard(new Bear(1, 1));
            engine.PutMonsterOnBoard(new Carrot(1, 2));
            engine.PutMonsterOnBoard(new Carrot(2, 1));
            engine.PutMonsterOnBoard(new Carrot(1, 0));
            engine.PutMonsterOnBoard(new Carrot(0, 1));

            engine.Turn();
            Bear b = (Bear)engine.Monsters.FirstOrDefault();
            Assert.IsTrue(b.Pos.X == 1 && b.Pos.Y == 1);
        }
    }
}
