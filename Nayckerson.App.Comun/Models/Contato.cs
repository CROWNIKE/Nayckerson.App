using System.ComponentModel.DataAnnotations.Schema;

namespace Nayckerson.App.Comum.Models
{
    public class Contato
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}