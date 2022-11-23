using CDP.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP.Models
{
    [Table("Aviso")]
    public class Aviso
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(50, ErrorMessage = "Máximo de {1} caracteres!")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(250, ErrorMessage = "Máximo de {1} caracteres!")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Display(Name = "Prioridade")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public Prioridades Prioridade { get; set; }

        public Aviso() { }

        public Aviso(int id, string name, string description, Prioridades prioridade)
        {
            Id = id;
            Name = name;
            Description = description;
            CreationDate = DateTime.Now;
            Prioridade = prioridade;
        }
    }
}
