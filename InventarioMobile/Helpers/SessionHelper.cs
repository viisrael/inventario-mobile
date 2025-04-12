using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioMobile.Helpers;
public static class SessionHelper
{
    public static void SaveToken(string token, DateTime expireIn)
    {
        Preferences.Set("token", token);
        Preferences.Set("expireDateTimeKey", expireIn);
    }


    public static async Task<string> GetTokenAsync()
    {
        var token = Preferences.Get("token", string.Empty);
        var expireDateTime = Preferences.Get("expireDateTimeKey", DateTime.MinValue);
     
        if (string.IsNullOrEmpty(token) || expireDateTime < DateTime.Now)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

            return string.Empty;
        }

        return token;
    }
}
