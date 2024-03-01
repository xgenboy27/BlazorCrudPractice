using BlazorCrudPractice.Client.Services;
using BlazorCrudPractice.Shared.Model;
using BlazorCrudPractice.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorCrudPractice.Client.Shared
{
    public partial class BaseBlazor
    {
        [Inject]
        public IService _service { get; set; }
        [Inject]
        public IJSRuntime JsRuntime { get; set; }
    }
}
