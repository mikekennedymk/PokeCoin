using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokéCoin.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(80)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [StringLength(80)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(80)]
        public string Senha { get; set; }

        public DateTime DataNascimento { get; set; }

        [Required]
        public DateTime CriadoEm { get; set; }

        public DateTime? RemovidoEm { get; set; }

        // Construtor que define CriadoEm com a data atual
        public Usuarios()
        {
            CriadoEm = DateTime.UtcNow;
        }
    }
}