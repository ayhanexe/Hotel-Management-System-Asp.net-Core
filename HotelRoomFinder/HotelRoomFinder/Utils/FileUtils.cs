using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace HotelRoomFinder.Utils
{
    public class FileUtils
    {
        public static async Task<string> CopyFile(IFormFile file, string path)
        {
            var newFileName = GeneralUtils.GenerateName(10);
            FileStream stream = new FileStream($"{path}/{newFileName}{file.FileName}", FileMode.Create);
            await file.CopyToAsync(stream);
            stream.Close();

            return $"{newFileName}{file.FileName}";
        }

        public static async Task<bool> DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
    }
}
