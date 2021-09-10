using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleClientes.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [MaxLength(150, ErrorMessage = "O nome dever ter no máximo 150 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é um campo obrigatório")]
        [MaxLength(11, ErrorMessage = "O CPF dever ter no máximo 10 caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Data de nascimento é um campo obrigatório")]
        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }
        public decimal RendaFamiliar { get; set; }
    }
}
