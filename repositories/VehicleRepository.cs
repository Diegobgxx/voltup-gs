using models;
using MongoDB.Driver;

namespace repositories
{
    public class VehicleRepository
    {
        private readonly IMongoCollection<VehicleModel> _vehicles;

        public VehicleRepository(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _vehicles = database.GetCollection<VehicleModel>(collectionName);
        }

        public async Task<List<VehicleModel>> GetVehiclesAsync()
        {
            return await _vehicles.Find(vehicle => true).ToListAsync();
        }

        public async Task<VehicleModel> GetVehicleByIdAsync(string id)
        {
            return await _vehicles.Find(vehicle => vehicle.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateVehicleAsync(VehicleModel vehicle)
        {
            await _vehicles.InsertOneAsync(vehicle);
        }

        public async Task UpdateVehicleAsync(string id, VehicleModel vehicleIn)
        {
            vehicleIn.Id = id;
            await _vehicles.ReplaceOneAsync(vehicle => vehicle.Id == id, vehicleIn);
        }

        public async Task DeleteVehicleAsync(string id)
        {
            await _vehicles.DeleteOneAsync(vehicle => vehicle.Id == id);
        }
    }
}