using Core.Entities;

namespace Entity.Models
{
    public class Publisher : IEntity
    {
        public Guid PublisherId { get; set; }
        public DateTime EstablishedDate { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

    }
}
