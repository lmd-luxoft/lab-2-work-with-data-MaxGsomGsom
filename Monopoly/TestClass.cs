// Copyright 2021 Russian Post
// This source code is Russian Post Confidential Proprietary.
// This software is protected by copyright. All rights and titles are reserved.
// You shall not use, copy, distribute, modify, decompile, disassemble or reverse engineer the software.
// Otherwise this violation would be treated by law and would be subject to legal prosecution.
// Legal use of the software provides receipt of a license from the right holder only.

// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Linq;
using NUnit.Framework;

#nullable enable
namespace Monopoly
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void GetPlayersListReturnCorrectList()
        {
            string[] players = new string[]{ "Peter","Ekaterina","Alexander" };
            GamePlayer[] expectedPlayers = new GamePlayer[]
            {
                new GamePlayer("Peter",6000, 1),
                new GamePlayer("Ekaterina",6000, 2),
                new GamePlayer("Alexander",6000, 3)
            };
            Monopoly monopoly = new Monopoly(players);
            GamePlayer[] actualPlayers = monopoly.GetPlayersList().ToArray();

            Assert.AreEqual(expectedPlayers, actualPlayers);
        }
        [Test]
        public void GetFieldsListReturnCorrectList()
        {
            GameField[] expectedCompanies = 
                new GameField[]{
                new GameField("Ford",FieldType.AUTO),
                new GameField("MCDonald", FieldType.FOOD),
                new GameField("Lamoda", FieldType.CLOTHER),
                new GameField("Air Baltic",FieldType.TRAVEL),
                new GameField("Nordavia",FieldType.TRAVEL),
                new GameField("Prison",FieldType.PRISON),
                new GameField("MCDonald",FieldType.FOOD),
                new GameField("TESLA",FieldType.AUTO)
            };
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            GameField[] actualCompanies = monopoly.GetFieldsList().ToArray();
            Assert.AreEqual(expectedCompanies, actualCompanies);
        }
        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            var x = monopoly.GetFieldByName("Ford");
            Assert.NotNull(x);
            monopoly.Buy(1, x!);
            var actualPlayer = monopoly.GetPlayerInfo(1);
            var expectedPlayer = new GamePlayer("Peter", 5500, 1);
            Assert.AreEqual(expectedPlayer, actualPlayer);
            var actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual(1, actualField?.PlayerId);
        }
        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(players);
            var  x = monopoly.GetFieldByName("Ford");
            Assert.NotNull(x);
            monopoly.Buy(1, x!);
            x = monopoly.GetFieldByName("Ford");
            Assert.NotNull(x);
            monopoly.Renta(2, x!);
            var player1 = monopoly.GetPlayerInfo(1);
            Assert.AreEqual(5750, player1?.Money);
            var player2 = monopoly.GetPlayerInfo(2);
            Assert.AreEqual(5750, player2?.Money);
        }
    }
}
