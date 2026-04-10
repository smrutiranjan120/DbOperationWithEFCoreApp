using DbOperationWithEFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEFCoreApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public CurrencyController(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCurrenciesAsync()
        {
            var currencyList = await _appDbContext.Currencies.ToListAsync();
            return Ok(currencyList);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllCurrencyByIdAsync([FromRoute] int id)
        {
            var result = await _appDbContext.Currencies.FindAsync(id);
            return Ok(result);

        }

        [HttpGet("{name:string}")]
        public async Task<IActionResult> GetAllCurrencyByNameAsync([FromRoute] string name)
        {
            var result = await _appDbContext.Currencies.Where(x => x.Title == name).FirstOrDefaultAsync();
            return Ok(result);

        }

        [HttpGet("{name:string}/{description:string}")]
        public async Task<IActionResult> GetAllCurrencyByNameDescriptionAsync([FromRoute] string name, [FromRoute] string description)
        {
            var result = await _appDbContext.Currencies.FirstOrDefaultAsync(x => x.Title == name && x.Description == description);
            return Ok(result);

        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAllCurrenciesByFilterAsync([FromBody] List<int> ids)
        {
            var result = await _appDbContext.Currencies.Where(x=> ids.Contains(x.Id)).ToListAsync();
            return Ok(result);

        }
    }
}
