using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIparaTESTE.Domains
    {
    [Table("Produto")]
    public class Product
        {
        [Key]
        public Guid IdProduct { get; set; }
        [Required(ErrorMessage ="Nome obrigatório!")]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Preço obrigatório!")]
        [Column(TypeName = "SMALLMONEY")]
        public decimal Price { get; set; }
        }
    }
