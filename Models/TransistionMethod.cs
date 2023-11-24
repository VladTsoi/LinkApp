namespace LinkApp.Models
{
    public class TransistionMethod
    {
        public static string ToShortUrl(int? id, ApplicationContext db)
        {
            var chooseLink = db.Links.First(l => l.Id == id);
            if (chooseLink != null)
            {
                chooseLink.Transition += 1;
                db.SaveChangesAsync();
                return chooseLink.Url;
            }
            return null;    
        }
    }
}
