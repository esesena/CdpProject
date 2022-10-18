using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CDP.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Display(Name = "Administrador")]
        public bool Admin { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
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

        public Usuario()
        {

        }

        public Usuario(int id, string nome, string email, string senha, bool admin, bool ativo, string telefone, string celular, Cargo cargos)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Admin = admin;
            Ativo = ativo;
            Telefone = telefone;
            Celular = celular;
            Cargos = cargos;
        }
    }
}
