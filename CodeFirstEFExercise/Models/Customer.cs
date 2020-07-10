using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstEFExercise.Models {
    public class Customer {

        public Customer() {}

        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        [StringLength(2)]
        [Required]
        public string State { get; set; }
        public bool IsNationalAccount { get; set; } = false;
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalSales { get; set; } = 0;

        []
        public virtual IEnumerable<Order> Orders { get; set; }

    }
}
