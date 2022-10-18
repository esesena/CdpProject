using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP.Models
{
    [Table("Plantio")]
    public class Plantio
    {
        [Key]
        public int IdPlantio { get; set; }

        [Display(Name = "Data do Plantio")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public DateTime DataPlantio { get; set; }

        [Display(Name = "Quantidade de Chuva")]
        [Required(ErrorMessage = "Quantidade de {0} é obrigatório!")]
        public int Chuva { get; set; }

        [Display(Name = "Tipo de Plantio")]
        [Required(ErrorMessage = "Tipo de plantio é obrigatório!")]
        [StringLength(100, ErrorMessage = "Máximo de {1} caracteres!")]
        public string TipoPlantio { get; set; }

        [Display(Name = "Cultura")]
        [Required(ErrorMessage = "Cultura é obrigatório!")]
        [StringLength(100, ErrorMessage = "Máximo de {1} caracteres!")]
        public string Cultura { get; set; }

        [Display(Name = "Tempo")]
        [StringLength(250, ErrorMessage = "Máximo de {1} caracteres!")]
        [Required(ErrorMessage = "Tempo é obrigatório!")]
        public string TempoPlantio { get; set; }

        [Display(Name = "Umidade do Ar")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public int UmidadePlantio { get; set; }

        [Display(Name = "Tipo de Semente")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public int IdSemente { get; set; }
        public virtual Semente Sementes { get; set; }

        [Display(Name = "Quantidade de Sementes")]
        [StringLength(250, ErrorMessage = "Máximo de {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string QtdSementes { get; set; }

        [Display(Name = "Distribuição de Sementes")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "Máximo de {1} caracteres!")]
        public string DistSementes { get; set; }

        [Display(Name = "Tipo de Abubação")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(250, ErrorMessage = "Máximo de {1} caracteres!")]
        public string Adubacao { get; set; }
    }
}
