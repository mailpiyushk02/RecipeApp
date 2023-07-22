using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Models.Dto;
using RecipeApp_RecipeAPI.Repository.IRepository;
using System.Net;

namespace RecipeApp_RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/CookFollower")]
    public class CookFollowerAPIController : ControllerBase
    {
        private readonly ICookFollowerRespository _dbCookFollower;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public CookFollowerAPIController(ICookFollowerRespository dbCookFollower, IMapper mapper)
        {
            _dbCookFollower = dbCookFollower;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetCookFollower()
        {
            try
            {
                IEnumerable<CookFollower> cookFollowerList = await _dbCookFollower.GetAllAsync();
                _response.Result = _mapper.Map<List<CookFollowerDTO>>(cookFollowerList);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
                throw;
            }
        }
        [HttpGet("id", Name = "GetCookFollower")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetCookFollower(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var cookFollower = await _dbCookFollower.GetAsync(u => u.Id == id);
                if (cookFollower == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                _response.Result = _mapper.Map<CookFollowerDTO>(cookFollower);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return _response;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { e.Message };
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateCookFollower([FromBody] CookFollowerCreateDTO createDTO)
        {
            try
            {
                if(createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Incorrect Input" };
                    return _response;
                }
                var cookFollower = _mapper.Map<CookFollower>(createDTO);
                await _dbCookFollower.CreateAsync(cookFollower);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<CookFollowerDTO>(cookFollower);
                _response.IsSuccess = true;
                return _response;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { e.Message };
                throw;
            }
            
        }






        [HttpDelete]
        public async Task<ActionResult<APIResponse>> DeleteCookFollower(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var cookFollower = await _dbCookFollower.GetAsync(u => u.Id == id);
                if (cookFollower == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Invalid input" };
                    return NotFound(_response);
                }
                await _dbCookFollower.RemoveAsync(cookFollower);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { "Something went wrong.\n" + e.Message };
                throw;
            }
        }
        //[HttpPut]
        //public async Task<ActionResult<APIResponse>> UpdateCookFollower(int id, [FromBody] CookFollowerUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.VillaNo)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var cookFollower = _mapper.Map<CookFollower>(updateDTO);
        //        await _dbCookFollower.UpdateAsync(cookFollower);
        //        _response.Result = _mapper.Map<CookFollowerUpdateDTO>(cookFollower);
        //        _response.IsSuccess = true;
        //        return Ok(_response);
        //    }
        //    catch (Exception e)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessage = new List<string> { e.Message };
        //        throw;
        //    }
        //}
    }
}
