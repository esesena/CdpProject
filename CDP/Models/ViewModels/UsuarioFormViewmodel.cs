using CDP_Project.Models;

namespace CDP.Models.ViewModels
{
    public class UsuarioFormViewmodel
    {
        public Usuario Usuario { get; set; }
        public ICollection<Cargo> Cargos { get; set; }
    }
}
