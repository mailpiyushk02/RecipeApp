using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Models.Dto;
using RecipeApp_RecipeAPI.Repository.IRepository;
using System.Net;

namespace RecipeApp_RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/recipeReaction")]
    public class RecipeReactionAPIController : ControllerBase
    {
        private readonly IRecipeReactionRepository _dbRecipeReaction;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public RecipeReactionAPIController(IRecipeReactionRepository dbRecipeReaction,IMapper mapper)
        {
            _dbRecipeReaction = dbRecipeReaction;
            _mapper = mapper;
            _response = new APIResponse();
        }





        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetRecipeReaction()
        {
            try
            {
                IEnumerable<RecipeReaction> recipeReactionList = await _dbRecipeReaction.GetAllAsync();
                _response.Result = _mapper.Map<List<RecipeReactionDTO>>(recipeReactionList);
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
        [HttpGet("id", Name = "GetRecipeReaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetRecipeReaction(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var recipeReaction = await _dbRecipeReaction.GetAsync(u => u.Id == id);
                if (recipeReaction == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                _response.Result = _mapper.Map<RecipeReactionDTO>(recipeReaction);
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
        public async Task<ActionResult<APIResponse>> DeleteRecipeReaction(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var recipeReaction = await _dbRecipeReaction.GetAsync(u => u.Id == id);
                if (recipeReaction == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Invalid input" };
                    return NotFound(_response);
                }
                await _dbRecipeReaction.RemoveAsync(recipeReaction);
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
        //public async Task<ActionResult<APIResponse>> UpdateRecipeReaction(int id, [FromBody] RecipeReactionUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.VillaNo)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var recipeReaction = _mapper.Map<RecipeReaction>(updateDTO);
        //        await _dbRecipeReaction.UpdateAsync(recipeReaction);
        //        _response.Result = _mapper.Map<RecipeReactionUpdateDTO>(recipeReaction);
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
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] RecipeReactionCreateDTO createDTO)
        {
            try
            {
                if(createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Incorrect Input" };
                    return _response;
                }
                var recipeReaction = _mapper.Map<RecipeReaction>(createDTO);
                await _dbRecipeReaction.CreateAsync(recipeReaction);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<RecipeReactionDTO>(recipeReaction);
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
