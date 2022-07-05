using Bill_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bill_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public  class BillController: ControllerBase
    {
        private readonly BillService _billService; 

        public BillController(BillService billSevice)
        {
             _billService = billSevice;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<string>))]
        public async Task<IActionResult> GetBills()
        {
            var result = await _billService.GetBills();
            return Ok(result);
        }
    }
}
