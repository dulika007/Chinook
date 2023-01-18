using Chinook.Models;

namespace Chinook.Repositories.Interfaces;

public interface IUserPlaylistRepository
{
    Task AddAsync(UserPlaylist obj);
    Task DeleteAsync(UserPlaylist obj);
    Task<UserPlaylist> GetByUserIdAndPlayId(string userId, long playId);
}