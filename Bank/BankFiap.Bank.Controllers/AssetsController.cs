using Microsoft.AspNetCore.Mvc;
using Bank.BankFiap.Bank.Repository;
using Bank.BankFiap.Bank.Interface;
using Microsoft.AspNetCore.Authorization;
using Bank.BankFiap.Bank.DTO;
using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Controllers
{
    public class AssetsController : ControllerBase
    {
        private IAsset _assetRepository;
        private readonly ILogger<AssetsController> _logger;
        public AssetsController(IAsset assetRepository, ILogger<AssetsController> logger)
        {
            _assetRepository = assetRepository;
            _logger = logger;
        }

        [HttpPost("add-asset")]
        public IActionResult Add([FromBody] AssetDTO asset)
        {
            try
            {
                _assetRepository.Add(new Asset(asset));
                return Ok("Ativo adicionado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar adicionar ativo");
                return StatusCode(500, "Erro interno ao tentar adicionar ativo");
            }
        }

        [HttpGet("get-asset/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var asset = _assetRepository.GetById(id);
                if (asset == null)
                    return NotFound("Ativo não encontrado");
                return Ok(asset);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter ativo");
                return StatusCode(500, "Erro interno ao tentar obter ativo");
            }
        }

        [HttpGet("get-assets")]
        public IActionResult GetAssets()
        {
            try
            {
                var asset = _assetRepository.GetAll();
                if (asset == null)
                    return NotFound("Ativos não encontrados");
                return Ok(asset);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter ativos");
                return StatusCode(500, "Erro interno ao tentar obter ativos");
            }
        }

        [HttpGet("get-assets-by-type/{type}")]
        public IActionResult GetAssetsByType(int type)
        {
            try
            {
                var assets = _assetRepository.GetAssetsByType(type);
                return Ok(assets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter ativos por tipo");
                return StatusCode(500, "Erro interno ao tentar obter ativos por tipo");
            }
        }

        [HttpPut("update-asset")]
        public IActionResult Update([FromBody] AssetDTO asset)
        {
            try
            {
                _assetRepository.Update(new Asset(asset));
                return Ok("Ativo atualizado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar atualizar ativo");
                return StatusCode(500, "Erro interno ao tentar atualizar ativo");
            }
        }

        [HttpDelete("delete-asset/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _assetRepository.Delete(id);
                return Ok("Ativo excluído com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar excluir ativo");
                return StatusCode(500, "Erro interno ao tentar excluir ativo");
            }
        }
    }
}
