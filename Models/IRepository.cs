namespace LinkApp.Models
{
    public interface IRepository
    {
        IEnumerable<Link> GetAll();
        Link Get(int id);
        void Create(Link user);
    }
}
