﻿using System.ComponentModel.DataAnnotations;

namespace ThienAspWebApi.Models
{
    public class TypeCate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Category? Category { get; set; }
    }
}