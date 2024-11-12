using models;
using MongoDB.Driver;

namespace repositories
{
    public class ChargingStationRepository
    {
        private readonly IMongoCollection<ChargingStationModel> _chargingStations;

        public ChargingStationRepository(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _chargingStations = database.GetCollection<ChargingStationModel>(collectionName);
        }

        public async Task<List<ChargingStationModel>> GetChargingStationsAsync()
        {
            return await _chargingStations.Find(station => true).ToListAsync();
        }

        public async Task<ChargingStationModel> GetChargingStationByIdAsync(string id)
        {
            return await _chargingStations.Find(station => station.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateChargingStationAsync(ChargingStationModel chargingStation)
        {
            await _chargingStations.InsertOneAsync(chargingStation);
        }

        public async Task UpdateChargingStationAsync(string id, ChargingStationModel chargingStationIn)
        {
            chargingStationIn.Id = id;
            await _chargingStations.ReplaceOneAsync(station => station.Id == id, chargingStationIn);
        }

        public async Task DeleteChargingStationAsync(string id)
        {
            await _chargingStations.DeleteOneAsync(station => station.Id == id);
        }
    }
}