// Copyright 2021 Russian Post
// This source code is Russian Post Confidential Proprietary.
// This software is protected by copyright. All rights and titles are reserved.
// You shall not use, copy, distribute, modify, decompile, disassemble or reverse engineer the software.
// Otherwise this violation would be treated by law and would be subject to legal prosecution.
// Legal use of the software provides receipt of a license from the right holder only.

// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Linq;
using NUnit.Framework;

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
                new GamePlayer("Peter",6000),
                new GamePlayer("Ekaterina",6000),
                new GamePlayer("Alexander",6000)
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
                new GameField("Ford",FieldType.AUTO,0,false),
                new GameField("MCDonald", FieldType.FOOD, 0, false),
                new GameField("Lamoda", FieldType.CLOTHER, 0, false),
                new GameField("Air Baltic",FieldType.TRAVEL,0,false),
                new GameField("Nordavia",FieldType.TRAVEL,0,false),
                new GameField("Prison",FieldType.PRISON,0,false),
                new GameField("MCDonald",FieldType.FOOD,0,false),
                new GameField("TESLA",FieldType.AUTO,0,false)
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
            GameField x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            GamePlayer actualPlayer = monopoly.GetPlayerInfo(1);
            GamePlayer expectedPlayer = new GamePlayer("Peter", 5500);
            Assert.AreEqual(expectedPlayer, actualPlayer);
            GameField actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual(1, actualField.PlayerIndex);
        }
        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            GameField  x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            x = monopoly.GetFieldByName("Ford");
            monopoly.Renta(2, x);
            GamePlayer player1 = monopoly.GetPlayerInfo(1);
            Assert.AreEqual(5750, player1.Money);
            GamePlayer player2 = monopoly.GetPlayerInfo(2);
            Assert.AreEqual(5750, player2.Money);
        }
    }
}
