using CDP.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP.Models
{
    [Table("Sementes")]
    public class Semente
    {
        public Semente()
        {
        }

        [Key]
        public int Id { get; set; }
  
        [Display(Name = "Cultura")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public Cultura Cultura { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string Descricao { get; set; }

        [Display(Name = "Hábito de Crescimento")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string HabitoCrescimento { get; set; }

        [Display(Name = "Altura da Planta")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public decimal Altura { get; set; }

        [Display(Name = "Floração")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public decimal Floracao { get; set; }

        [Display(Name = "Resistência ao Acamamento")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Resistencia { get; set; }

        [Display(Name = "Grupo Maturaçãoo")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public decimal GrupoMaturacao { get; set; }

        [Display(Name = "Consumo Médio de Sementes")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string ConsumoSementes { get; set; }
    }
}