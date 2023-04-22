using System.ComponentModel.DataAnnotations;

public class Store : BaseEntity
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Company { get; set; }

    [Required]
    public string Address { get; set; }
}
