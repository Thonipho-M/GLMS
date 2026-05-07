using System.ComponentModel.DataAnnotations;

public class ServiceRequest
{
    public int Id { get; set; }

    [Required]
    public int ContractId { get; set; }

    public Contract? Contract { get; set; }

    [Required]
    public string Description { get; set; }

    public decimal CostUSD { get; set; }

    public decimal CostZAR { get; set; }

    public string? Status { get; set; }
}