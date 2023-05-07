using System.ComponentModel.DataAnnotations;

namespace EventManagement.Domain.SeedWorks
{
    namespace BillingService.Domain.SeedWorks
    {
        public abstract class BaseEntity
        {
            [Key]
            public int ID { get; set; }

            public DateTime CreatedDate { get; set; } = DateTime.Now;
        }
    }
}
