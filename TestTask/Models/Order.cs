using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestTask.Models.Enums;

namespace TestTask.Models;

[Table("Orders")]
public class Order
{
    [Key]
    public Guid Id { get; set; }
    
    public Status Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? DeletedAt { get; set; }
    
    [Required]
    public IEnumerable<Line> Lines { get; set; }
}