﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        IPlatformService _platformService;


        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _platformService.GetAll();

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("add")]
        public IActionResult Add(Platform platform) 
        {
            var result = _platformService.Add(platform);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Platform platform)
        {
            var result=_platformService.Delete(platform);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result) ;
        }
        [HttpPost("update")]
        public IActionResult Update(Platform platform)
        { 
            var result = _platformService.Update(platform);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int platformId)
        { 
            var result = _platformService.GetById(platformId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
