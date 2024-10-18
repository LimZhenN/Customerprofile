using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetAll()
        {
            // Retrieve all customers from the database
            var cusinfos = await _context.cusInfos.ToListAsync();
            // Convert the customer models to DTOs
            var cusDto = cusinfos.Select(s => s.ToCusDto());
            // Return the DTOs with a 200 OK status
            return Ok(cusDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var cusinfos = await _context.cusInfos.FindAsync(id);

            if(cusinfos == null)
            {
                return NotFound();
            }

            return Ok(cusinfos.ToCusDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCusinfoRequestDto CusDtos)
        {
            var cusModel = CusDtos.TocusinfoFromCreateDto();
            await _context.cusInfos.AddAsync(cusModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new{ id = cusModel.Id}, cusModel.ToCusDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCusinfoRequestDto updateDto)
        {
            var cusModel = await _context.cusInfos.FirstOrDefaultAsync(x => x.Id == id);
            
            if (cusModel == null)
            {
                return NotFound();
            }

            cusModel.FirstName = updateDto.FirstName;
            cusModel.LastName = updateDto.LastName;
            cusModel.email = updateDto.email;
            cusModel.PhoneNo = updateDto.PhoneNo;

            await _context.SaveChangesAsync();
            return Ok(cusModel.ToCusDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete ([FromRoute] int id)
        {
            var cusModel = await _context.cusInfos.FirstOrDefaultAsync(x => x.Id == id);

            if (cusModel == null)
            {
                return NotFound();
            }

            _context.cusInfos.Remove(cusModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}