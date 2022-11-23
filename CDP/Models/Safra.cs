using CDP.Models.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP.Models
{
    [Table("Safras")]
    public class Safra
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome da Safra")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(10, ErrorMessage = "Máximo de {1} caracteres!")]
        public string Nome { get; set; }

        [Display(Name = "Cultura")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public Cultura Cultura { get; set; }

        [Display(Name = "Funcionarios")]
        [Required(ErrorMessage = "Funcionário é obrigatório!")]
        public ICollection<Funcionario> Funcionarios { get; set; }

        [Display(Name = "Funcionarios")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public int TalhaoId { get; set; }

        public ICollection<Talhoes> Talhoes { get; set; }
    }
}
