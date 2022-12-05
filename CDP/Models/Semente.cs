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

        [Display(Name = "Resistência")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string Resistencia { get; set; }

        [Display(Name = "Maturação")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public decimal Maturacao { get; set; }

        public Semente(int idSemente, string descricao, string resistencia, decimal maturacao)
        {
            Id = idSemente;
            Descricao = descricao;
            Resistencia = resistencia;
            Maturacao = maturacao;
        }
    }
}