using CDP.Models;

namespace CDP.Models.ViewModels
{
    public class FuncionarioFormViewModel
    {
        public Funcionario Funcionario { get; set; }
        public ICollection<Cargo> Cargos { get; set; }
    }
}
