using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Tasks
{
    public sealed record Priority :ValueObject
    {
        public static readonly Priority Low = new("Low", 1);
        public static readonly Priority Medium = new("Medium", 2);
        public static readonly Priority High = new("High", 3);
        public static readonly Priority Critical = new("Critical", 4);

        private static readonly Dictionary<int, Priority> _priorities = new()
        {
            [1] = Low,
            [2] = Medium,
            [3] = High,
            [4] = Critical
        };

        public string Name { get; }
        public int Value { get; }

        // FIXED: Constructor parameters swapped to match usage
        private Priority(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public static Priority FromValue(int value) => _priorities[value];

        public static Priority FromName(string name) => name?.ToLower() switch
        {
            "low" => Low,
            "medium" => Medium,
            "high" => High,
            "critical" => Critical,
            _ => throw new ArgumentException($"Invalid priority: {name}")
        };
    }
}
