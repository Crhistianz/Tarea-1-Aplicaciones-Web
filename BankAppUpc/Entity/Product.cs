using System;
using System.Collections.Generic;
using System.Text;
using BankAppUpc.Common;

namespace BankAppUpc.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Enums.Status Status { get; set; }
    }
}
