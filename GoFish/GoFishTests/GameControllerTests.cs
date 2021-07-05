﻿using GoFish;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishTests
{
    [TestClass]
    public class GameControllerTests
    {
        [TestMethod]
        public void TestController()
        {
            var gameContorller = new GameController("Human",
                new List<string>() { "Player1", "Player2", "Player3" });
            Assert.AreEqual("Starting a new game with players Human, Player1, Player2, Player3", gameContorller.Status);
        }

        [TestMethod]
        public void TestNextRound()
        {
            var gameController = new GameController("Owen", new List<string>() { "Brittney" });

            gameController.NextRound(gameController.Opponents.First(), Values.Six);
            Assert.AreEqual("Owen asked Brittney for Sixes" +
                Environment.NewLine + "Brittney has 1 Six card" +
                Environment.NewLine + "Brittney asked Owen for Sevens" +
                Environment.NewLine + "Brittney drew a card" +
                Environment.NewLine + "Owen has 6 cards and 0 books" +
                Environment.NewLine + "The stock has 41 cards" +
                Environment.NewLine, gameController.Status);
        }

        [TestMethod]
        public void TestNewGame()
        {
            Player.Random = new MockRandom() { ValueToReturn = 0};
            var gameController = new GameController("Owen", new List<string>() { "Brittney" });
            gameController.NextRound(gameController.Opponents.First(), Values.Six);
            gameController.NewGame();
            Assert.AreEqual("Owen", gameController.HumanPlayer.Name);
            Assert.AreEqual("Brittney", gameController.Opponents.First().Name);
            Assert.AreEqual("Starting a new game", gameController.Status);
        }
    }
}
