using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orderMicroservice.Data;
using orderMicroservice.Models;

namespace orderMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutsController : ControllerBase
    {
        private readonly orderMicroserviceContext _context;

        public CheckoutsController(orderMicroserviceContext context)
        {
            _context = context;
        }

        // GET: api/Checkouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checkout>>> GetCheckout()
        {
            return await _context.Checkout.ToListAsync();
        }


     
        
        // Post : api/cheekout/pay
        [HttpPost("pay")]
        public async Task<dynamic> Pay(Models.Checkout pm)
        {
            //return await MakePayment.PayAsync(pm.cardNumber, pm.month, pm.year, pm.cvc, pm.totalPrice);
            if (await MakePayment.PayAsync(pm.cardNumber, pm.month, pm.year, pm.cvc, pm.totalPrice) == "success")
            {

                _context.Checkout.Add(pm);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCheckout", new { id = pm.Id }, pm);
            }
            else
            {
                return "Checkout is not successful";

            }
            
            }
            
        
        



        // GET: api/Checkouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Checkout>> GetCheckout(int id)
        {
            var checkout = await _context.Checkout.FindAsync(id);

            if (checkout == null)
            {
                return NotFound();
            }

            return checkout;
        }

        // PUT: api/Checkouts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckout(int id, Checkout checkout)
        {
            if (id != checkout.Id)
            {
                return BadRequest();
            }

            _context.Entry(checkout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckoutExists(id))
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

        // POST: api/Checkouts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

       

        // DELETE: api/Checkouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckout(int id)
        {
            var checkout = await _context.Checkout.FindAsync(id);
            if (checkout == null)
            {
                return NotFound();
            }

            _context.Checkout.Remove(checkout);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckoutExists(int id)
        {
            return _context.Checkout.Any(e => e.Id == id);
        }
    }
}
