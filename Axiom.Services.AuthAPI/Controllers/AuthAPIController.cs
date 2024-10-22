﻿using Axiom.Services.AuthAPI.Models.Dto;
using Axiom.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Axiom.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _responseDTO;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _responseDTO = new();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _responseDTO.Success = false;
                _responseDTO.Message = errorMessage;
                return BadRequest(_responseDTO);
            }

            return Ok(_responseDTO);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);

            if (loginResponse.User == null)
            {
                _responseDTO.Success = false;
                _responseDTO.Message = "Username or password is incorrect";
                return BadRequest(_responseDTO);
            }

            _responseDTO.Result = loginResponse;
            return Ok(_responseDTO);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());

            if (assignRoleSuccessful) return Ok(_responseDTO);
            _responseDTO.Success = false;
            _responseDTO.Message = "Error encountered";
            return BadRequest(_responseDTO);
        }
    }
}