using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace api.Controllers
{
    [Route("api/CusInfo")]
    [ApiController]
    public class CusInfoControllers: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CusInfoControllers(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var cusinfos = _context.cusInfos.ToList()
            .Select(s => s.ToCusDto());
            return Ok(cusinfos);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var cusinfos = _context.cusInfos.Find(id);

            if(cusinfos == null)
            {
                return NotFound();
            }

            return Ok(cusinfos.ToCusDto());
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCusinfoRequestDto CusDtos)
        {
            var cusModel = CusDtos.TocusinfoFromCreateDto();
            _context.cusInfos.Add(cusModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new{ id = cusModel.Id}, cusModel.ToCusDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateCusinfoRequestDto updateDto)
        {
            var cusModel = _context.cusInfos.FirstOrDefault(x => x.Id == id);
            
            if (cusModel == null)
            {
                return NotFound();
            }

            cusModel.FirstName = updateDto.FirstName;
            cusModel.LastName = updateDto.LastName;
            cusModel.email = updateDto.email;
            cusModel.PhoneNo = updateDto.PhoneNo;

            _context.SaveChanges();
            return Ok(cusModel.ToCusDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete ([FromRoute] int id)
        {
            var cusModel = _context.cusInfos.FirstOrDefault(x => x.Id == id);

            if (cusModel == null)
            {
                return NotFound();
            }

            _context.cusInfos.Remove(cusModel);
            _context.SaveChanges();

            return NoContent();
        }
    }
}