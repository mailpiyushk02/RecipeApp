using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Models.Dto;
using RecipeApp_RecipeAPI.Repository.IRepository;
using System.Net;

namespace RecipeApp_RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/recipeType")]
    public class RecipeTypeAPIController : ControllerBase
    {
        private readonly IRecipeTypeRepository _dbRecipeType;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public RecipeTypeAPIController(IRecipeTypeRepository dbRecipeType,IMapper mapper)
        {
            _dbRecipeType = dbRecipeType;
            _mapper = mapper;
            _response = new APIResponse();
        }




        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetRecipeType()
        {
            try
            {
                IEnumerable<RecipeType> recipeTypeList = await _dbRecipeType.GetAllAsync();
                _response.Result = _mapper.Map<List<RecipeTypeDTO>>(recipeTypeList);
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
        [HttpGet("id", Name = "GetRecipeType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetRecipeType(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var recipeType = await _dbRecipeType.GetAsync(u => u.Id == id);
                if (recipeType == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                _response.Result = _mapper.Map<RecipeTypeDTO>(recipeType);
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
        [HttpDelete]
        public async Task<ActionResult<APIResponse>> DeleteRecipeType(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var recipeType = await _dbRecipeType.GetAsync(u => u.Id == id);
                if (recipeType == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Invalid input" };
                    return NotFound(_response);
                }
                await _dbRecipeType.RemoveAsync(recipeType);
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
        //public async Task<ActionResult<APIResponse>> UpdateRecipeType(int id, [FromBody] RecipeTypeUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.VillaNo)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var recipeType = _mapper.Map<RecipeType>(updateDTO);
        //        await _dbRecipeType.UpdateAsync(recipeType);
        //        _response.Result = _mapper.Map<RecipeTypeUpdateDTO>(recipeType);
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





        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] RecipeTypeCreateDTO createDTO)
        {
            try
            {
                if(createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Incorrect Input" };
                    return _response;
                }
                var recipeType = _mapper.Map<RecipeType>(createDTO);
                await _dbRecipeType.CreateAsync(recipeType);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<RecipeTypeDTO>(recipeType);
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
    }
}
