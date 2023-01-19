using Microsoft.AspNetCore.Components;

namespace Chinook;

public interface INavMenuService
{
    List<Chinook.ClientModels.Playlist> AdditionalMenuItems { get; set; }
    public Func<Task> OnChanged { get; set; }
    Task NotifyChanged();
}