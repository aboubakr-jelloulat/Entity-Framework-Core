using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Jump_start.Shared
{
    public class Wallet
    {
        public int Id { get; set; }
        public string? Holder;
        public decimal? Balance { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Holder}  ({Balance})";
        }

    }
}

