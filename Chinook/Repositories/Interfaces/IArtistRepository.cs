using Chinook.Models;

namespace Chinook.Repositories.Interfaces;

public interface IArtistRepository
{
    Task<IEnumerable<Artist>> GetAllAsync();
    Task<Artist> GetByArtistIdAsync(long artistId);
}