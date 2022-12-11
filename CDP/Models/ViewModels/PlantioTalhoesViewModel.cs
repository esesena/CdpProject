using Org.BouncyCastle.Asn1.Crmf;

namespace CDP.Models.ViewModels
{
    public class PlantioTalhoesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DataPlantio { get; set; }
        public bool Checked { get; set; }
    }
}
