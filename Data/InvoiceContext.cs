using Microsoft.EntityFrameworkCore;

namespace ThinkBridge.Data
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>()
                .HasKey(i => i.InvoiceID);

            modelBuilder.Entity<InvoiceItem>()
                .HasKey(ii => ii.ItemID);

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.Items)
                .WithOne()
                .HasForeignKey(ii => ii.InvoiceID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

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
