using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayckerson.App.Comum.Models
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public Contato Contato { get; set; }
        public Endereco Endereco { get; set; }
        public int Idade => DateTime.Today.Year - Nascimento.Year;
    }
}
