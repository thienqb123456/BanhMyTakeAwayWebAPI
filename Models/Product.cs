using System.ComponentModel.DataAnnotations;

namespace ThienAspWebApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public double Price { get; set; }

        public int TypeCateId { get; set; }

        public TypeCate? TypeCate { get; set; }
    }
}
