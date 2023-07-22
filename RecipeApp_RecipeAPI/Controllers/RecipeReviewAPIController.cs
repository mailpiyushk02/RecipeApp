﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Models.Dto;
using RecipeApp_RecipeAPI.Repository.IRepository;
using System.Net;

namespace RecipeApp_RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/recipeReview")]
    public class RecipeReviewAPIController : ControllerBase
    {
        private readonly IRecipeReviewRespository _dbRecipeReview;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public RecipeReviewAPIController(IRecipeReviewRespository dbRecipeReview,IMapper mapper)
        {
            _dbRecipeReview = dbRecipeReview;
            _mapper = mapper;
            _response = new APIResponse();
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetRecipeReview()
        {
            try
            {
                IEnumerable<RecipeReview> recipeReviewList = await _dbRecipeReview.GetAllAsync();
                _response.Result = _mapper.Map<List<RecipeReviewDTO>>(recipeReviewList);
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
        [HttpGet("id", Name = "GetRecipeReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetRecipeReview(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var recipeReview = await _dbRecipeReview.GetAsync(u => u.Id == id);
                if (recipeReview == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                _response.Result = _mapper.Map<RecipeReviewDTO>(recipeReview);
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
        public async Task<ActionResult<APIResponse>> DeleteRecipeReview(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var recipeReview = await _dbRecipeReview.GetAsync(u => u.Id == id);
                if (recipeReview == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Invalid input" };
                    return NotFound(_response);
                }
                await _dbRecipeReview.RemoveAsync(recipeReview);
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
        //public async Task<ActionResult<APIResponse>> UpdateRecipeReview(int id, [FromBody] RecipeReviewUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.VillaNo)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var recipeReview = _mapper.Map<RecipeReview>(updateDTO);
        //        await _dbRecipeReview.UpdateAsync(recipeReview);
        //        _response.Result = _mapper.Map<RecipeReviewUpdateDTO>(recipeReview);
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
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] RecipeReviewCreateDTO createDTO)
        {
            try
            {
                if(createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Incorrect Input" };
                    return _response;
                }
                var recipeReview = _mapper.Map<RecipeReview>(createDTO);
                await _dbRecipeReview.CreateAsync(recipeReview);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<RecipeReviewDTO>(recipeReview);
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
