using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP.Models
{
    [Table("Plantio")]
    public class Plantio
    {
        public Plantio()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Data do Plantio")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public DateTime DataPlantio { get; set; }

        [Display(Name = "Quantidade de Chuva")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public double Chuva { get; set; }

        [Display(Name = "Tipo de Plantio")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string TipoPlantio { get; set; }

        [Display(Name = "Cultura")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string Cultura { get; set; }

        [Display(Name = "Tempo durante o plantio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string TempoPlantio { get; set; }

        [Display(Name = "Umidade do Ar")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public double UmidadePlantio { get; set; }

        [Display(Name = "Tipo de Semente")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public int IdSemente { get; set; }
        public virtual Semente Sementes { get; set; }

        [Display(Name = "Quantidade de Sementes")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string QtdSementes { get; set; }

        [Display(Name = "Distribuição de Sementes")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public double DistSementes { get; set; }

        [Display(Name = "Tipo de Abubação")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string Adubacao { get; set; }

        public Plantio(int id, DateTime dataPlantio, double chuva, string tipoPlantio, string cultura, string tempoPlantio, double umidadePlantio, Semente sementes, string qtdSementes, double distSementes, string adubacao)
        {
            Id = id;
            DataPlantio = dataPlantio;
            Chuva = chuva;
            TipoPlantio = tipoPlantio;
            Cultura = cultura;
            TempoPlantio = tempoPlantio;
            UmidadePlantio = umidadePlantio;
            Sementes = sementes;
            QtdSementes = qtdSementes;
            DistSementes = distSementes;
            Adubacao = adubacao;
        }
    }
}
