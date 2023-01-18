using Chinook.Models;
using Chinook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repositories;

public class ArtistRepository : IArtistRepository
{
    private readonly ChinookContext _context;

    public ArtistRepository(ChinookContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Get All data
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Artist>> GetAllAsync()
    {
        return await _context.Artists.ToListAsync();
    }

    /// <summary>
    /// Get data by ArtistId
    /// </summary>
    /// <param name="artistId"></param>
    /// <returns></returns>
    public async Task<Artist> GetByArtistIdAsync(long artistId)
    {
        return await _context.Artists.FirstAsync(i => i.ArtistId == artistId);
    }
}