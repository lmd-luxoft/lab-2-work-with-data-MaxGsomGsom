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
        public GameField(string name, FieldType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; private set; }

        public FieldType Type { get; private set; }

        public int PlayerId { get; private set; }

        public bool Owned { get; private set; }

        public void SetOwner(int playerId)
        {
            PlayerId = playerId;
            Owned = true;
        }

        public int GetPrice()
        {
            return Type switch
            {
                FieldType.AUTO => 500,
                FieldType.FOOD => 250,
                FieldType.TRAVEL => 700,
                FieldType.CLOTHER => 100,
                _ => 0
            };
        }

        public int GetRent()
        {
            return Type switch
            {
                FieldType.AUTO => 250,
                FieldType.FOOD => 250,
                FieldType.TRAVEL => 300,
                FieldType.CLOTHER => 100,
                FieldType.PRISON => 1000,
                FieldType.BANK => 700,
                _ => 0
            };
        }

        public override bool Equals(object obj)
        {
            return obj is GameField field &&
                   Name == field.Name &&
                   Type == field.Type &&
                   PlayerId == field.PlayerId &&
                   Owned == field.Owned;
        }
    }
}
