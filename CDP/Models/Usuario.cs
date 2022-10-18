using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CDP_Project.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Email é obrigatório!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Senha é obrigatório!")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Administrador é obrigatório!")]
        [Display(Name = "Administrador")]
        public bool Admin { get; set; }

        [Required(ErrorMessage = "Ativo é obrigatório!")]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [StringLength(20, ErrorMessage = "Máximo de 20 caracteres!")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [StringLength(20, ErrorMessage = "Máximo de 20 caracteres!")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Display(Name = "Cargo")]
        public int IdCargo { get; set; }
        public Cargo Cargos { get; set; }

    }
}
