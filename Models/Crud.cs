using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace LinkApp.Models
{
    public class Crud
    {
        public async static Task Edit(Link link, ApplicationContext db)
        {
            var linkChoose = db.Links.Where(l => l.Id == link.Id).Single();
            linkChoose.Url = link.Url;
            linkChoose.Transition = 0;
            linkChoose.ShortUrl = LinkMethod.Short(link.Url, db);
            await db.SaveChangesAsync();
        }
        public async static Task Create(Link link, ApplicationContext db)
        {
            db.Links.Add(new Link() { Url = link.Url, Date = DateTime.Now, Transition = 0, ShortUrl = LinkMethod.Short(link.Url, db) });
            await db.SaveChangesAsync();
        }
        public async static Task Delete(int? id, ApplicationContext db)
        {
            Link link = new Link { Id = id.Value };
            db.Entry(link).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }
    }
}
