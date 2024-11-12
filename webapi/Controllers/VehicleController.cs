using interfaces;
using Microsoft.AspNetCore.Mvc;
using models;

namespace webapi_swagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleBusiness _vehicleBusiness;

        public VehiclesController(IVehicleBusiness vehicleBusiness)
        {
            _vehicleBusiness = vehicleBusiness;
        }

        /// <summary>
        /// Lista todos os veículos.
        /// </summary>
        /// <returns>Uma lista de veículos.</returns>
        [HttpGet]
        [Tags("Consulta de Veículos")]
        [ProducesResponseType(typeof(List<VehicleModel>), 200)]
        public async Task<IActionResult> GetVehiclesAsync()
        {
            var vehicles = await _vehicleBusiness.GetVehiclesAsync();
            return Ok(vehicles);
        }

        /// <summary>
        /// Consulta um veículo específico pelo ID.
        /// </summary>
        /// <param name="id">Identificador único do veículo.</param>
        /// <returns>O veículo consultado, caso encontrado. Caso contrário, NotFound (404).</returns>
        [HttpGet("{id}")]
        [Tags("Consulta de Veículos")]
        [ProducesResponseType(typeof(VehicleModel), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetVehicleByIdAsync(string id)
        {
            var vehicle = await _vehicleBusiness.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        /// <summary>
        /// Cria um novo veículo.
        /// </summary>
        /// <param name="vehicle">Dados do veículo a ser criado.</param>
        /// <returns>O veículo criado, incluindo o ID gerado.</returns>
        [HttpPost]
        [Tags("Cadastro de Veículos")]
        [ProducesResponseType(typeof(VehicleModel), 201)]
        public async Task<IActionResult> CreateVehicleAsync([FromBody] VehicleModel vehicle)
        {
            var createdVehicle = await _vehicleBusiness.CreateVehicleAsync(vehicle);
            return CreatedAtRoute("GetVehicleById", new { id = createdVehicle.Id }, createdVehicle);
        }

        /// <summary>
        /// Atualiza um veículo existente.
        /// </summary>
        /// /// <param name="id">Identificador único do veículo.</param>
        /// <param name="vehicle">Dados do veículo atualizado.</param>
        /// <returns>No Content (204) se a atualização for bem-sucedida. Caso contrário, NotFound (404).</returns>
        [HttpPut("{id}")]
        [Tags("Atualização de Veículos")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateVehicleAsync(string id, [FromBody] VehicleModel vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest("ID da URL deve corresponder ao ID do veículo no corpo da requisição.");
            }

            var updatedVehicle = await _vehicleBusiness.UpdateVehicleAsync(id, vehicle);
            if (updatedVehicle == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Exclui um veículo.
        /// </summary>
        /// <param name="id">Identificador único do veículo.</param>
        /// <returns>No Content (204) se a exclusão for bem-sucedida. Caso contrário, NotFound (404).</returns>
        [HttpDelete("{id}")]
        [Tags("Exclusão de Veículos")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteVehicleAsync(string id)
        {
            await _vehicleBusiness.DeleteVehicleAsync(id);
            return NoContent();
        }
    }
}