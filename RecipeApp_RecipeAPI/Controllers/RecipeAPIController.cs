using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Models.Dto;
using RecipeApp_RecipeAPI.Repository.IRepository;
using System.Net;

namespace RecipeApp_RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/recipe")]
    public class RecipeAPIController: ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IRecipeRepository _dbRecipe;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public RecipeAPIController(ApplicationDbContext db, IRecipeRepository dbRecipe, IMapper mapper)
        {
            _db = db;
            _dbRecipe = dbRecipe;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<APIResponse>> GetRecipe()
        //{
        //    try
        //    {
        //        await _db.Recipes.Include(p => p.Cook).Include(p => p.Locale).ToListAsync();
        //        IEnumerable<Recipe> recipeList = await _dbRecipe.GetAllAsync();
        //        _response.Result = _mapper.Map<List<RecipeDTO>>(recipeList);
        //        _response.StatusCode = HttpStatusCode.OK;
        //        _response.IsSuccess = true;
        //        return _response;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessage = new List<string> { ex.Message };
        //        throw;
        //    }
        //}

        public async Task<ActionResult<List<APIResponse>>> GetRecipe()
        {
            await _db.Recipes.Include(p => p.Cook).Include(p => p.Locale).ToListAsync();
            var recipeList = await _dbRecipe.GetAllAsync();
            _response.Result = _mapper.Map<List<RecipeDTO>>(recipeList);
            _response.StatusCode = HttpStatusCode.OK;
            var responseList = new List<APIResponse>() { };
            responseList.Add(_response);
            return responseList;
        }



        [HttpGet("id", Name = "GetRecipe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       
        public async Task<ActionResult<APIResponse>> GetRecipe(string id)
        {
            if (id == "0")
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                return _response;
            }

            var recipe = await _db.Recipes
                                  .Include(p => p.Locale)
                                  .Include(p => p.Cook)
                                  .FirstOrDefaultAsync(p => p.Id == id);
            if (recipe == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                return _response;
            }

            _response.Result = _mapper.Map<RecipeDTO>(recipe);
            _response.StatusCode = HttpStatusCode.OK;
            return _response;
        }





        [HttpDelete]
        public async Task<ActionResult<APIResponse>> DeleteRecipe(string id)
        {
            try
            {
                if (id == "0")
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var recipe = await _dbRecipe.GetAsync(u => u.Id == id);
                if (recipe == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Invalid input" };
                    return NotFound(_response);
                }
                await _dbRecipe.RemoveAsync(recipe);
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
        //public async Task<ActionResult<APIResponse>> UpdateRecipe(int id, [FromBody] RecipeUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.VillaNo)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var recipe = _mapper.Map<Recipe>(updateDTO);
        //        await _dbRecipe.UpdateAsync(recipe);
        //        _response.Result = _mapper.Map<RecipeUpdateDTO>(recipe);
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
        public async Task<ActionResult<APIResponse>> CreateRecipe([FromBody] RecipeCreateDTO createDTO)
        {
            try
            {
                if(createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "No Input provided" };
                    return _response;
                }
                var recipe = _mapper.Map<Recipe>(createDTO);
                await _dbRecipe.CreateAsync(recipe);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<RecipeDTO>(recipe);
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
