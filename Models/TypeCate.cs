using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThienAspWebApi.Models
{
    public class TypeCate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        public List<Product>? Products { get; set; }
    }
}
