using interfaces;
using Microsoft.Extensions.Options;
using models;
using repositories;
using repositories.Settings;

namespace business
{
    public class VehicleBusiness : IVehicleBusiness
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleBusiness(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var settings = mongoDbSettings.Value;
            _vehicleRepository = new VehicleRepository(settings.ConnectionString!, settings.DatabaseName!,
                settings.CollectionName!);
        }

        public async Task<List<VehicleModel>> GetVehiclesAsync()
        {
            return await _vehicleRepository.GetVehiclesAsync();
        }

        public async Task<VehicleModel> GetVehicleByIdAsync(string id)
        {
            return await _vehicleRepository.GetVehicleByIdAsync(id);
        }

        public async Task<VehicleModel> CreateVehicleAsync(VehicleModel vehicle)
        {

            await _vehicleRepository.CreateVehicleAsync(vehicle);

            return vehicle;
        }

        public async Task<VehicleModel> UpdateVehicleAsync(string id, VehicleModel vehicle)
        {

            vehicle.Id = id; 
            await _vehicleRepository.UpdateVehicleAsync(id, vehicle);
            
            return vehicle;
        }

        public async Task DeleteVehicleAsync(string id)
        {
            await _vehicleRepository.DeleteVehicleAsync(id);
        }
    }
}