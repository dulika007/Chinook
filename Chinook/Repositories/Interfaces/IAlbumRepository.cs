using Chinook.Models;

namespace Chinook.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetByArtistIdAsync(long artistId);
    }
}
