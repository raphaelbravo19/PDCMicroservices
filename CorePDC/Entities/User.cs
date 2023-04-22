using System.ComponentModel.DataAnnotations;

public class User : BaseEntity
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public int Age { get; set; }
}
