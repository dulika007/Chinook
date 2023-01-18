using Chinook.Models;

namespace Chinook.Repositories.Interfaces
{
    public interface ITrackRepository
    {
        Task<Track> GetByIdAsync(long trackId);
        Task<IEnumerable<Track>> GetWithAlbumAndPlayListByIdAsync(long artistId);
        Task SaveAsync();
    }
}
