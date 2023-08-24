using Core.Entities;

namespace Entity.Models
{
    public class Category : IEntity
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

    }
}
