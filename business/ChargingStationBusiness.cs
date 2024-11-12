using interfaces;
using Microsoft.Extensions.Options;
using models;
using repositories;
using repositories.Settings;

namespace business
{
    public class ChargingStationBusiness : IChargingStationBusiness
    {
        private readonly ChargingStationRepository _chargingStationRepository;

        public ChargingStationBusiness(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var settings = mongoDbSettings.Value;
            _chargingStationRepository = new ChargingStationRepository(settings.ConnectionString!, settings.DatabaseName!,
                settings.CollectionName!);
        }
        public async Task<List<ChargingStationModel>> GetChargingStationsAsync()
        {
            return await _chargingStationRepository.GetChargingStationsAsync();
        }

        public async Task<ChargingStationModel> GetChargingStationByIdAsync(string id)
        {
            return await _chargingStationRepository.GetChargingStationByIdAsync(id);
        }

        public async Task<ChargingStationModel> CreateChargingStationAsync(ChargingStationModel chargingStation)
        {

            await _chargingStationRepository.CreateChargingStationAsync(chargingStation);
            
            return chargingStation;
        }

        public async Task<ChargingStationModel> UpdateChargingStationAsync(string id, ChargingStationModel chargingStation)
        {

            chargingStation.Id = id;
            await _chargingStationRepository.UpdateChargingStationAsync(id, chargingStation);


            return chargingStation;
        }

        public async Task DeleteChargingStationAsync(string id)
        {
            await _chargingStationRepository.DeleteChargingStationAsync(id);
        }
    }
}