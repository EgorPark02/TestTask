using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TestTask.Models;

[Table("Lines")]
public class Line
{
    [Required]
    public Guid Id { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Количество товаров должно быть больше 0")]
    public int Qty { get; set; }
}