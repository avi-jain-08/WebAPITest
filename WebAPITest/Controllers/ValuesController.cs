using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPITest.Models;
using static WebAPITest.Models.PersonParameter;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Evanth", "Jain" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value - " + id;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("covidTest")]
        public IActionResult CheckPersonSymptoms([FromBody] PersonParameter personParameter)
        {

            string result = string.Empty;

            if (personParameter != null)
            {
                if (personParameter.IsFever && personParameter.IsHavingCough && personParameter.IsVistedOutsideIndia)
                {
                    result = Colors.Red.ToString();
                }
                else if (!personParameter.IsFever && !personParameter.IsHavingCough && !personParameter.IsVistedOutsideIndia)
                {
                    result = Colors.Green.ToString();
                }
                else if ((personParameter.IsFever && personParameter.IsHavingCough) || (personParameter.IsVistedOutsideIndia && personParameter.IsFever) || (personParameter.IsHavingCough && personParameter.IsVistedOutsideIndia))
                {
                    result = Colors.Orange.ToString();
                }
            }

            //Soltion 2
            int sum = 0;
            if (personParameter != null)
            {

                sum = Convert.ToInt32(personParameter.IsFever) + Convert.ToInt32(personParameter.IsHavingCough) + Convert.ToInt32(personParameter.IsVistedOutsideIndia);
            }
            if (sum > 2)
            {
                result = Colors.Red.ToString();
            }
            else if (sum <= 2 && sum > 0)
            {
                result = Colors.Orange.ToString();
            }
            else if (sum == 0)
            {
                result = Colors.Green.ToString();
            }

            return Ok(result);
        }


        [HttpGet("testException")]
        public IActionResult GlobalException()
        {
            int[] ar = null;

            if (ar.Length > 0)
            {

            }
            return Ok();
            //string filePath = @"C:\Users\EJain\Desktop\test.txt";
            //System.IO.File.AppendAllText(filePath, " " + result);
            //var read = System.IO.File.ReadAllText(filePath);
        }
    }
}
