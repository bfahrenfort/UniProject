// Globals
namespace UniProject.Utils
{
    
    public class Utilities
    {
        public static int UserID;
        
        //connection for university database, readonly
        public static readonly string UniConnString =
            "server=unitour2.mysql.database.azure.com;user=testuser@unitour2;database=unidirectory;port=3306;password=pbn91Test!";
        //connection for user database, can read, write, and delete
        public static readonly string UserConnString =
            "server=unitour2.mysql.database.azure.com;user=Usertableuser@unitour2;database=userlogin;port=3306;password=pbn92Test!";
        
        
    }
}
