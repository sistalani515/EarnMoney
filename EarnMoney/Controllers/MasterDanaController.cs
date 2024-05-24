using EarnMoney.Models.Entities;
using EarnMoney.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EarnMoney.Controllers
{
    public class MasterDanaController : BaseController
    {
        private readonly IDanaService service;

        public MasterDanaController(IDanaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMasterDana()
        {
            try
            {
                var result = await service.GetAllMasterDana();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetMasterDanaByNoHP([FromQuery] string noHp)
        {
            try
            {
                var result = await service.GetMasterDanaByNomor(noHp);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertDana([FromBody] MasterDana master)
        {
            try
            {
                var result = await service.InsertMasterDana(master);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



    }
}
