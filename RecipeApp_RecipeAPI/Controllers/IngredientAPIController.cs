using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Models.Dto;
using RecipeApp_RecipeAPI.Repository.IRepository;
using System.Net;

namespace RecipeApp_RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/ingredient")]
    public class IngredientAPIController : ControllerBase
    {
        private readonly IIngredientRepository _dbIngredient;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public IngredientAPIController(IIngredientRepository dbIngredient,IMapper mapper)
        {
            _dbIngredient = dbIngredient;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetIngredient()
        {
            try
            {
                IEnumerable<Ingredient> ingredientList = await _dbIngredient.GetAllAsync();
                _response.Result = _mapper.Map<List<List<IngredientDTO>>>(ingredientList);
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
        [HttpGet("id", Name = "GetIngredient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetIngredient(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var ingredient = await _dbIngredient.GetAsync(u => u.Id == id);
                if (ingredient == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                _response.Result = _mapper.Map<IngredientDTO>(ingredient);
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
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] IngredientCreateDTO createDTO)
        {
            try
            {
                if(createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Incorrect Input" };
                    return _response;
                }
                var ingredient = _mapper.Map<Ingredient>(createDTO);
                await _dbIngredient.CreateAsync(ingredient);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<IngredientDTO>(ingredient);
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
        public async Task<ActionResult<APIResponse>> DeleteIngredient(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var ingredient = await _dbIngredient.GetAsync(u => u.Id == id);
                if (ingredient == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Invalid input" };
                    return NotFound(_response);
                }
                await _dbIngredient.RemoveAsync(ingredient);
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
        //public async Task<ActionResult<APIResponse>> UpdateIngredient(int id, [FromBody] IngredientUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.VillaNo)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var ingredient = _mapper.Map<Ingredient>(updateDTO);
        //        await _dbIngredient.UpdateAsync(ingredient);
        //        _response.Result = _mapper.Map<IngredientUpdateDTO>(ingredient);
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
