using Chinook.Models;
using Chinook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly ChinookContext _context;

        public PlaylistRepository(ChinookContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get data along with Track, Album & Artists By PlaylistId
        /// </summary>
        /// <param name="playlistId"></param>
        /// <returns></returns>
        public async Task<Playlist> GetWithTracksAndAlbumAndArtistByIdAsync(long playlistId)
        {
            return await _context.Playlists.Include(i => i.Tracks).ThenInclude(i => i.Album).ThenInclude(i => i.Artist)
                .Include(i => i.Tracks).ThenInclude(i => i.Playlists).ThenInclude(i => i.UserPlaylists).FirstOrDefaultAsync(p => p.PlaylistId == playlistId);
        }

        /// <summary>
        /// Get data by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Playlist> GetByNameAsync(string name)
        {
            return await _context.Playlists.FirstOrDefaultAsync(i => i.Name == name);
        }

        /// <summary>
        /// Insert a new Playlist record
        /// </summary>
        /// <param name="obj"></param>
        public async Task AddAsync(Playlist obj)
        {
            await _context.Playlists.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all Playlist data
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Playlist>> GetAllAsync()
        {
            return await _context.Playlists.ToListAsync();
        }

        /// <summary>
        /// Save changes
        /// </summary>
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get next PlaylistId
        /// </summary>
        /// <returns></returns>
        public async Task<long> GetNewId()
        {
            var result = await _context.Playlists.OrderByDescending(i => i.PlaylistId).FirstOrDefaultAsync();
            return result.PlaylistId + 1;
        }

        public async Task DeleteAsync(Playlist obj)
        {
            _context.Playlists.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
