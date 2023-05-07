using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models.DTO;
using TaskManagerAPI.Repositories.Token;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
        public AuthController(UserManager<IdentityUser> userManager,ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        //Post:/api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.UserName,
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.PassWord);
            if(identityResult.Succeeded)
            {
                //Add roles to this user
                if (registerRequestDto.Roles != null&& registerRequestDto.Roles.Any()) {
                    identityResult= await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if(identityResult.Succeeded)
                    {
                        return Ok("Đã tạo tài khoản thành công, mời đăng nhập");
                    }
                }

            }
            return BadRequest("Something went wrong");
        }

        //Post: api/auth/login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user= await userManager.FindByEmailAsync(loginRequestDto.UserName);
            if(user != null)
            {
              var checkPasswordResult=   await userManager.CheckPasswordAsync(user, loginRequestDto.PassWord);
                if (checkPasswordResult)
                {
                    //Get roles for this user
                    var roles=await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        //Create Token
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
                        
                        var respone = new LoginResponeDto
                        {
                            Id=user.Id,
                            UserName=user.UserName,
                            JwtToken = jwtToken
                        };
                        return Ok(respone);
                    }
                }
            }
            return BadRequest("Tên đăng nhập hoặc mật khẩu sai");
        }

    }
}
