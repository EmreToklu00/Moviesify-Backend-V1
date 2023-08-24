using Business.Abstract;
using Business.Constants.Results;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.DTO;
using Entity.Models;

namespace Business.Concrete
{
    public class PublisherManager : IPublisherService
    {
        IPublisherDal _publisherDal;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }
        public IResult Add(PublisherDTO publisher)
        {
            Publisher entity = new Publisher()
            {
                PublisherId=publisher.PublisherId,
                Name = publisher.Name,
                Email=publisher.Email,
                Address = publisher.Address,
                EstablishedDate = publisher.EstablishedDate,
            };
            _publisherDal.Add(entity);
            return new SuccessResult(message: ResultMessages.PUBLISHER_ADDED);
        }

        public IResult Delete(Guid publisherId)
        {
            Publisher entity = _publisherDal.Get(m => m.PublisherId == publisherId);
            _publisherDal.Delete(entity);
            return new SuccessResult(message: ResultMessages.PUBLISHER_DELETED);
        }

        public IDataResult<PublisherDTO> GetById(Guid publisherId)
        {
            Publisher entity = _publisherDal.Get(m => m.PublisherId == publisherId);
            PublisherDTO response = new PublisherDTO()
            {
                PublisherId=publisherId,    
                Name = entity.Name,
                Email = entity.Email,
                EstablishedDate = entity.EstablishedDate,
                Address = entity.Address  
            };
            return new SuccessDataResult<PublisherDTO>(response);
        }

        public IDataResult<List<PublisherDTO>> GetList()
        {
            List<Publisher> entityList = _publisherDal.GetAll().ToList();
            List<PublisherDTO> responseList = new List<PublisherDTO>();
            foreach (var publisher in entityList)
            {
                var movieDTO = new PublisherDTO()
                {
                    PublisherId = publisher.PublisherId,
                    Name = publisher.Name,   
                    Email = publisher.Email, 
                    Address = publisher.Address,
                    EstablishedDate=publisher.EstablishedDate,
                };
                responseList.Add(movieDTO);
            }
            return new SuccessDataResult<List<PublisherDTO>>(responseList);
        }

        public IResult Update(PublisherDTO publisher)
        {
            Publisher entity = _publisherDal.Get(m => m.PublisherId == publisher.PublisherId);
            entity.Name = publisher.Name;
            entity.Email = publisher.Email;
            entity.Address = publisher.Address;
            entity.EstablishedDate = publisher.EstablishedDate;
            _publisherDal.Update(entity);
            return new SuccessResult(message: ResultMessages.PUBLISHER_UPDATED);
        }
    }
}
