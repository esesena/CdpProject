using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CDP_Project.Models
{
    [Table("Fazenda")]
    public class Fazenda
    {
        [Key]
        public int IdFazenda { get; set; }

        [Display(Name = "Nome")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Localização")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Localizacao { get; set; }

        [Display(Name = "Área")]
        [Required(ErrorMessage = "Área é obrigatório!")]
        public int Area { get; set; }
    }
}