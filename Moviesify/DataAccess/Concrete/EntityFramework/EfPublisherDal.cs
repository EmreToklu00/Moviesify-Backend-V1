using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPublisherDal : EfCoreEntityRepository<Publisher, MoviesifyContext>, IPublisherDal
    {
    }
}
