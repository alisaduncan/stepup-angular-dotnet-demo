using System.Security.Claims;
using HeroAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController: ControllerBase
    {
        private HeroData heroData = new HeroData();
        private readonly string requiredAcrValue = "urn:okta:loa:2fa:any";

        [Authorize]
        [HttpGet]
        public IActionResult GetHeroes()
        {
            var principal = HttpContext.User.Identity as ClaimsIdentity;
            var acrClaim = principal?.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/claims/authnclassreference");

            // check if conditions are not met
            if (acrClaim?.Value != requiredAcrValue) {
                HttpContext.Response.Headers.WWWAuthenticate = $"Bearer error=\"insufficient_user_authentication\",error_description=\"A different authentication level is required\",acr_values=\"{requiredAcrValue}\"";
                return Unauthorized();
            }

            return Ok(heroData.Heroes);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FullHeroesController: ControllerBase
    {
        private HeroData heroData = new HeroData();
        private readonly int maxAge = 30; 

        [Authorize]
        [HttpGet]
        public IActionResult GetFullHeroes()
        {
            var principal = HttpContext.User.Identity as ClaimsIdentity;

            var now = DateTimeOffset.Now.ToUnixTimeSeconds();
            var iat = 0;
            Int32.TryParse(principal?.Claims.FirstOrDefault(c => c.Type == "auth_time")?.Value, out iat);
            var maxIatAllowed = iat + maxAge;
            
            // check if conditions are not met
            if (now > maxIatAllowed) {
                HttpContext.Response.Headers.WWWAuthenticate = $"Bearer error=\"insufficient_user_authentication\",error_description=\"More recent authentication is required\",max_age=\"{maxAge}\"";
                return Unauthorized();
            }

            return Ok(heroData.FullHeroes);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FeaturedHeroesController: ControllerBase
    { 
        private HeroData heroData = new HeroData();

        [HttpGet]
        public ActionResult<IEnumerable<Hero>> GetFeaturedHeroes()
        {
            return heroData.FeaturedHeroes;
        }
    }
}