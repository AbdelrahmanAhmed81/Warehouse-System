using System.Text.RegularExpressions;

namespace WarehousesSystem
{
    public class Validation
    {
        public static Regex urlRegex = new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)");
        public static Regex faxRegex = new Regex(@"^\+[\d]{6,14}$");
        public static Regex phoneRegex = new Regex(@"^\+[\d]{12}$");
        public static Regex telephoneRegex = new Regex(@"^\+[\d]{6,9}$");
         
        public static Regex charsOnlyStringRegex = new Regex(@"^(\w[^_]+\s)*\w[^_]+$");
        public static Regex addressRegex = new Regex(@"^([\w\d]+\s)*[\w\d]+$");
    }
}
