using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicingPlan.Model
{
    [Table(nameof(Role))]
    public  class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
