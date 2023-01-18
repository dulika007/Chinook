using Chinook.Models;
using Chinook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly ChinookContext _context;

        public TrackRepository(ChinookContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get data by Id
        /// </summary>
        /// <param name="trackId"></param>
        /// <returns></returns>
        public async Task<Track> GetByIdAsync(long trackId)
        {
            return await _context.Tracks.FirstOrDefaultAsync(i => i.TrackId == trackId);
        }

        /// <summary>
        /// Get data along with Album & Playlist by ArtistId
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Track>> GetWithAlbumAndPlayListByIdAsync(long artistId)
        {
            return await _context.Tracks.Include(i => i.Album).Include(i => i.Playlists).ThenInclude(i => i.UserPlaylists).Where(a => a.Album.ArtistId == artistId).ToListAsync();
        }

        /// <summary>
        /// Insert a new Track record
        /// </summary>
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
