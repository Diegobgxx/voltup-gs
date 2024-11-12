using models;

namespace interfaces
{
    public interface IVehicleBusiness
    {
        List<VehicleModel> GetVehicles();
        VehicleModel GetVehicleById(string id);
        VehicleModel CreateVehicle(VehicleModel vehicle);
        VehicleModel UpdateVehicle(string id, VehicleModel vehicle);
        void DeleteVehicle(string id);
    }
}