using Chinook.ClientModels;
using Microsoft.AspNetCore.Components;

namespace Chinook;

public class NavMenuService : INavMenuService
{
    public List<Playlist> AdditionalMenuItems { get; set; }
    public Func<Task> OnChanged { get; set; }
    public async Task NotifyChanged()
    {
        await OnChanged();
    }
}