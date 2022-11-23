using CDP.Models.Enums;
using NuGet.Protocol.Core.Types;

namespace CDP.Models.ViewModels
{
    public class SafraFormViewModel
    {
        public Safra Safra { get; set; }
        public Cultura Cultura { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
