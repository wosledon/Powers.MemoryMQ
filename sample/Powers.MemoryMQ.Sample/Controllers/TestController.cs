// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this
// file to you under the MIT license. See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Powers.MemoryMQ.Abstractions;

namespace Powers.MemoryMQ.Sample.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class TestController : ControllerBase
    {
        private readonly IMessageProducer<string, object> _producer;

        public TestController(IMessageProducer<string, object> producer)
        {
            _producer = producer;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string key, string value)
        {
            await _producer.ProduceAsync(key, value);

            return NoContent();
        }
    }
}
