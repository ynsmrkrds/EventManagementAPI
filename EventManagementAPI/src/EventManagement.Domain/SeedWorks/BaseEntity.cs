namespace EventManagement.Domain.SeedWorks
{
    namespace BillingService.Domain.SeedWorks
    {
        public abstract class BaseEntity
        {
            public int ID { get; set; }

            public DateTime CreatedDate { get; set; } = DateTime.Now;
        }
    }
}
