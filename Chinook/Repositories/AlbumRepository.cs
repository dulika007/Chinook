using Chinook.Models;
using Chinook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private readonly ChinookContext _context;

    public AlbumRepository(ChinookContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get data by ArtistId
    /// </summary>
    /// <param name="artistId"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Album>> GetByArtistIdAsync(long artistId)
    {
        return await _context.Albums.Where(i => i.ArtistId == artistId).ToListAsync();
    }
}