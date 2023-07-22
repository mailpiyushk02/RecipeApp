using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Models.Dto;
using RecipeApp_RecipeAPI.Repository.IRepository;
using System.Net;

namespace RecipeApp_RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/diet")]
    public class DietAPIController : ControllerBase
    {
        private readonly IDietRespository _dbDiet;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public DietAPIController(IDietRespository dbDiet,IMapper mapper)
        {
            _dbDiet = dbDiet;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetDiet()
        {
            try
            {
                IEnumerable<Diet> dietList = await _dbDiet.GetAllAsync();
                _response.Result = _mapper.Map<List<DietDTO>>(dietList);
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
        [HttpGet("id", Name = "GetDiet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetDiet(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var diet = await _dbDiet.GetAsync(u => u.Id == id);
                if (diet == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                _response.Result = _mapper.Map<DietDTO>(diet);
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
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] DietCreateDTO createDTO)
        {
            try
            {
                if(createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Incorrect Input" };
                    return _response;
                }
                var diet = _mapper.Map<Diet>(createDTO);
                await _dbDiet.CreateAsync(diet);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<DietDTO>(diet);
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
        public async Task<ActionResult<APIResponse>> DeleteDiet(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var diet = await _dbDiet.GetAsync(u => u.Id == id);
                if (diet == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Invalid input" };
                    return NotFound(_response);
                }
                await _dbDiet.RemoveAsync(diet);
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
        //public async Task<ActionResult<APIResponse>> UpdateDiet(int id, [FromBody] DietUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.VillaNo)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var diet = _mapper.Map<Diet>(updateDTO);
        //        await _dbDiet.UpdateAsync(diet);
        //        _response.Result = _mapper.Map<DietUpdateDTO>(diet);
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
