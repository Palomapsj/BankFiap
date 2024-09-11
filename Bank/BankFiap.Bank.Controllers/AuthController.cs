using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Interface;
using BankFiap.Bank.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Bank.BankFiap.Bank.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {

        private IUser _usuarioRepository;
        private readonly ITokenService _tokenService;

        public AuthController(IUser usuarioRepository,
            ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult AuthenticationAsync([FromBody] UserDTO auth)
        {
            var user = _usuarioRepository.GetUserByNameAndPassword(auth.Name, auth.PasswordHash);

            if (user == null)
            {
                return NotFound(new { msg = "Usuario ou senha inválidos" });
            }

            var token = _tokenService.GetToken(user);

            user.PasswordHash = null;

            return Ok(new
            {
                User = user,
                Token = token
            });
        }
    }
}
