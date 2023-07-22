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
    [Route("api/category")]
    public class CategoryAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ICategoryRepository _dbCategory;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public CategoryAPIController(ICategoryRepository dbCategory,IMapper mapper,ApplicationDbContext db)
        {
            _db = db;
            _dbCategory = dbCategory;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetCategory()
        {
            try
            {
                 _db.Categories.Include(p => p.Locale).ToList();
                IEnumerable<Category> categoryList = await _dbCategory.GetAllAsync();
                _response.Result = _mapper.Map<List<CategoryDTO>>(categoryList);
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
        [HttpGet("id", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetCategory(int id)
        {
            try
            {
                
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }

                var categoryList = await _db.Categories.Include(p => p.Locale).ToListAsync();
                Category category = null;
                foreach (var a in categoryList)
                {
                    if(a.Id == id)
                        category = a;
                }

                if (category == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }
                
                _response.Result = category;
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
        public async Task<ActionResult<APIResponse>> Category([FromBody] CategoryCreateDTO createDTO)
        {
            try
            {
                if(createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Incorrect Input" };
                    return _response;
                }
                var category = _mapper.Map<Category>(createDTO);
                await _dbCategory.CreateAsync(category);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<CategoryDTO>(category);
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
        public async Task<ActionResult<APIResponse>> DeleteCategory(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var category = await _dbCategory.GetAsync(u => u.Id == id);
                if (category == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Invalid input" };
                    return NotFound(_response);
                }
                await _dbCategory.RemoveAsync(category);
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
        //public async Task<ActionResult<APIResponse>> UpdateCategory(int id, [FromBody] CategoryUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.VillaNo)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var category = _mapper.Map<Category>(updateDTO);
        //        await _dbCategory.UpdateAsync(category);
        //        _response.Result = _mapper.Map<CategoryUpdateDTO>(category);
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
