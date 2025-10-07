﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _02_EF_Core_DbContext.Data
{
    public class Wallet
    {
        public int Id { get; set; }
        public string? Holder { get; set; }
        public decimal? Balance { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Holder}  ({Balance})";
        }

    }
}
