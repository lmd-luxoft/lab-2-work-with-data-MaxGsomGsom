// Copyright 2021 Russian Post
// This source code is Russian Post Confidential Proprietary.
// This software is protected by copyright. All rights and titles are reserved.
// You shall not use, copy, distribute, modify, decompile, disassemble or reverse engineer the software.
// Otherwise this violation would be treated by law and would be subject to legal prosecution.
// Legal use of the software provides receipt of a license from the right holder only.

using System.Collections.Generic;

namespace Monopoly
{
    class GamePlayer
    {
        public GamePlayer(string name, int money)
        {
            Money = money;
            Name = name;
        }

        public string Name { get; private set; }

        public int Money { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is GamePlayer player &&
                   Name == player.Name &&
                   Money == player.Money;
        }
    }
}
