using CDP_Project.Models;

namespace CDP.Models.ViewModels
{
    public class UsuarioFormViewModel
    {
        public Usuario Usuario { get; set; }
        public ICollection<Cargo> Cargos { get; set; }
    }
}
