namespace FutureComputer.Application.Products.Common;

public static class CommonConstant
{
    public static string ERROR_REQUEST_MESSAGE = "The request has some errors. Please check again in: {0}";
    public static string FOLDER_NAME = "Image_Files";
    public static string FOLDER_PATH = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME);
}