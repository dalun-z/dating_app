using CloudinaryDotNet.Actions;

namespace API.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);      // return publicId
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}