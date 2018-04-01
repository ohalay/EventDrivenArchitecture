using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventDrivenArchitecture.SSE.SSE;
using Microsoft.AspNetCore.Mvc;

namespace EventDrivenArchitecture.SSE.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ISseSendService sseService;

        public ValuesController(ISseSendService sseService)
        {
            this.sseService = sseService;
        }
       

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]dynamic value)
        {
            await sseService.SendMessageAsync(new SseMessage<dynamic>
            {
                Event = "someEvent",
                Data = value,
                Id = Guid.NewGuid().ToString()
            });
        }

    }
}
