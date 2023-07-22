﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Models.Dto;
using RecipeApp_RecipeAPI.Repository.IRepository;
using System.Data;
using System.Net;

namespace RecipeApp_RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleAPIController : ControllerBase
    {
        private readonly IRoleRepository _dbRole;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public RoleAPIController(IRoleRepository dbRole, IMapper mapper)
        {
            _dbRole = dbRole;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetRole()
        {
            try
            {
                IEnumerable<Role> roleList = await _dbRole.GetAllAsync();
                _response.Result = _mapper.Map<List<RoleDTO>>(roleList);
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
        [HttpGet("id", Name = "GetRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetRole(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var role = await _dbRole.GetAsync(u => u.Id == id);
                if (role == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                _response.Result = _mapper.Map<RoleDTO>(role);
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
        public async Task<ActionResult<APIResponse>> DeleteRole(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var role = await _dbRole.GetAsync(u => u.Id == id);
                if (role == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "Invalid input" };
                    return NotFound(_response);
                }
                await _dbRole.RemoveAsync(role);
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
        //public async Task<ActionResult<APIResponse>> UpdateRole(int id, [FromBody] RoleUpdateDTO updateDTO)
        //{
        //    try
        //    {
        //        if (updateDTO == null || id != updateDTO.VillaNo)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var role = _mapper.Map<Role>(updateDTO);
        //        await _dbRole.UpdateAsync(role);
        //        _response.Result = _mapper.Map<RoleUpdateDTO>(role);
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
        public async Task<ActionResult<APIResponse>> CreateRole([FromBody] RoleCreateDTO createDTO)
        {
            try
            {
                if(createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage = new List<string> { "No Input provided" };
                    return _response;
                }
                var role = _mapper.Map<Role>(createDTO);
                await _dbRole.CreateAsync(role);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<RoleDTO>(role);
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
