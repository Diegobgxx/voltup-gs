using models;

namespace interfaces
{
    public interface IVehicleBusiness
    {
        Task<List<VehicleModel>> GetVehiclesAsync();
        Task<VehicleModel> GetVehicleByIdAsync(string id);
        Task<VehicleModel> CreateVehicleAsync(VehicleModel vehicle);
        Task<VehicleModel> UpdateVehicleAsync(string id, VehicleModel vehicle);
        Task DeleteVehicleAsync(string id);
    }
}