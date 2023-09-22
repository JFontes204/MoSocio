using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicingPlan.Model
{
    [Table(nameof(UserRole))]
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
