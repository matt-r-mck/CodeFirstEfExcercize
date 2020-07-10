using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstEFExercise.Models {
    public class Order {

        public Order() {}

        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Description { get; set; }
        
        [Column(TypeName = "decimal(9,2)")]
        public decimal Total { get; set; }

        /// <summary>
        /// Creates FK
        /// </summary>
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual IEnumerable<OrderLine> OrderLines { get; set; }

    }
}
