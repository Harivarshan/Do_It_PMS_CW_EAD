using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework_EAD.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime JsRuntime, string message)
        {
            await JsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }
        public static async ValueTask ToastrError(this IJSRuntime JsRuntime, string message)
        {
            await JsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }        
        public static async ValueTask ToastrSuccess2(this IJSRuntime JsRuntime, string message)
        {
            await JsRuntime.InvokeVoidAsync("ShowToastr2", "success", message);
        }
        public static async ValueTask ToastrError2(this IJSRuntime JsRuntime, string message)
        {
            await JsRuntime.InvokeVoidAsync("ShowToastr2", "error", message);
        }
    }
}
