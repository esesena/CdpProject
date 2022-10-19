using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        public Funcionario()
        {
        }

        [Key]
        public int IdFuncionario { get; set; }

        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "Nome do funcionário é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [StringLength(15, ErrorMessage = "{0} deve ter {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Cpf { get; set; }

        [Display(Name = "Cargo")]
        public int IdCargo { get; set; }
        public virtual Cargo Cargo { get; set; }

        [Display(Name = "Carga Horária")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public int CargaHoraria { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public DataType DataNascimento { get; set; }

        [Display(Name = "CEP")]
        [StringLength(10, ErrorMessage = "{0} deve ter {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Cep { get; set; }

        [Display(Name = "Logradouro")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Logradouro { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Estado { get; set; }

        public Funcionario(int idFuncionario, string nome, string cpf, Cargo cargo, int cargaHoraria, DataType dataNascimento, string cep, string logradouro, string bairro, string cidade, string estado)
        {
            IdFuncionario = idFuncionario;
            Nome = nome;
            Cpf = cpf;
            Cargo = cargo;
            CargaHoraria = cargaHoraria;
            DataNascimento = dataNascimento;
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}