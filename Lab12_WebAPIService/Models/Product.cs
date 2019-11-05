﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab12_WebAPIService.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Price { get; set; }
    }
}