using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CDP_Project.Models
{
    [Table("Plantio")]
    public class Plantio
    {
        [Key]
        public int IdPlantio { get; set; }

        [Display(Name = "Data do Plantio")]
        [Required(ErrorMessage = "Data é obrigatório!")]
        public DateTime DataPlantio { get; set; }

        [Display(Name = "Quantidade de Chuva")]
        [Required(ErrorMessage = "Quantidade de chuva é obrigatório!")]
        public int Chuva { get; set; }

        [Display(Name = "Tipo de Plantio")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Tipo de plantio é obrigatório!")]
        public string TipoPlantio { get; set; }

        [Display(Name = "Cultura")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Cultura é obrigatório!")]
        public string Cultura { get; set; }

        [Display(Name = "Tempo")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Tempo é obrigatório!")]
        public string TempoPlantio { get; set; }

        [Display(Name = "Umidade do Ar")]
        [Required(ErrorMessage = "Umidade é obrigatório!")]
        public int UmidadePlantio { get; set; }

        [Display(Name = "Tipo de Semente")]
        [Required(ErrorMessage = "Tipo de semente é obrigatório!")]
        public int IdSemente { get; set; }
        public virtual Semente Sementes { get; set; }

        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Display(Name = "Quantidade de Sementes")]
        [Required(ErrorMessage = "Quantidade de sementes é obrigatório!")]
        public string QtdSementes { get; set; }

        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Display(Name = "Distribuição de Sementes")]
        [Required(ErrorMessage = "Distribuição de sementes é obrigatório!")]
        public string DistSementes { get; set; }

        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Display(Name = "Tipo de Abubação")]
        [Required(ErrorMessage = "Tipo de adubação é obrigatório!")]
        public string Adubacao { get; set; }
    }
}
