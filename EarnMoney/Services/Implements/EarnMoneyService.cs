using AutoMapper;
using EarnMoney.Helpers.PathURL;
using EarnMoney.Helpers.RestSharp;
using EarnMoney.Helpers.Seriliazer;
using EarnMoney.Models.Entities;
using EarnMoney.Models.Requests.EarnMoney.Missions;
using EarnMoney.Models.Requests.EarnMoney.Withdraw;
using EarnMoney.Models.Responses.EarnMoney;
using EarnMoney.Models.Responses.EarnMoney.Missions;
using EarnMoney.Services.Interfaces;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.Xml;

namespace EarnMoney.Services.Implements
{
    public class EarnMoneyService : IEarnMoneyService
    {
        private readonly IDanaService danaService;
        private readonly IEarnMoneyUserService userService;
        private readonly IMapper mapper;
        private readonly ILogger<EarnMoneyService> logger;

        public EarnMoneyService(IDanaService danaService, IEarnMoneyUserService userService, IMapper mapper, ILogger<EarnMoneyService> logger)
        {
            this.danaService = danaService;
            this.userService = userService;
            this.mapper = mapper;
            this.logger = logger;
        }

        private Dictionary<string, object> CreateHeader(string token = "")
        {
            return new Dictionary<string, object>
                {
                    { "log-header", "I am the log request header." },
                    { "token", $"{token}" },
                    { "Content-Type", "application/x-www-form-urlencoded" },
                    { "Host", "admin.tgldy.xyz" },
                    { "Connection", "Keep-Alive" },
                    { "Accept-Encoding", "gzip" },
                    { "User-Agent", "okhttp/4.10.0" }
                };
        }

        public async Task<EarnMoneyGetMissionResponse> GetUserMissions(string deviceId)
        {
            try
            {
                var user = await userService.GetUserByDeviceId(deviceId);
                if (user == null) throw new Exception("User Not exist");
                var body = new EarnMoneyGetMissionRequest { GoogleId = user.GoogleId!, DeviceId = user.DeviceId!, Token = user.Token! };
                var response = await RestHelper.GetResponse<EarnMoneyGetMissionResponse>(EarnMoneyRoute.GetListMission, Method.Post, CreateHeader(user.Token!), body.ToString()!);
                if (response != null && response.Data != null && response.Data!.Data!.Count > 0) 
                {
                    response.Data.Data.ForEach(e => e.DeviceId = user.DeviceId!);
                    var missions = mapper.Map<List<EarnMoneyMissions>>(response.Data!.Data!);
                    await userService.AddOrUpdateUserMissions(user.DeviceId!, missions);
                }
                return response!.Data!;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<int> MissionStepOne(EarnMoneyUser user, EarnMoneyMissions missios)
        {
            try
            {
                var exist = await userService.GetUserByDeviceId(user.DeviceId!);
                if (exist == null) throw new Exception("User Not exist");
                var body = new EarnMoneyMissionStartRequest { MissionId = missios.MissionId!, GoogleId = user.GoogleId!, DeviceId = user.DeviceId!, Token = user.Token! };
                var response = await RestHelper.GetResponse(EarnMoneyRoute.MissionStepOne, Method.Post, CreateHeader(user.Token!), body.ToString());
                //logger.LogInformation($"MissionStepOne => \n{response.Content!}");
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> MissionStepTwo(EarnMoneyUser user, EarnMoneyMissions missios)
        {
            try
            {
                var exist = await userService.GetUserByDeviceId(user.DeviceId!);
                if (exist == null) throw new Exception("User Not exist");
                var body = new EarnMoneyMissionStartRequest { Urut=1, MissionId = missios.MissionId!, GoogleId = user.GoogleId!, DeviceId = user.DeviceId!, Token = user.Token! };
                var response = await RestHelper.GetResponse(EarnMoneyRoute.MissionStepTwo, Method.Post, CreateHeader(user.Token!), body.ToString());
                //logger.LogInformation($"MissionStepTwo => \n{response.Content!}");
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> MissionStepThree(EarnMoneyUser user, EarnMoneyMissions missios)
        {
            try
            {
                var exist = await userService.GetUserByDeviceId(user.DeviceId!);
                if (exist == null) throw new Exception("User Not exist");
                var body = new EarnMoneyMissionStartRequest { MissionId = missios.MissionId! , DeviceId = user.DeviceId, Token = user.Token!, GoogleId= user.GoogleId!};
                var response = await RestHelper.GetResponse(EarnMoneyRoute.MissionStepThree, Method.Post, CreateHeader(user.Token!), body.ToString());
                //logger.LogInformation($"MissionStepThree => \n{response.Content!}");
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<EarnMoneyDoMissionResponse> MissionStepFour(EarnMoneyUser user, EarnMoneyMissions missios)
        {
            try
            {
                var exist = await userService.GetUserByDeviceId(user.DeviceId!);
                if (exist == null) throw new Exception("User Not exist");
                var body = new EarnMoneyMissionStartRequest { MissionId = missios.MissionId! , DeviceId = user.DeviceId,GoogleId = user.GoogleId!, Token = user.Token!, };
                var response = await RestHelper.GetResponse<EarnMoneyDoMissionResponse>(EarnMoneyRoute.MissionStepFour, Method.Post, CreateHeader(user.Token!), body.ToString());
                //logger.LogInformation($"MissionStepFour => \n{response.Content!}");
                return response.Data!;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<EarnMonyeCheckMissionResponse> CheckCompleteMission(string deviceId)
        {
            try
            {
                var exist = await userService.GetUserByDeviceId(deviceId!);
                if (exist == null) throw new Exception("User Not exist");
                var body = new EarnMonyeCheckMissionRequest { DeviceId = exist.DeviceId,Token = exist.Token!, GoogleId = exist.GoogleId! };
                var response = await RestHelper.GetResponse<EarnMonyeCheckMissionResponse>(EarnMoneyRoute.CheckCompleteMission, Method.Post, CreateHeader(exist.Token!), body.ToString());
                if(response != null && response.Data != null && response.Data!.Code == 200 && response.Data!.Data != null )
                {
                    int mission = response.Data!.Data.Condistion;
                    int complete = response.Data!.Data.Complete;
                    await userService.UpdateMissionUser(exist.DeviceId!, mission, complete);
                }
                return response!.Data!;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> AutoCheckCompleteMission()
        {
            try
            {
                var users = await userService.GetAllUsers();
                foreach(var u in users.OrderByDescending(e => e.Created))
                {
                    await CheckCompleteMission(u.DeviceId!);
                }
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EarnMoneyDoMissionResponse> DoAutoMission(string deviceId, string missionId, int success)
        {
            try
            {
                var user = await userService.GetUserByDeviceId(deviceId);
                if (user == null) throw new Exception("User null");
                var missions = await userService.GetMissionById(deviceId, missionId);
                if (missions == null) throw new Exception("Mission null");
                int time = 1;
                if(success == 0)
                {
                    time = 1;
                }else if(success ==1 || success == 3 || success == 5 || success == 6)
                {
                    time = 2;
                }else if(success == 2)
                {
                    time = 5;
                }else if(success == 7)
                {
                    time = 9;
                }else if(success == 8)
                {
                    time = 7;
                }else if(success == 9)
                {
                    time = 3;
                }else
                {
                    time = 10;
                }
                await MissionStepOne(user, missions);
                await Task.Delay(1000 * time);
                await MissionStepTwo(user, missions);
                await Task.Delay(1000 * time);
                await MissionStepThree(user, missions);
                await Task.Delay(1000 * time);
                var result = await MissionStepFour(user, missions);
                await Task.Delay(1000 * time);
                await CheckCompleteMission(user.DeviceId!);
                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EarnMoneyBaseResponse> DoWithdrawUser(string deviceId, string noHp)
        {
            try
            {
                var user = await userService.GetUserByDeviceId(deviceId);
                if (user == null) throw new Exception("User null");
                var noDana = await danaService.GetMasterDanaByNomor(noHp);
                if(noDana == null)
                {
                    MasterDana masterDana = new MasterDana
                    {
                        Nama = "Random " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        NoDana = noHp
                    };
                    await danaService.InsertMasterDana(masterDana);
                }
                var body = new EarnMoneyWithdrawRequest
                {
                    GoogleId = user.GoogleId,
                    DeviceId = user.DeviceId,
                    Token = user.Token,
                    NoDana = noHp,
                };
                var response = await RestHelper.GetResponse<EarnMoneyBaseResponse>(EarnMoneyRoute.Withdraw, Method.Post, CreateHeader(user.Token!), body.ToString());
                logger.LogInformation($"Withdraw => \n{response.Content!}");
                user.NoHP = noHp;
                await userService.SetNoHPUser(user.DeviceId!, noHp);
                return response.Data!;

            }
            catch (Exception)
            {

                throw;
            }
        }
        private async Task<int> DoFastWithdraw(RestRequest req)
        {
            try
            {
                var client = new RestClient(EarnMoneyRoute.BaseUrl, configureSerialization: s => s.UseNewtonsoftJson());
                var response = await client.ExecuteAsync<EarnMoneyBaseResponse>(req);
                logger.LogInformation(response.Content!.ToString());
                return 1;
            }
            catch (Exception ex)
            {
                logger.LogError($"DoFastWithdraw => \n{ex.Message}");
                return 0;
            }
        }
        public async Task<int> DoAutoWithdrawUser(string noHp)
        {
            try
            {
                var users = await userService.GetAllUsers();
                var listTask = new List<Task>();
                var listBody = new List<EarnMoneyWithdrawRequest>();
                foreach (var user in users.Where(e => e.MissionToday >= 3 && e.MissionToday == e.FinishToday && e.IsWD == false).Take(10).ToList())
                {
                    logger.LogInformation(user.ToString());
                    listBody.Add( new EarnMoneyWithdrawRequest
                    {
                        GoogleId = user.GoogleId,
                        DeviceId = user.DeviceId,
                        Token = user.Token,
                        NoDana = noHp,
                    });
                }

                //List<RestRequest> requests = new List<RestRequest>();
                foreach (var b in listBody)
                {
                    var req = new RestRequest(EarnMoneyRoute.Withdraw, Method.Post);
                    req.AddBody(b.ToString(), ContentType.FormUrlEncoded);
                    foreach (var i in CreateHeader(b.Token!))
                    {
                        req.AddOrUpdateHeader(i.Key, i.Value.ToString()!);
                    }
                    //requests.Add(req);
                    listTask.Add(Task.Run(async () => {
                        await DoFastWithdraw(req);
                    }));

                }
                if (listTask.Count > 0)
                {
                    logger.LogInformation($"Run Users : {listTask.Count}");
                    await Task.WhenAll(listTask);
                    return 0;
                }
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError($"DoAuto => \n{ex.Message}");
                throw;
            }
        }

        
        //payee_documentType=&payee_documentType2=&payee_documentType3=&payee_documentId=&payee_documentId2=&payee_documentId3=&bank=DANA&pay_account=083894826886&real_name=tesg&money=15000.0&jf=30000&id=187&channel=jfq_offer&version=1.0.1.5&versionCode=10015&deviceId=04179e71f694553c&randomUUID=&token=d8518a81fd071e35428875a5fd26cbdc&is_vpn=false&is_developer=false&cell_mcc=510&gaid=8fb2cd04-00c5-4925-9f35-1a4aab0c61de
        public async Task DoAutoAllMissions(string deviceId)
        {
            try
            {
                var user = await userService.GetUserByDeviceId(deviceId);
                if (user == null) throw new Exception("User null");
                int success = 0;
                var missions = await GetUserMissions(deviceId);
                int currentMissions = 0;
                List<string> filtrmission = new List<string>();
                var listMissions = missions.Data!.OrderBy(e => e.Type != 10).Select(m => m.MissionId!).ToList();
                var priorMissions = await userService.GetPriorityMission();
                await RestHelper.SendText($"Memulai Misi User : {deviceId!}");
                if(listMissions.Count > 0)
                {
                    foreach (var p in priorMissions)
                    {

                        var pe = listMissions.FirstOrDefault(e => e == p.MissionId);
                        if(pe != null && !string.IsNullOrEmpty(pe))
                        {
                            try
                            {
                                currentMissions++;
                                logger.LogInformation($"Do Priority Missions : {currentMissions} of {listMissions.Count}");
                                var m1 = await DoAutoMission(deviceId, pe, success);
                                if (m1 != null && m1.Data != null && m1.Data!.Status == 1)
                                {
                                    success++;
                                    logger.LogInformation($"Mision : {currentMissions} Success");
                                    await RestHelper.SendText($"Misi User : {deviceId!} {success} Success");
                                    await userService.AddOrUpdatePriorityMission(pe, true);
                                }
                                else
                                {
                                    await userService.AddOrUpdatePriorityMission(pe, false);
                                }
                                if (success >= 3)
                                {
                                    throw new Exception("Sukses 3 Mission");
                                }
                                logger.LogInformation("===============================");
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message == "Sukses 3 Mission")
                                {
                                    logger.LogInformation("==============Selesai 3 Misi, waktunya withdraw=================");
                                    await Task.Delay(2000);
                                    var rrr = await CheckCompleteMission(deviceId);
                                    if(rrr != null && rrr.Data != null && rrr.Code == 200 && rrr.Data.Condistion == rrr.Data.Complete)
                                    {
                                        await RestHelper.SendText($"Misi User : {deviceId!} Sukses, Waktunya WD");
                                    }
                                    throw new Exception(ex.Message);
                                }
                            }

                            listMissions.Remove(p.MissionId!);
                        }
                    }
                }
                
                foreach (var m in listMissions)
                {
                    try
                    {
                        currentMissions++;
                        logger.LogInformation($"Do Missions : {currentMissions} of {listMissions.Count}");
                        var m1 = await DoAutoMission(deviceId, m, success);
                        if(m1 != null && m1.Data != null && m1.Data!.Status == 1)
                        {
                            success++;
                            logger.LogInformation($"Mision : {currentMissions} Success");
                            await RestHelper.SendText($"Misi User : {deviceId!} {success} Success");
                            await userService.AddOrUpdatePriorityMission(m, true);
                        }
                        //else
                        //{
                        //    await userService.AddOrUpdatePriorityMission(m, false);
                        //}
                        if (success >= 3)
                        {
                            throw new Exception("Sukses 3 Mission");
                        }
                        logger.LogInformation("===============================");
                    }
                    catch (Exception ex)
                    {
                        if(ex.Message == "Sukses 3 Mission")
                        {
                            logger.LogInformation("==============Selesai 3 Misi, waktunya withdraw=================");
                            await Task.Delay(2000);
                            var rrr = await CheckCompleteMission(deviceId);
                            if (rrr != null && rrr.Data != null && rrr.Code == 200 && rrr.Data.Condistion == rrr.Data.Complete)
                            {
                                await RestHelper.SendText($"Misi User : {deviceId!} Sukses, Waktunya WD");
                            }
                            throw new Exception(ex.Message);
                        }
                        else
                        {
                            logger.LogError(ex.Message);
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task StartNewUser(string deviceId, string googleId, string token)
        {
            try
            {
                var u = await userService.InsertUser(new EarnMoneyUser { DeviceId = deviceId, GoogleId = googleId, Token = token });
                if (u != 1) throw new Exception("gagal buat user");
                await RestHelper.SendText($"User baru ditambahkan, ID : {deviceId!}");
                await DoAutoAllMissions(deviceId);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"StartNewUser => \n{ex.Message}");
                await RestHelper.SendText($"Insert User : {deviceId!} Gagal\n{ex.Message}");
            }
        }
        public async Task ContinueMissionById(string deviceId)
        {
            try
            {
                await DoAutoAllMissions(deviceId);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
