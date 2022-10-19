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

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string Descricao { get; set; }

        public Semente(int idSemente, string descricao)
        {
            Id = idSemente;
            Descricao = descricao;
        }
    }
}