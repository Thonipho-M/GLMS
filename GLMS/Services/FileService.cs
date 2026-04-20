public class FileService
{
    private readonly string _uploadPath = "wwwroot/files";

    public string SavePdf(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new Exception("File is empty");

        var extension = Path.GetExtension(file.FileName).ToLower();

        if (extension != ".pdf")
            throw new Exception("Only PDF files are allowed");

        var fileName = Guid.NewGuid().ToString() + ".pdf";
        var fullPath = Path.Combine(_uploadPath, fileName);

        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return "/files/" + fileName;
    }
}