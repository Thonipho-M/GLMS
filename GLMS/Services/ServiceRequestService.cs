public class ServiceRequestService
{
    public bool CanCreateServiceRequest(string contractStatus)
    {
        if (contractStatus == "Expired" || contractStatus == "On Hold")
            return false;

        return true;
    }
}