﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MotorcycleRental.Domain.Entities
{
    public class RentalPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = default!;

        [Required]
        public int Days { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}
