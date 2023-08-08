using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserCrudApi.Models
{
    public class CadastroUsuario
    {
        [Key]
        [Column("Codigo")]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        public string Telefone { get; set; }
        [Required]
        public string Senha { get; set; }

    }
}