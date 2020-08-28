﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter а product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter а description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage = "Please enter а positive price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please specify а category")]
        public string Category { get; set; }
    }
}
