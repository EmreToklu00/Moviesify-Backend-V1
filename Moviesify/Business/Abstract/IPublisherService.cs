using Core.Utilities.Results;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        IDataResult<PublisherDTO> GetById(Guid publisherId);

        IDataResult<List<PublisherDTO>> GetList();

        IResult Add(PublisherDTO publisher);

        IResult Update(PublisherDTO publisher);

        IResult Delete(Guid publisherId);
    }
}
