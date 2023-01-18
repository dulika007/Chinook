using Chinook.Models;

namespace Chinook.Repositories.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<Playlist> GetWithTracksAndAlbumAndArtistByIdAsync(long playlistId);
        Task<Playlist> GetByNameAsync(string name);
        Task AddAsync(Playlist obj);
        Task<IEnumerable<Playlist>> GetAllAsync();
        Task SaveAsync();
        Task<long> GetNewId();
        Task DeleteAsync(Playlist obj);
    }
}
