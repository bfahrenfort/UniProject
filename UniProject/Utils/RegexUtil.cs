using System.Text.RegularExpressions;

namespace UniProject.Utils
{
    public class RegexUtil
    {
        //Validates an email address.
        public static Regex ValidEmailAddress()
        {
            return new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" +
                             @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
        }

        //Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character:
        
        public static Regex ValidPassword()
        {
            return new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#@$!%*?&-])[A-Za-z\d@#$!%*?&-]{8,}$");
        }


        //Minimum length of 6 character and no New Lines.
        public static Regex MinLength(int length)
        {
            return new Regex("/^.{6,}$/");
        }


    }
}