using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstEFExercise.Models {
    
    /// <summary>
    /// Models an order created by a customer and creates order table.
    /// </summary>
    public class Order {

        public Order() {}

        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "decimal(9,2)")]
        public decimal Total { get; set; }

        /// <summary>
        /// Creates FK to attach customer to each order.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Creates a virtual instance of customer owning this order.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Creates a virtual instane of all lines attached to rder when called.
        /// </summary>
        public virtual IEnumerable<OrderLine> OrderLines { get; set; }

    }
}
