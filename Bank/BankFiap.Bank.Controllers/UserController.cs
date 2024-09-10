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


        [HttpPost("Register-User")]
        public IActionResult AddUser(UserDTO userDTO)
        {
            try
            {
                _logger.LogInformation("Tentando cadastrar usuario");
                _usuarioRepository.Add(new User(userDTO));
                _logger.LogInformation("Usuario cadastrado com sucesso");

                return Ok("Usuario cadastrado com sucesso");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar usuário no banco de dados");
                return StatusCode(500, "Erro interno ao tentar cadastrar usuário");
            }
        }

            [HttpGet("Get-user-byId/{id}")]
            public IActionResult GetUserById(int id)
            {
                try
                {
                    _logger.LogInformation("Buscando usuario");
                    return Ok(_usuarioRepository.GetById(id));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao tentar obter usuário no banco de dados");
                    return StatusCode(500, "Erro interno ao tentar obter usuário");
                }
            }

             [HttpPost("UpdateUser")]
             public IActionResult UpdateUser(UserDTO userDTO)
             {
                 try
                 {
                     _logger.LogInformation("Tentando cadastrar usuario");
                     _usuarioRepository.Update(new User(userDTO));
                     _logger.LogInformation("Usuario cadastrado com sucesso");

                     return Ok("Usuario cadastrado com sucesso");
                 }
                 catch (Exception ex)
                 {
                     _logger.LogError(ex, "Erro ao tentar cadastrar usuário no banco de dados");
                     return StatusCode(500, "Erro interno ao tentar cadastrar usuário");
                 }
             }
    }
    }

