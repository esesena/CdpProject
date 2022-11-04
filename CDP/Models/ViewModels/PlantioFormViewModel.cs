using CDP.Models;

namespace CDP.Models.ViewModels
{
    public class PlantioFormViewModel
    {
        public Plantio Plantio { get; set; }
        public ICollection<Safra> Safras { get; set; }
        public ICollection<Talhoes> Talhoes { get; set; }
    }
}
