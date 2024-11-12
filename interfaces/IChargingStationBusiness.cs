using models;

namespace interfaces
{
    public interface IChargingStationBusiness
    {
        Task<List<ChargingStationModel>> GetChargingStationsAsync();
        Task<ChargingStationModel> GetChargingStationByIdAsync(string id);
        Task<ChargingStationModel> CreateChargingStationAsync(ChargingStationModel chargingStation);
        Task<ChargingStationModel> UpdateChargingStationAsync(string id, ChargingStationModel chargingStation);
        Task DeleteChargingStationAsync(string id);
    }
}