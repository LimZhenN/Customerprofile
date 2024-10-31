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
    // Defines the API route for accessing customer information
    [Route("api/CusInfo")]
    [ApiController]
    public class CusInfoControllers: ControllerBase
    {       
        // Field to interact with the database context for data access
        private readonly ApplicationDBContext _context;
        // Constructor to initialize the database context
        public CusInfoControllers(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/CusInfo
        // Fetches all customer information from the database
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Retrieve all customers from the database
            var cusinfos = await _context.cusInfos.ToListAsync();
            // Convert each customer record to a Data Transfer Object (DTO) for controlled exposure
            var cusDto = cusinfos.Select(s => s.ToCusDto());
            // Return the DTOs with a 200 OK status
            return Ok(cusDto);
        }

        // GET: api/CusInfo/{id}
        // Fetches a specific customer by their unique ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            // Find the customer in the database by ID
            var cusinfos = await _context.cusInfos.FindAsync(id);
            // Check if the customer was not found, return 404 NotFound if so
            if(cusinfos == null)
            {
                return NotFound();
            }
            // Convert the customer model to a DTO and return with a 200 OK status
            return Ok(cusinfos.ToCusDto());
        }

        // POST: api/CusInfo
        // Creates a new customer record based on the provided DTO data
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCusinfoRequestDto CusDtos)
        {
            // Map the DTO to a customer model for database storage
            var cusModel = CusDtos.TocusinfoFromCreateDto();
            // Add the new customer model to the database context
            await _context.cusInfos.AddAsync(cusModel);
            // Save the changes to persist the new record in the database
            await _context.SaveChangesAsync();
            // Return a 201 Created status along with the created resource's DTO
            return CreatedAtAction(nameof(GetById), new{ id = cusModel.Id}, cusModel.ToCusDto());
        }

        // PUT: api/CusInfo/{id}
        // Updates an existing customer's information based on their ID and the provided update DTO
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCusinfoRequestDto updateDto)
        {
            // Find the customer record in the database by ID
            var cusModel = await _context.cusInfos.FirstOrDefaultAsync(x => x.Id == id);
            // If the customer does not exist, return a 404 NotFound
            if (cusModel == null)
            {
                return NotFound();
            }

            // Update customer properties with the new data from the DTO
            cusModel.FirstName = updateDto.FirstName;
            cusModel.LastName = updateDto.LastName;
            cusModel.email = updateDto.email;
            cusModel.PhoneNo = updateDto.PhoneNo;

            // Save the changes to persist the updates in the database
            await _context.SaveChangesAsync();
            // Return the updated customer information as a DTO with a 200 OK status
            return Ok(cusModel.ToCusDto());
        }

        // DELETE: api/CusInfo/{id}
        // Deletes a specific customer record based on their ID
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete ([FromRoute] int id)
        {
            // Find the customer record in the database by ID
            var cusModel = await _context.cusInfos.FirstOrDefaultAsync(x => x.Id == id);
            // If the customer does not exist, return a 404 NotFound
            if (cusModel == null)
            {
                return NotFound();
            }
            // Remove the customer record from the database context
            _context.cusInfos.Remove(cusModel);
            // Save the changes to persist the deletion in the database
            await _context.SaveChangesAsync();
            // Return a 204 No Content status, indicating successful deletion with no content to return
            return NoContent();
        }
    }
}