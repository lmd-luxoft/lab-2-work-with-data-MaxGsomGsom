// Copyright 2021 Russian Post
// This source code is Russian Post Confidential Proprietary.
// This software is protected by copyright. All rights and titles are reserved.
// You shall not use, copy, distribute, modify, decompile, disassemble or reverse engineer the software.
// Otherwise this violation would be treated by law and would be subject to legal prosecution.
// Legal use of the software provides receipt of a license from the right holder only.

namespace Monopoly
{
    internal sealed class GameField
    {
        public GameField(string name, FieldType type, int playerIndex, bool owned)
        {
            Name = name;
            Type = type;
            PlayerIndex = playerIndex;
            Owned = owned;
        }

        public string Name { get; private set; }

        public FieldType Type { get; private set; }

        public int PlayerIndex { get; private set; }

        public bool Owned { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is GameField field &&
                   Name == field.Name &&
                   Type == field.Type &&
                   PlayerIndex == field.PlayerIndex &&
                   Owned == field.Owned;
        }
    }
}
