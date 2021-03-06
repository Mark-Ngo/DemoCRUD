namespace DemoCRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(266)]
        public string Name { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}