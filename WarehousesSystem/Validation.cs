using System.Text.RegularExpressions;

namespace WarehousesSystem
{
    public class Validation
    {
        static Regex urlRegex = new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)");
        static Regex nameRegex = new Regex(@"^(\w\s?){25}$");
        static Regex faxRegex = new Regex(@"^\+[\d]{6,14}$");
        static Regex phoneRegex = new Regex(@"^\+[\d]{12}$");
        static Regex telephoneRegex = new Regex(@"^\+[\d]{6,9}$");
    }
}
