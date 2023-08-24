using Core.Entities;

namespace Entity.Models
{
    public class Movie : IEntity
    {
        public Guid MovieId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid PublisherId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishYear { get; set; }
        public string ImageUrl { get; set; }

        public double IMDb { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual Category Category { get; set; }


    }
}
