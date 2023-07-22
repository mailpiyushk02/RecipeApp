using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Models.Dto;
using RecipeApp_RecipeAPI.Repository.IRepository;
using System.Net;

namespace RecipeApp_RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/recipeInstruction")]
    public class RecipeInstructionAPIController : ControllerBase
    {
        private readonly IRecipeInstructionRespository _dbRecipeInstruction;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public RecipeInstructionAPIController(IRecipeInstructionRespository dbRecipeInstruction,IMapper mapper)
        {
            _dbRecipeInstruction = dbRecipeInstruction;
            _mapper = mapper;
            _response = new APIResponse();
        }





        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetRecipeInstruction()
        {
            try
            {
                IEnumerable<RecipeInstruction> recipeInstructionList = await _dbRecipeInstruction.GetAllAsync();
                _response.Result = _mapper.Map<List<RecipeInstructionDTO>>(recipeInstructionList);
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
        [HttpGet("id", Name = "GetRecipeInstruction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetRecipeInstruction(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var recipeInstruction = await _dbRecipeInstruction.GetAsync(u => u.Id == id);
                if (recipeInstruction == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                _response.Result = _mapper.Map<RecipeInstructionDTO>(recipeInstruction);
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
        public async Task<ActionResult<APIResponse>> DeleteRecipeInstruction(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var recipeInstruction = await _dbRecipeInstruction.GetAsync(u => u.Id == id);
                if (recipeInstruction == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Invalid input" };
                    return NotFound(_response);
                }
                await _dbRecipeInstruction.RemoveAsync(recipeInstruction);
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
        //public async Task<ActionResult<APIResponse>> UpdateRecipeInstruction(int id, [FromBody] RecipeInstructionUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.VillaNo)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var recipeInstruction = _mapper.Map<RecipeInstruction>(updateDTO);
        //        await _dbRecipeInstruction.UpdateAsync(recipeInstruction);
        //        _response.Result = _mapper.Map<RecipeInstructionUpdateDTO>(recipeInstruction);
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
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] RecipeInstructionCreateDTO createDTO)
        {
            try
            {
                if(createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Incorrect Input" };
                    return _response;
                }
                var recipeInstruction = _mapper.Map<RecipeInstruction>(createDTO);
                await _dbRecipeInstruction.CreateAsync(recipeInstruction);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<RecipeInstructionDTO>(recipeInstruction);
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
