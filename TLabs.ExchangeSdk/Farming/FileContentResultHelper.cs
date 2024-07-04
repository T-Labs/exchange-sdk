using Microsoft.AspNetCore.Mvc;

namespace TLabs.ExchangeSdk.Farming;

public class FileContentResultHelper
{
    public static FileContentResult GetFileContentResult(string type, byte[] image)
    {
        FileContentResult fileContentResult = null;
        switch (type)
        {
            case "gif":
                return new FileContentResult(image, "image/gif");

            case "png":
                return new FileContentResult(image, "image/png");

            case "webp":
                return new FileContentResult(image, "image/webp");

            default:
                return new FileContentResult(image, "image/jpeg");
        }
    }
}
