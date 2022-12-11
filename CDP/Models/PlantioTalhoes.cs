using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP.Models
{
    public class PlantioTalhoes
    {
        [Key]
        [Column(Order =1)]
        public int PlantioId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int TalhoesId { get; set; }

        public virtual Plantio Plantio { get; set; }
        public virtual Talhoes Talhoes { get; set; }
    }
}
