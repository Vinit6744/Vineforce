using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VineforceShivamPratapSinghDb.Dto;
using VineforceShivamPratapSinghDb.Services;

namespace VineforceShivamPratapSinghDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateServices _stateServices;

        public StateController(IStateServices stateServices)
        {
            _stateServices = stateServices;
        }


        /// <summary>
        /// GetSateList
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSateList")]
        public List<StateDto> GetSateList()
        {
            return _stateServices.GetSateList().ToList();
        }


        /// <summary>
        /// PostStateData
        /// </summary>
        /// <returns></returns>
        [HttpPost("PostStateData")]
        public bool PostStateData(StatePostData stateDto)
        {
            return _stateServices.PostStateData(stateDto);
        }

        /// <summary>
        /// DeleteStateData
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{stateId}")]
        public bool DeleteStateData(int stateId)
        {
            return _stateServices.DeleteStateData(stateId);
        }

    }
}
