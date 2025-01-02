﻿using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Try2.Dtos
{
    public class ProductDto
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
    }
}