using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//-->ATTRIBUTE
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)//carmanager ın referansını tutabiliyor
        {
            //constructor da erişim yok
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            
            var result = _carService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int carid)
        {
            var result = _carService.GetById(carid);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpPost] post güncelleme ve silme içinde kullanılabilir
    }
}
