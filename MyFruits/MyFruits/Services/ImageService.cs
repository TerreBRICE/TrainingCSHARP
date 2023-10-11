using myFruits.Models;
using myFruits.Services;

namespace MyFruits.Services;

public class ImageService
{

    private readonly PathService pathService;

    public ImageService(PathService pathService)
    {
        this.pathService = pathService;
    }

    public async Task<Image> UploadAsync(Image image)
    {
        var uploadsPath = pathService.GetUploadPath();

        var imageFile = image.File;
        var imageFileName = GetRandomFileName(imageFile.FileName);
        var imageUploadPath = Path.Combine(uploadsPath, imageFileName);

        using (var fs = new FileStream(imageUploadPath, FileMode.Create))
        {
            await imageFile.CopyToAsync(fs);
        }

        image.Name = imageFile.FileName;
        image.Path = pathService.GetUploadPath(imageFileName, withWebRootPath: false);

        return image;
    }

    private string GetRandomFileName(string filename)
    {
        return Guid.NewGuid() + Path.GetExtension(filename);
    }

    public void DeleteUploadedFile(Image? image)
    {
        if (image == null)
        {
            return;
        }
        var imagePath = pathService.GetUploadPath(Path.GetFileName(image.Path));

        if(File.Exists(imagePath)) 
            File.Delete(imagePath);
    }
}
