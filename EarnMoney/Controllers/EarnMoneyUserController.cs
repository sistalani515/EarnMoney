using EarnMoney.Helpers.Seriliazer;
using EarnMoney.Models.Entities;
using EarnMoney.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EarnMoney.Controllers
{
    public class EarnMoneyUserController : BaseController
    {
        private readonly IEarnMoneyUserService service;
        private readonly IEarnMoneyService earnMoney;
        private readonly ILogger<EarnMoneyUserController> logger;

        public EarnMoneyUserController(IEarnMoneyUserService service, IEarnMoneyService earnMoney, ILogger<EarnMoneyUserController> logger)
        {
            this.service = service;
            this.earnMoney = earnMoney;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await service.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetUserByDeviceId([FromQuery] string deviceId)
        {
            try
            {
                var result = await service.GetUserByDeviceId(deviceId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetUserByGoogleId([FromQuery] string googleId)
        {
            try
            {
                var result = await service.GetUserByGoogleId(googleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser([FromBody] EarnMoneyUser user)
        {
            try
            {
                var result = await service.InsertUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserMissions([FromQuery] string deviceId)
        {
            try
            {
                var result = await earnMoney.GetUserMissions(deviceId);
                logger.LogInformation(result.ToString());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DoAutoMission([FromQuery] string deviceId, string missionId)
        {
            try
            {
                var result = await earnMoney.DoAutoMission(deviceId, missionId, 0);
                logger.LogInformation(result.ToString());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Withdraw([FromQuery] string deviceId, string noHp)
        {
            try
            {
                var result = await earnMoney.DoWithdrawUser(deviceId, noHp);
                logger.LogInformation(result.ToString());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewUserAutoMission([FromQuery] string parambody)
        {
            try
            {
                logger.LogInformation($"New User Inserted => \n{parambody}");
                var r = EarnMoneyUser.ParseFromRaw(parambody);
                await Task.Delay(1000);
                _ = earnMoney.StartNewUser(r.DeviceId!, r.GoogleId!, r.Token!);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ContinueMissions([FromQuery] string deviceId)
        {
            try
            {
                await Task.Delay(1000);
                _ = earnMoney.ContinueMissionById(deviceId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> CheckCompleteMission([FromQuery] string deviceId)
        {
            try
            {
                await Task.Delay(1000);
                _ = earnMoney.CheckCompleteMission(deviceId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AutoCheckCompleteMission()
        {
            try
            {
                await Task.Delay(1000);
                _ = earnMoney.AutoCheckCompleteMission();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AutoWDUsers([FromQuery] string noHP)
        {
            try
            {
                await Task.Delay(1000);
                _ = earnMoney.DoAutoWithdrawUser(noHP);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
