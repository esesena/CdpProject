using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP_Project.Models
{
    [Table("Cargos")]
    public class Cargo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "Máximo de 20 caracteres!")]
        public string Descricao { get; set; }

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

        public Cargo()
        {

        }

        public Cargo(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public void AddUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }
        public void AddFuncionario(Funcionario funcionario)
        {
            Funcionarios.Add(funcionario);
        }
    }
}