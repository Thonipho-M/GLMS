using System.ComponentModel.DataAnnotations;

public class Client
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public string ContactDetails { get; set; }

    public string Region { get; set; }

    public ICollection<Contract> Contracts { get; set; }
}