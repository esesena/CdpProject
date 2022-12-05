using CDP.Models.Enums;
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPlantio { get; set; }

        [Display(Name = "Cultura")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public Cultura Cultura { get; set; }

        [Display(Name = "Safra")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string Safra { get; set; }

        [Display(Name = "Quantidade de Chuva")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Chuva { get; set; }

        [Display(Name = "Tipo de Plantio")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public TipoPlantio TipoPlantio { get; set; }

        [Display(Name = "Tempo durante o plantio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string TempoPlantio { get; set; }

        [Display(Name = "Umidade do Ar")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UmidadePlantio { get; set; }

        [Display(Name = "Tipo de Semente")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public int SementeId { get; set; }
        public virtual Semente Sementes { get; set; }

        [Display(Name = "Quantidade de Sementes")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string QtdSementes { get; set; }

        [Display(Name = "Distribuição de Sementes")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal DistSementes { get; set; }

        [Display(Name = "Tipo de Abubação")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string Adubacao { get; set; }

        [Display(Name = "Talhões")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public int TalhaoId { get; set; }
        public ICollection<Talhoes> Talhao { get; set; }

    }
}
