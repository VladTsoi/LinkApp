using Microsoft.EntityFrameworkCore;

namespace LinkApp.Models
{
    public static class LinkMethod
    {
        public static string Short(string Url, ApplicationContext db)
        {
            var link = db.Links.FirstOrDefault(l => l.Url == Url);
            if (link == null)
            {
                return Shorter.ShortUrl(db);
            }
            else
                return link.ShortUrl;
        }
    }
}
