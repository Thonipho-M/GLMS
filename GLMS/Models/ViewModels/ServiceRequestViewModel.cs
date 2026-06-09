namespace GLMS.Models.ViewModels
{
    public class ServiceRequestViewModel
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}