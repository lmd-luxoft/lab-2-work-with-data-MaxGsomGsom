// Copyright 2021 Russian Post
// This source code is Russian Post Confidential Proprietary.
// This software is protected by copyright. All rights and titles are reserved.
// You shall not use, copy, distribute, modify, decompile, disassemble or reverse engineer the software.
// Otherwise this violation would be treated by law and would be subject to legal prosecution.
// Legal use of the software provides receipt of a license from the right holder only.

using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    //TODO Инкапсулировать логику вычитания/прибавления денег в класс игрока, не пересоздавать игрока при каждой операции
    //TODO Инкапсулировать логику передачи права собственности в класс игрового поля, не пересоздавать поле при каждой операции
    //TODO Добавить айдишники для игроков, использовать их в игровых полях
    class Monopoly
    {
        private readonly List<GamePlayer> players = new List<GamePlayer>();
        private readonly List<GameField> fields = new List<GameField>();

        public Monopoly(string[] playersNames)
        {
            for (int i = 0; i < playersNames.Length; i++)
            {
                players.Add(new GamePlayer(playersNames[i], 6000));     
            }

            fields.Add(new GameField("Ford", FieldType.AUTO, 0, false));
            fields.Add(new GameField("MCDonald", FieldType.FOOD, 0, false));
            fields.Add(new GameField("Lamoda", FieldType.CLOTHER, 0, false));
            fields.Add(new GameField("Air Baltic", FieldType.TRAVEL, 0, false));
            fields.Add(new GameField("Nordavia", FieldType.TRAVEL, 0, false));
            fields.Add(new GameField("Prison", FieldType.PRISON, 0, false));
            fields.Add(new GameField("MCDonald", FieldType.FOOD, 0, false));
            fields.Add(new GameField("TESLA", FieldType.AUTO, 0, false));
        }

        internal IReadOnlyList<GamePlayer> GetPlayersList()
        {
            return players;
        }

        internal List<GameField> GetFieldsList()
        {
            return fields;
        }

        internal GameField GetFieldByName(string name)
        {
            return fields.FirstOrDefault(field => field.Name == name);
        }

        internal bool Buy(int playerIndex, GameField field)
        {
            var player = GetPlayerInfo(playerIndex);
            int cash = 0;
            switch(field.Type)
            {
                case FieldType.AUTO:
                    if (field.PlayerIndex != 0)
                        return false;
                    cash = player.Money - 500;
                    players[playerIndex - 1] = new GamePlayer(player.Name, cash);
                    break;
                case FieldType.FOOD:
                    if (field.PlayerIndex != 0)
                        return false;
                    cash = player.Money - 250;
                    players[playerIndex - 1] = new GamePlayer(player.Name, cash);
                    break;
                case FieldType.TRAVEL:
                    if (field.PlayerIndex != 0)
                        return false;
                    cash = player.Money - 700;
                    players[playerIndex - 1] = new GamePlayer(player.Name, cash);
                    break;
                case FieldType.CLOTHER:
                    if (field.PlayerIndex != 0)
                        return false;
                    cash = player.Money - 100;
                    players[playerIndex - 1] = new GamePlayer(player.Name, cash);
                    break;
                default:
                    return false;
            }
            int i = players.Select((item, index) => new { name = item.Name, index = index })
                .Where(n => n.name == player.Name)
                .Select(p => p.index).FirstOrDefault();
            fields[i] = new GameField(field.Name, field.Type, playerIndex, field.Owned);
             return true;
        }

        internal GamePlayer GetPlayerInfo(int index)
        {
            return players[index - 1];
        }

        internal bool Renta(int playerIndex, GameField field)
        {
            var player = GetPlayerInfo(playerIndex);
            GamePlayer oldPlayer = null;
            switch(field.Type)
            {
                case FieldType.AUTO:
                    if (field.PlayerIndex == 0)
                        return false;
                    oldPlayer =  GetPlayerInfo(field.PlayerIndex);
                    player = new GamePlayer(player.Name, player.Money - 250);
                    oldPlayer = new GamePlayer(oldPlayer.Name, oldPlayer.Money + 250);
                    break;
                case FieldType.FOOD:
                    if (field.PlayerIndex == 0)
                        return false;
                    oldPlayer = GetPlayerInfo(field.PlayerIndex);
                    player = new GamePlayer(player.Name, player.Money - 250);
                    oldPlayer = new GamePlayer(oldPlayer.Name, oldPlayer.Money + 250);

                    break;
                case FieldType.TRAVEL:
                    if (field.PlayerIndex == 0)
                        return false;
                    oldPlayer = GetPlayerInfo(field.PlayerIndex);
                    player = new GamePlayer(player.Name, player.Money - 300);
                    oldPlayer = new GamePlayer(oldPlayer.Name, oldPlayer.Money + 300);
                    break;
                case FieldType.CLOTHER:
                    if (field.PlayerIndex == 0)
                        return false;
                    oldPlayer = GetPlayerInfo(field.PlayerIndex);
                    player = new GamePlayer(player.Name, player.Money - 100);
                    oldPlayer = new GamePlayer(oldPlayer.Name, oldPlayer.Money + 1000);

                    break;
                case FieldType.PRISON:
                    player = new GamePlayer(player.Name, player.Money - 1000);
                    break;
                case FieldType.BANK:
                    player = new GamePlayer(player.Name, player.Money - 700);
                    break;
                default:
                    return false;
            }
            players[playerIndex - 1] = player;
            if(oldPlayer != null)
                players[field.PlayerIndex - 1] = oldPlayer;
            return true;
        }
    }
}
