﻿using System.ComponentModel.DataAnnotations;

namespace ThienAspWebApi.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        public List<TypeCate>? TypeCates { get; set; }

    }
}
