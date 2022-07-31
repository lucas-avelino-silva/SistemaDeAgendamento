namespace Bussines.Models
{
    public class Entity
    {
        public Entity()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
    }
}
