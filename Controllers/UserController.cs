﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TwitterCloneAPIUserAuth.Services;
using TwitterCloneAPIUserAuth.Data;
using TwitterCloneAPIUserAuth.Models;
using TwitterCloneShared.SharedModels;

namespace TwitterCloneAPIUserAuth.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthenticationService _authService;

        public UserController(UserService userService, AuthenticationService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Registration model)
    {
        var user = new User
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        var result = await _userService.RegisterUserAsync(user, model.Password);
        if (result.Succeeded)
        {
            return Ok(new { Message = "Registration successful!" });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] Login model)
        {
            bool isValidCredentials = await _authService.ValidateCredentials(model.Email, model.Password);
            if (isValidCredentials)
            {
                var user = await _userService.AuthenticateAsync(model.Email, model.Password);
                if (user != null)
                {
                    var token = _authService.GenerateJwtToken(user.Id);  // Generate the JWT token here
                    return Ok(new { Token = token });
                }
            }

            return Unauthorized();
        }
    }

