namespace UniProject.Models
{
    // A single saved search
    public class SavedSearchesModel
    {
        public int UserId { get; set; }
        
        public string SavedSchool { get; set; }
        
        public SavedSearchesModel(int d, string s)
        {
            UserId = d;
            SavedSchool = s;
        }
    }
}
