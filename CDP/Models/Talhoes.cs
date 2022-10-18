using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP.Models
{
    [Table("Talhoes")]
    public class Talhoes
    {
        [Key]
        public int IdTalhao { get; set; }

        [Display(Name = "Nome")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Localização")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Localização é obrigatório!")]
        public string Localizacao { get; set; }

        [Display(Name = "Área")]
        [Required(ErrorMessage = "Área é obrigatório!")]
        public int Area { get; set; }

        [Display(Name = "Tipo de Solo")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Tipo de solo é obrigatório!")]
        public string TipoSolo { get; set; }

        [Display(Name = "Cultivar Anterior")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Cultivar anterior é obrigatório!")]
        public string CultivarAnterior { get; set; }

        [Display(Name = "Fazenda")]
        [Required(ErrorMessage = "Fazenda é obrigatório!")]
        public int IdFazenda { get; set; }

        public virtual Fazenda Fazenda { get; set; }
    }
}