using Microsoft.AspNetCore.Mvc;
using ThinkBridge.Data;

namespace ThinkBridge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public InvoiceController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetInvoice(int id)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.InvoiceID == id);
            if (invoice == null)
                return NotFound();

            var items = _context.InvoiceItems.Where(ii => ii.InvoiceID == id).ToList();
            
            return Ok(new 
            { 
                invoiceId = invoice.InvoiceID,
                customerName = invoice.CustomerName,
                items = items.Select(i => new { name = i.Name, price = i.Price })
            });
        }

        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            var invoices = _context.Invoices.Select(i => new
            {
                invoiceId = i.InvoiceID,
                customerName = i.CustomerName
            }).ToList();

            return Ok(invoices);
        }
    }
}
