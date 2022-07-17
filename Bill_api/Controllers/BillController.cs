using Bill_api.Database.Models;
using Bill_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bill_api.Controllers
{
    [ApiController]
    public  class BillController: ControllerBase
    {
        private readonly BillService _billService; 

        public BillController(BillService billSevice)
        {
             _billService = billSevice;
        }
        [HttpGet]
        [Route("api/bills")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<string>))]
        public async Task<IActionResult> GetBills()
        {
            var result = await _billService.GetBills();
            return Ok(result);
        }

        [HttpPost]
        [Route("api/providers/add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddBillProvider([FromBody]BillProvider billProvider)
        {
            await _billService.AddProvider(billProvider);
            return Ok();
        }

        [HttpGet]
        [Route("api/providers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type =typeof(List<BillProvider>))]
        public async Task<IActionResult> GetProviders()
        {
            var result = await _billService.GetBillProviders();
            return Ok(result);
        }
    }
}
