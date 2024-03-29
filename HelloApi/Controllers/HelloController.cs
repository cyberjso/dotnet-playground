﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloApi.Models;

namespace HelloApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HelloController : ControllerBase
  {
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Hello>> Get()
    {
      return new Hello[1]
     {
                new Hello(Id: "123", Name: "Jack", IsComplete: false)
     };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
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
  }
}
