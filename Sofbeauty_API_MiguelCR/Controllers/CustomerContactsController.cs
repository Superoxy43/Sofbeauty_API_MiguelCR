﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sofbeauty_API_MiguelCR.Models;

namespace Sofbeauty_API_MiguelCR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContactsController : ControllerBase
    {
        private readonly SofbeautyContext _context;

        public CustomerContactsController(SofbeautyContext context)
        {
            _context = context;
        }

        // GET: api/CustomerContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerContact>>> GetCustomerContacts()
        {
            return await _context.CustomerContacts.ToListAsync();
        }

        // GET: api/CustomerContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerContact>> GetCustomerContact(int id)
        {
            var customerContact = await _context.CustomerContacts.FindAsync(id);

            if (customerContact == null)
            {
                return NotFound();
            }

            return customerContact;
        }

        // PUT: api/CustomerContacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerContact(int id, CustomerContact customerContact)
        {
            if (id != customerContact.ContactsId)
            {
                return BadRequest();
            }

            _context.Entry(customerContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerContacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerContact>> PostCustomerContact(CustomerContact customerContact)
        {
            _context.CustomerContacts.Add(customerContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerContact", new { id = customerContact.ContactsId }, customerContact);
        }

        // DELETE: api/CustomerContacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerContact(int id)
        {
            var customerContact = await _context.CustomerContacts.FindAsync(id);
            if (customerContact == null)
            {
                return NotFound();
            }

            _context.CustomerContacts.Remove(customerContact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerContactExists(int id)
        {
            return _context.CustomerContacts.Any(e => e.ContactsId == id);
        }
    }
}
