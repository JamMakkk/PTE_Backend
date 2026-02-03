
namespace Shared
{
    public class FileHandler
    {
        public static async Task<bool> SaveUploadedFile(Stream file, string filePath) 
        {
            await using var stream = new FileStream(
                filePath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                bufferSize: 81920,
                useAsync: true
            );

            await file.CopyToAsync(stream);
            return true;
        }
    }
}
