using Microsoft.AspNetCore.Mvc;
using Bank.BankFiap.Bank.Repository;
using Bank.BankFiap.Bank.Interface;
using Microsoft.AspNetCore.Authorization;
using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Controllers
{
    public class UserController : ControllerBase
    {
        private IUser _usuarioRepository;
        private readonly ILogger<UserController> _logger;
        public UserController(IUser usuarioRepository, ILogger<UserController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        [HttpPost("add-user")]
        public IActionResult Add([FromBody] UserDTO user)
        {
            try
            {
                _usuarioRepository.Add(new User(user));
                return Ok("Usuário adicionado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar adicionar usuário");
                return StatusCode(500, "Erro interno ao tentar adicionar usuário");
            }
        }

        [HttpGet("get-user/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var user = _usuarioRepository.GetById(id);
                if (user == null)
                    return NotFound("Usuário não encontrado");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter usuário");
                return StatusCode(500, "Erro interno ao tentar obter usuário");
            }
        }

        [HttpGet("get-user-by-email/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            try
            {
                var user = _usuarioRepository.GetUserByEmail(email);
                if (user == null)
                    return NotFound("Usuário não encontrado");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter usuário por email");
                return StatusCode(500, "Erro interno ao tentar obter usuário por email");
            }
        }

        [HttpPut("update-user")]
        public IActionResult Update([FromBody] UserDTO user)
        {
            try
            {
                _usuarioRepository.Update(new User(user));
                return Ok("Usuário atualizado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar atualizar usuário");
                return StatusCode(500, "Erro interno ao tentar atualizar usuário");
            }
        }

        [HttpDelete("delete-user/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.Delete(id);
                return Ok("Usuário excluído com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar excluir usuário");
                return StatusCode(500, "Erro interno ao tentar excluir usuário");
            }
        }

    }
}

