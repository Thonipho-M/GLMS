using GLMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Contract
{
    public int Id { get; set; }

    [Required]
    public int ClientId { get; set; }

    public Client Client { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [Required]
    public string Status { get; set; } // Draft, Active, Expired, On Hold

    public string ServiceLevel { get; set; }

    public string FilePath { get; set; } // PDF location

    public ICollection<ServiceRequest> ServiceRequests { get; set; }
}