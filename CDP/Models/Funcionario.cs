using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP_Project.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        public int IdFuncionario { get; set; }

        [Display(Name = "Nome")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Nome do funcionário é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [StringLength(15, ErrorMessage = "Máximo de 15 caracteres!")]
        [Required(ErrorMessage = "CPF é obrigatório!")]
        public string Cpf { get; set; }

        [Display(Name = "Cargo")]
        public int IdCargo { get; set; }
        public virtual Cargo Cargo { get; set; }

        [Display(Name = "Carga Horária")]
        [Required(ErrorMessage = "Carga horária é obrigatório!")]
        public int CargaHoraria { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de nascimento é obrigatório!")]
        public DataType DataNascimento { get; set; }

        [Display(Name = "CEP")]
        [StringLength(10, ErrorMessage = "Máximo de 10 caracteres!")]
        [Required(ErrorMessage = "CEP é obrigatório!")]
        public string Cep { get; set; }

        [Display(Name = "Logradouro")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Logradouro é obrigatório!")]
        public string Logradouro { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Bairro é obrigatório!")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(250, ErrorMessage = "Máximo de 250 caracteres!")]
        [Required(ErrorMessage = "Cidade é obrigatório!")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [StringLength(100, ErrorMessage = "Máximo de 100 caracteres!")]
        [Required(ErrorMessage = "Estado é obrigatório!")]
        public string Estado { get; set; }
    }
}