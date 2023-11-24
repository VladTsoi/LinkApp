namespace LinkApp.Models
{
    public class Shorter
    {
        public static string ShortUrl(ApplicationContext db)
        {
            string shortUrlNew = "";
            int limit = 11;
            char[] letters = "abcdefghijklmnpqrstuvwxyz".ToCharArray();

            Random rand = new Random();
            for(var i = 0; i < limit; i++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                if (i == 4) { shortUrlNew += "."; }
                if (i == 7) { shortUrlNew += "/"; }
                shortUrlNew += letters[letter_num];
            }
            shortUrlNew = "http://" + shortUrlNew;
            var shortUrls = db.Links.Select(l => l.ShortUrl);

            foreach (var shortUrl in shortUrls)
            {
                if (shortUrl == shortUrlNew)
                {
                    return shortUrl;
                }
            }
            return shortUrlNew;
        }
    }
}
