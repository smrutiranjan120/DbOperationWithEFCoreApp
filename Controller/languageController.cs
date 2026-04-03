using DbOperationWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DbOperationWithEFCoreApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class languageController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public languageController(AppDbContext appDbContext)
        {
            _appDbContext=appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLanguagesAsync()
        {
            var languageList = await _appDbContext.Languages.ToListAsync();
            return Ok(languageList);
        }

    }
}
