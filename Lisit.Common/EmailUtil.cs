using System.Text.RegularExpressions;

namespace Lisit.Common; 
public static class EmailUtil {
    public static bool IsEmailValid(this string email) {
        string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(patron);
        return regex.IsMatch(email);
    }
}
