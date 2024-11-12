using interfaces;
using Microsoft.AspNetCore.Mvc;
using models;

namespace webapi_swagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargingStationsController : ControllerBase
    {
        private readonly IChargingStationBusiness _chargingStationBusiness;

        public ChargingStationsController(IChargingStationBusiness chargingStationBusiness)
        {
            _chargingStationBusiness = chargingStationBusiness;
        }

        /// <summary>
        /// Lista todas as estações de carregamento.
        /// </summary>
        /// <returns>Uma lista de estações de carregamento.</returns>
        [HttpGet]
        [Tags("Consulta de Estações de Carregamento")]
        [ProducesResponseType(typeof(List<ChargingStationModel>), 200)]
        public async Task<IActionResult> GetChargingStationsAsync()
        {
            var chargingStations = await _chargingStationBusiness.GetChargingStationsAsync();
            return Ok(chargingStations);
        }

        /// <summary>
        /// Consulta uma estação de carregamento específica pelo ID.
        /// </summary>
        /// <param name="id">Identificador único da estação de carregamento.</param>
        /// <returns>A estação de carregamento consultada, caso encontrada. Caso contrário, NotFound (404).</returns>
        [HttpGet("{id}")]
        [Tags("Consulta de Estações de Carregamento")]
        [ProducesResponseType(typeof(ChargingStationModel), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetChargingStationByIdAsync(string id)
        {
            var chargingStation = await _chargingStationBusiness.GetChargingStationByIdAsync(id);
            if (chargingStation == null)
            {
                return NotFound();
            }
            return Ok(chargingStation);
        }

        /// <summary>
        /// Cria uma nova estação de carregamento.
        /// </summary>
        /// <param name="chargingStation">Dados da estação de carregamento a ser criada.</param>
        /// <returns>A estação de carregamento criada, incluindo o ID gerado.</returns>
        [HttpPost]
        [Tags("Cadastro de Estações de Carregamento")]
        [ProducesResponseType(typeof(ChargingStationModel), 201)]
        public async Task<IActionResult> CreateChargingStationAsync([FromBody] ChargingStationModel chargingStation)
        {
            var createdChargingStation = await _chargingStationBusiness.CreateChargingStationAsync(chargingStation);
            return CreatedAtRoute("GetChargingStationById", new { id = createdChargingStation.Id }, createdChargingStation);
        }

        /// <summary>
        /// Atualiza uma estação de carregamento existente.
        /// </summary>
        /// <param name="id">Identificador único da estação de carregamento.</param>
        /// <param name="chargingStation">Dados da estação de carregamento atualizada.</param>
        /// <returns>No Content (204) se a atualização for bem-sucedida. Caso contrário, NotFound (404).</returns>
        [HttpPut("{id}")]
        [Tags("Atualização de Estações de Carregamento")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateChargingStationAsync(string id, [FromBody] ChargingStationModel chargingStation)
        {
            if (id != chargingStation.Id)
            {
                return BadRequest("ID da URL deve corresponder ao ID da estação de carregamento no corpo da requisição.");
            }

            var updatedChargingStation = await _chargingStationBusiness.UpdateChargingStationAsync(id, chargingStation);
            if (updatedChargingStation == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Exclui uma estação de carregamento.
        /// </summary>
        /// <param name="id">Identificador único da estação de carregamento.</param>
        /// <returns>No Content (204) se a exclusão for bem-sucedida. Caso contrário, NotFound (404).</returns>
        [HttpDelete("{id}")]
        [Tags("Exclusão de Estações de Carregamento")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteChargingStationAsync(string id)
        {
            await _chargingStationBusiness.DeleteChargingStationAsync(id);
            return NoContent();
        }
    }
}