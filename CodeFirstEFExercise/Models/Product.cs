using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstEFExercise.Models {
    public class Product {

        /// <summary>
        /// Models and creates table for products available from our inventory.
        /// </summary>
        public Product() {}

        public int Id { get; set; }

        //attributes
        [StringLength(8)]
        public string Code { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "decimal(9,2)")]
        public decimal Price { get; set; }
        public bool InStock { get; set; } = true;

    }
}
