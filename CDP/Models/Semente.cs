using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP_Project.Models
{
    [Table("Sementes")]
    public class Semente
    {
        [Key]
        public int IdSemente { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição é obrigatório!")]
        [StringLength(100, ErrorMessage = "Máximo de 20 caracteres!")]
        public string Descricao { get; set; }
    }
}