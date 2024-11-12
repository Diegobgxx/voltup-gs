using models;

namespace interfaces
{
    public interface IChargingStationBusiness
    {
        List<ChargingStationModel> GetChargingStations();
        ChargingStationModel GetChargingStationById(string id);
        ChargingStationModel CreateChargingStation(ChargingStationModel chargingStation);
        ChargingStationModel UpdateChargingStation(string id, ChargingStationModel chargingStation);
        void DeleteChargingStation(string id);
    }
}