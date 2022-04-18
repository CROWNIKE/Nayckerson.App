using System.ComponentModel.DataAnnotations.Schema;

namespace Nayckerson.App.Comum.Models
{
    public class Endereco
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Quadra { get; set; }
        public string Lote { get; set; }
    }
}