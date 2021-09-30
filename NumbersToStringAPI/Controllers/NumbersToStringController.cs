using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumbersToStringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersToStringController : ControllerBase
    {
        [HttpPost("Convert")]
        public IActionResult Convert([FromBody] NumberObject input)
        {
            string result = NumberToStringConverter.Convert(input.input);
            return Ok(result);
        }

        [HttpPost("ConvertMultiple")]
        public IActionResult ConvertMultiple([FromBody] NumberObject[] inputs)
        {
            string[] results = new string[inputs.Length];
            for (int i = 0; i < inputs.Length; i++)
            {
                results[i] = NumberToStringConverter.Convert(inputs[i].input);
            }
            return Ok(results);
        }


        public class NumberObject
        {
            public NumberObject(double input)
            {
                this.input = input;
            }

            public double input { get; set; }
        }


    }
}
