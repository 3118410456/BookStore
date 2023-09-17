using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailsController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public BillDetailsController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: api/BillDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillDetail>>> GetBillDetails()
        {
          if (_context.BillDetails == null)
          {
              return NotFound();
          }
            return await _context.BillDetails.ToListAsync();
        }

        // GET: api/BillDetails/5
        [HttpGet("{billID}")]
        public async Task<ActionResult<IEnumerable<BillDetail>>> GetBillDetailByBillID(int billID)
        {
            var billDetail = await _context.BillDetails.Where(bd => bd.BillID == billID).ToListAsync();

            if (billDetail == null)
            {
                return NotFound();
            }

            return billDetail;
        }

        // PUT: api/BillDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillDetail(int id, BillDetail billDetail)
        {
            if (id != billDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(billDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillDetailExists(id))
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

        // POST: api/BillDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillDetail>> PostBillDetail(BillDetail billDetail)
        {
          if (_context.BillDetails == null)
          {
              return Problem("Entity set 'BookStoreContext.BillDetails'  is null.");
          }
            _context.BillDetails.Add(billDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillDetail", new { id = billDetail.Id }, billDetail);
        }

        // POST: api/BillDetails
        [HttpPost("add-multiple")]
        public async Task<IActionResult> AddMultipleBillDetails([FromBody] BillDetailDTO billDetailDTO)
        {
            if (billDetailDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                // Thêm danh sách BillDetail vào cơ sở dữ liệu
                _context.BillDetails.AddRange(billDetailDTO.BillDetails);
                await _context.SaveChangesAsync();

                // Trả về một phản hồi JSON thành công
                return Ok(new { message = "Successfully added multiple BillDetails." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        // DELETE: api/BillDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillDetail(int id)
        {
            if (_context.BillDetails == null)
            {
                return NotFound();
            }
            var billDetail = await _context.BillDetails.FindAsync(id);
            if (billDetail == null)
            {
                return NotFound();
            }

            _context.BillDetails.Remove(billDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillDetailExists(int id)
        {
            return (_context.BillDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
