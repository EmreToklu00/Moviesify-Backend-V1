using Core.Entities;

namespace Entity.DTO
{
    public class PublisherDTO: IEntity
    {
        public Guid PublisherId { get; set; }
        public DateTime EstablishedDate { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
