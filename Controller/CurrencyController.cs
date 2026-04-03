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
        public async Task<IActionResult> GetAllCurrencyByIdAsync([FromRoute] string name)
        {
            var result = await _appDbContext.Currencies.Where(x => x.Title == name).FirstOrDefaultAsync();
            return Ok(result);

        }
    }
}
