using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CDP.Models
{
    [Table("Fazenda")]
    public class Fazenda
    {
        public Fazenda()
        {
        }

        [Key]
        public int IdFazenda { get; set; }

        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Localização")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Localizacao { get; set; }

        [Display(Name = "Área")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public double Area { get; set; }

        public ICollection<Talhoes> Talhoes { get; set; } = new List<Talhoes>();

        public Fazenda(int idFazenda, string nome, string localizacao, double area)
        {
            IdFazenda = idFazenda;
            Nome = nome;
            Localizacao = localizacao;
            Area = area;
        }
    }
}