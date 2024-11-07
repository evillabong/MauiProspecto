using Microsoft.JSInterop;

namespace WebApi.Extensions
{
    public static class JSRuntimeExtension
    {
        public static ValueTask Alert(this IJSRuntime js, string message)
        {
            return js.InvokeVoidAsync("alert", message);
        }
        public static ValueTask<bool> Confirm(this IJSRuntime js, string message)
        {
            return js.InvokeAsync<bool>("confirm", message);
        }
    }
}
