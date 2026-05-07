using System.ComponentModel.DataAnnotations;

public class Contract
{
    public int Id { get; set; }

    [Required]
    public int ClientId { get; set; }

    public Client? Client { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    [Required]
    public string Status { get; set; }

    public string? ServiceLevel { get; set; }

    public string? FilePath { get; set; }

    public ICollection<ServiceRequest>? ServiceRequests { get; set; } = new List<ServiceRequest>();
}