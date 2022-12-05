﻿using CDP.Models;

namespace CDP.Models.ViewModels
{
    public class PlantioFormViewModel
    {
        public Plantio Plantio { get; set; }
        public IEnumerable<Talhoes> Talhao { get; set; }
        public ICollection<Semente> Sementes { get; set; }
    }
}
