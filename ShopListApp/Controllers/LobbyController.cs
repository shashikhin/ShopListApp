using Microsoft.AspNetCore.Mvc;
using ShopListApp.Abstractions;
using ShopListApp.Service.Abstractions;
using ShopListApp.Domain.Models;

namespace ShopListApp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LobbyController : ControllerBase
    {
        private readonly ILobbyRepository _lobbyRepository;
        private readonly ILobbyService _lobbyService;
        public LobbyController(ILobbyRepository lobbyRepo, 
                               ILobbyService lobbyService)
        {
            _lobbyRepository = lobbyRepo;
            _lobbyService = lobbyService;
        }

        [HttpGet("get-lobby")]
        public IActionResult GetLobbyById(int lobbyId)
        {
            var lobby = _lobbyRepository.GetLobby(lobbyId);

            if (lobby == null)
                return BadRequest(ModelState); 

            return Ok(lobby);
        }

        [HttpGet("get-lobbies")]
        public IActionResult GetLobbys()
        {
            var lobbies = _lobbyRepository.GetLobbys();

            if (lobbies == null)
                return BadRequest(ModelState);

            return Ok(lobbies);
        }

        [HttpGet("get-lobby-users")]
        public IActionResult GetLobbyUsers([FromQuery] int lobbyId)
        {
            var users = _lobbyService.GetLobbyUsers(lobbyId);

            if (users == null)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpGet("get-lobby-products")]
        public IActionResult GetLobbyProducts([FromQuery] int lobbyId)
        {
            var products = _lobbyService.GetLobbyProducts(lobbyId);

            if (products == null)
                return BadRequest(ModelState);

            return Ok(products);
        }

        [HttpPost("create-lobby")]
        public IActionResult CreateLobby([FromQuery] int userId)
        {

            if (!_lobbyRepository.CreateLobby(userId))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete("delete-lobby")]
        public IActionResult DeleteLobby(int lobbyId)
        {

            if (!_lobbyRepository.DeleteLobby(lobbyId))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("update-lobby")]
        public IActionResult UpdateLobby([FromBody] Lobby lobby)
        {

            if (!_lobbyRepository.UpdateLobby(lobby))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("add-product-to-lobby")]
        public IActionResult AddProductToLobby([FromQuery] int lobbyId, int productId)
        {
            if (!_lobbyService.AddProductToLobby(lobbyId, productId))
            {
                ModelState.AddModelError("", "Something went wrong while adding product to lobby");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("add-user-to-lobby")]
        public IActionResult AddUserToLobby([FromQuery] int lobbyId, int userId)
        {
            if (!_lobbyService.AddUserToLobby(lobbyId, userId))
            {
                ModelState.AddModelError("", "Something went wrong while adding user to lobby");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
