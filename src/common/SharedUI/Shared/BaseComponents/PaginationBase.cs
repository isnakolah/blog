using Common.Application.Common.Models;
using Microsoft.AspNetCore.Components;

namespace SharedUI.Shared.BaseComponents;

public abstract class PaginationBase : ComponentBase
{
    [Parameter]
    [SupplyParameterFromQuery]
    public PaginationFilter PaginationFilter { get; init; } = new();
}