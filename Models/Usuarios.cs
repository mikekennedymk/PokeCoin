using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokéCoin.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }
        [Required]
        [StringLength(80)]
        public string Email { get; set; }
        [Required]
        [StringLength(80)]
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }

    }
}
