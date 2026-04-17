using Microsoft.AspNetCore.Mvc;

namespace ThinkBridge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        // Dummy data
        private static readonly List<Invoice> DummyInvoices = new List<Invoice>
        {
            new Invoice
            {
                InvoiceID = 1,
                CustomerName = "Acme Corporation",
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem { ItemID = 1, InvoiceID = 1, Name = "Web Development", Price = 5000 },
                    new InvoiceItem { ItemID = 2, InvoiceID = 1, Name = "UI Design", Price = 2000 }
                }
            },
            new Invoice
            {
                InvoiceID = 2,
                CustomerName = "Tech Solutions Inc",
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem { ItemID = 3, InvoiceID = 2, Name = "Consulting", Price = 3500 },
                    new InvoiceItem { ItemID = 4, InvoiceID = 2, Name = "Support", Price = 1500 }
                }
            },
            new Invoice
            {
                InvoiceID = 3,
                CustomerName = "Digital Agency",
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem { ItemID = 5, InvoiceID = 3, Name = "Mobile App", Price = 8000 }
                }
            }
        };

        /// <summary>
        /// Get a specific invoice by ID
        /// </summary>
        /// <param name="id">Invoice ID (1, 2, or 3)</param>
        /// <returns>Invoice with customer name and items</returns>
        /// <response code="200">Returns the invoice</response>
        /// <response code="404">Invoice not found</response>
        [HttpGet("{id}")]
        public IActionResult GetInvoice(int id)
        {
            var invoice = DummyInvoices.FirstOrDefault(i => i.InvoiceID == id);
            if (invoice == null)
                return NotFound();
            
            return Ok(new 
            { 
                invoiceId = invoice.InvoiceID,
                customerName = invoice.CustomerName,
                items = invoice.Items.Select(i => new { name = i.Name, price = i.Price }).ToList()
            });
        }

        /// <summary>
        /// Get all invoices
        /// </summary>
        /// <returns>List of all invoices</returns>
        /// <response code="200">Returns all invoices</response>
        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            var invoices = DummyInvoices.Select(i => new
            {
                invoiceId = i.InvoiceID,
                customerName = i.CustomerName
            }).ToList();

            return Ok(invoices);
        }
    }

    // Dummy data models
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string? CustomerName { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }

    public class InvoiceItem
    {
        public int ItemID { get; set; }
        public int InvoiceID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
