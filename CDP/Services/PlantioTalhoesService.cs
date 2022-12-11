using CDP.Data;
using CDP.Models;

namespace CDP.Services
{
    public class PlantioTalhoesService
    {
        private readonly CDPContext _context;

        public PlantioTalhoesService(CDPContext context)
        {
            _context = context;
        }
        public async Task InsertAsync(int PlantioId, int []TalhoesId)
        {
            foreach (var talId in TalhoesId)
            {
                PlantioTalhoes plantioTalhoes = new PlantioTalhoes();
                plantioTalhoes.PlantioId = PlantioId;
                plantioTalhoes.TalhoesId = talId;
                _context.Add(plantioTalhoes);
                await _context.SaveChangesAsync();
            }

        }

    }
}
