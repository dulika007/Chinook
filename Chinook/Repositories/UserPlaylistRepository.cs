using Chinook.Models;
using Chinook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repositories;

public class UserPlaylistRepository : IUserPlaylistRepository
{
    private readonly ChinookContext _context;

    public UserPlaylistRepository(ChinookContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Save new record
    /// </summary>
    /// <param name="obj"></param>
    public async Task AddAsync(UserPlaylist obj)
    {
        await _context.UserPlaylists.AddAsync(obj);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Delete existing record
    /// </summary>
    /// <param name="obj"></param>
    public async Task DeleteAsync(UserPlaylist obj)
    {
        _context.UserPlaylists.Remove(obj);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get data by UserId & PlayId
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="playId"></param>
    /// <returns></returns>
    public async Task<UserPlaylist> GetByUserIdAndPlayId(string userId, long playId)
    {
        return await _context.UserPlaylists.FirstOrDefaultAsync(i => i.UserId == userId && i.PlaylistId == playId);
    }
}