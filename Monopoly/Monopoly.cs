// Copyright 2021 Russian Post
// This source code is Russian Post Confidential Proprietary.
// This software is protected by copyright. All rights and titles are reserved.
// You shall not use, copy, distribute, modify, decompile, disassemble or reverse engineer the software.
// Otherwise this violation would be treated by law and would be subject to legal prosecution.
// Legal use of the software provides receipt of a license from the right holder only.

using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace Monopoly
{
    class Monopoly
    {
        private const int InitMoney = 6000;
        private readonly List<GamePlayer> players = new List<GamePlayer>();
        private readonly List<GameField> fields = new List<GameField>();

        public Monopoly(string[] playersNames)
        {
            for (int i = 0; i < playersNames.Length; i++)
            {
                players.Add(new GamePlayer(playersNames[i], InitMoney, i + 1));     
            }

            fields.Add(new GameField("Ford", FieldType.AUTO));
            fields.Add(new GameField("MCDonald", FieldType.FOOD));
            fields.Add(new GameField("Lamoda", FieldType.CLOTHER));
            fields.Add(new GameField("Air Baltic", FieldType.TRAVEL));
            fields.Add(new GameField("Nordavia", FieldType.TRAVEL));
            fields.Add(new GameField("Prison", FieldType.PRISON));
            fields.Add(new GameField("MCDonald", FieldType.FOOD));
            fields.Add(new GameField("TESLA", FieldType.AUTO));
        }

        internal IReadOnlyList<GamePlayer> GetPlayersList()
        {
            return players;
        }

        internal IReadOnlyCollection<GameField> GetFieldsList()
        {
            return fields;
        }

        internal GameField? GetFieldByName(string name)
        {
            return fields.FirstOrDefault(field => field.Name == name);
        }

        internal bool Buy(int playerId, GameField field)
        {
            var player = GetPlayerInfo(playerId);
            var price = field.GetPrice();
            if (player == null || field.Owned || price == 0)
                return false;

            player.SpendMoney(price);
            field.SetOwner(playerId);
            return true;
        }

        internal GamePlayer? GetPlayerInfo(int id)
        {
            return players.FirstOrDefault(p => p.Id == id);
        }

        internal bool Renta(int playerId, GameField field)
        {
            var player = GetPlayerInfo(playerId);
            if (player == null || !field.Owned)
                return false;

            var owner = GetPlayerInfo(field.PlayerId);
            var rent = field.GetRent();
            if (owner == null || rent == 0)
                return false;

            player.SpendMoney(rent);
            owner.ReceiveMoney(rent);
            return true;
        }
    }
}
