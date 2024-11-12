using interfaces;
using Microsoft.AspNetCore.Mvc;
using models;

namespace webapi_swagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        /// <summary>
        /// Lista todos os usuários.
        /// </summary>
        /// <returns>Uma lista de usuários.</returns>
        [HttpGet]
        [Tags("Consulta de Usuários")]
        [ProducesResponseType(typeof(List<UserModel>), 200)]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await _userBusiness.GetUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Consulta um usuário específico pelo ID.
        /// </summary>
        /// <param name="id">Identificador único do usuário.</param>
        /// <returns>O usuário consultado, caso encontrado. Caso contrário, NotFound (404).</returns>
        [HttpGet("{id}")]
        [Tags("Consulta de Usuários")]
        [ProducesResponseType(typeof(UserModel), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            var user = await _userBusiness.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="user">Dados do usuário a ser criado.</param>
        /// <returns>O usuário criado, incluindo o ID gerado.</returns>
        [HttpPost]
        [Tags("Cadastro de Usuários")]
        [ProducesResponseType(typeof(UserModel), 201)]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserModel user)
        {
            var createdUser = await _userBusiness.CreateUserAsync(user);
            return CreatedAtRoute("GetUserById", new { id = createdUser.Id }, createdUser);
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="id">Identificador único do usuário.</param>
        /// <param name="user">Dados do usuário atualizado.</param>
        /// <returns>No Content (204) se a atualização for bem-sucedida. Caso contrário, NotFound (404).</returns>
        [HttpPut("{id}")]
        [Tags("Atualização de Usuários")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUserAsync(string id, [FromBody] UserModel user)
        {
            if (id != user.Id)
            {
                return BadRequest("ID da URL deve corresponder ao ID do usuário no corpo da requisição.");
            }

            var updatedUser = await _userBusiness.UpdateUserAsync(id, user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Exclui um usuário.
        /// </summary>
        /// <param name="id">Identificador único do usuário.</param>
        /// <returns>No Content (204) se a exclusão for bem-sucedida. Caso contrário, NotFound (404).</returns>
        [HttpDelete("{id}")]
        [Tags("Exclusão de Usuários")]

        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            await _userBusiness.DeleteUserAsync(id);
            return NoContent();
        }
    }
}