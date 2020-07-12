﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace CodeFirstEFExercise.Models {

    /// <summary>
    /// Models individual item lines for each item in an order.
    /// </summary>
    public class OrderLine {

        public OrderLine() {}

        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int OrderId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }

    }
}
