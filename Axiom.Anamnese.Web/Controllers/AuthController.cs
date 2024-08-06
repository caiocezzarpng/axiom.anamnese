using Axiom.Anamnese.Web.Models.Dto;
using Axiom.Anamnese.Web.Service.IService;
using Axiom.Anamnese.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Axiom.Anamnese.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDTO = new();
            return View(loginRequestDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ResponseDto responseDTO = await _authService.LoginAsync(obj);

            if (responseDTO != null && responseDTO.Success)
            {
                LoginResponseDto loginResponseDTO =
                    JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDTO.Result));

                await SignInUser(loginResponseDTO);

                _tokenProvider.SetToken(loginResponseDTO.Token);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = responseDTO.Message;
                return View(obj);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text = StaticDetails.RoleAdmin, Value = StaticDetails.RoleAdmin},
                new SelectListItem{Text = StaticDetails.RoleCostumer, Value = StaticDetails.RoleCostumer},
            };

            ViewBag.RoleList = roleList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto obj)
        {
            ResponseDto result = await _authService.RegisterAsync(obj);
            ResponseDto assignRole;

            if (result != null && result.Success)
            {
                if (string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = StaticDetails.RoleCostumer;
                }

                assignRole = await _authService.AssignRoleAsync(obj);

                if (assignRole != null && assignRole.Success)
                {
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction(nameof(Login));
                }
            }
            else
            {
                TempData["error"] = result.Message;
            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text = StaticDetails.RoleAdmin, Value = StaticDetails.RoleAdmin},
                new SelectListItem{Text = StaticDetails.RoleCostumer, Value = StaticDetails.RoleCostumer},
            };

            ViewBag.RoleList = roleList;
            return View(obj);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            return RedirectToAction("Index", "Home");
        }

        private async Task SignInUser(LoginResponseDto model)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(model.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));


            identity.AddClaim(new Claim(ClaimTypes.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(ClaimTypes.Role,
                jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}