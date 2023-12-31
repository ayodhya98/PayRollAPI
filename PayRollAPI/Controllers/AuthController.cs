﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayRoll.Application.DTOs.Auth;
using PayRoll.Application.DTOs;
using PayRoll.Application.Repository.IRepository;

namespace PayRollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authService;

        public AuthController(IAuthRepository authService)
        {
            this._authService = authService;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await _authService.Login(user);

                if (result != null)
                {
                    LoginResponseDto responseDto = new LoginResponseDto()
                    {
                        Id = result.Id,
                        Email = result.Email,
                        Jwt = await _authService.GenerateTokenString(result),
                        FirstName = result.FirstName,
                        LastName = result.LastName,


                    };

                    return Ok(responseDto);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        [Route("register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser(UserCreationDto user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var result = await _authService.RegisterUser(user);

                if (result)
                {

                    return Ok("success");
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

