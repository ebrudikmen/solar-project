using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarProject.Models
{
    [Table("Bill", Schema = "dbo")]
    public class Bill
    {
        [Key] 
        public long Id { get; set; }

        [Required]
        public DateTime BillingDate { get; set; }

        [Required]
        public double Amount { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string PaymentType { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}