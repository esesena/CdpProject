using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP_Project.Models
{
    [Table("Safras")]
    public class Safra
    {
        [Key]
        public int IdSafra { get; set; }

        [Display(Name = "Nome da Safra")]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        [StringLength(10, ErrorMessage = "Máximo de 10 caracteres!")]
        public string Nome { get; set; }

        [Display(Name = "Funcionarios")]
        [Required(ErrorMessage = "Funcionário é obrigatório!")]
        public ICollection<Funcionario> Funcionarios { get; set; }

        [Display(Name = "Funcionarios")]
        [Required(ErrorMessage = "Funcionário é obrigatório!")]
        public int IdTalhao { get; set; }

        public ICollection<Talhoes> Talhoes { get; set; }
    }
}
