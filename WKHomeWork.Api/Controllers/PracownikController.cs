using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WKHomeWork.Library.Commands;
using WKHomeWork.Library.Domain.PracownikAggregate.Entities;

namespace WKHomeWork.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PracownikController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public PracownikController(ICommandBus commandsBus)
        {
            _commandBus = commandsBus;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] PracownikCreate pracownik)
        {
            await _commandBus.SendCommand(pracownik);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PracownikUpdate pracownik)
        {
            await _commandBus.SendCommand(pracownik);

            return Ok();
        }
    }

    
}