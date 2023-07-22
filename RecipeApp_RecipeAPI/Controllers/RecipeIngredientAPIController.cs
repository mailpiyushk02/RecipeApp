using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Models.Dto;
using RecipeApp_RecipeAPI.Repository.IRepository;
using System.Net;

namespace RecipeApp_RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/RecipeIngredient")]
    public class RecipeIngredientAPIController : ControllerBase
    {
        private readonly IRecipeIngredientRepository _dbRecipeIngredient;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public RecipeIngredientAPIController(IRecipeIngredientRepository dbRecipeIngredient,IMapper mapper)
        {
            _dbRecipeIngredient = dbRecipeIngredient;
            _mapper = mapper;
            _response = new APIResponse();
        }




        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetRecipeIngredient()
        {
            try
            {
                IEnumerable<RecipeIngredient> recipeIngredientList = await _dbRecipeIngredient.GetAllAsync();
                _response.Result = _mapper.Map<List<RecipeIngredientDTO>>(recipeIngredientList);
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
        [HttpGet("id", Name = "GetRecipeIngredient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetRecipeIngredient(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var recipeIngredient = await _dbRecipeIngredient.GetAsync(u => u.Id == id);
                if (recipeIngredient == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                _response.Result = _mapper.Map<RecipeIngredientDTO>(recipeIngredient);
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
        public async Task<ActionResult<APIResponse>> DeleteRecipeIngredient(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var recipeIngredient = await _dbRecipeIngredient.GetAsync(u => u.Id == id);
                if (recipeIngredient == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Invalid input" };
                    return NotFound(_response);
                }
                await _dbRecipeIngredient.RemoveAsync(recipeIngredient);
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
        //public async Task<ActionResult<APIResponse>> UpdateRecipeIngredient(int id, [FromBody] RecipeIngredientUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.VillaNo)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var recipeIngredient = _mapper.Map<RecipeIngredient>(updateDTO);
        //        await _dbRecipeIngredient.UpdateAsync(recipeIngredient);
        //        _response.Result = _mapper.Map<RecipeIngredientUpdateDTO>(recipeIngredient);
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
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] RecipeIngredientCreateDTO createDTO)
        {
            try
            {
                if(createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Incorrect Input" };
                    return _response;
                }
                var recipeIngredient = _mapper.Map<RecipeIngredient>(createDTO);
                await _dbRecipeIngredient.CreateAsync(recipeIngredient);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<RecipeIngredientDTO>(recipeIngredient);
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
