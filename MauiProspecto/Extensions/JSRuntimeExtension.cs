using Microsoft.JSInterop;

namespace MauiProspecto.Extensions
{
    public static class JSRuntimeExtension
    {
        public static async ValueTask AlertAsync(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("alert", message);
        }
        public static async ValueTask<bool> ConfirmAsync(this IJSRuntime js, string message)
        {
            return await js.InvokeAsync<bool>("confirm", message);
        }
    }
}
