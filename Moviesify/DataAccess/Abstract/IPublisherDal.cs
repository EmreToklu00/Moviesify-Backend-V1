﻿using Core.DataAccess;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPublisherDal : IEntityRepository<Publisher>
    {
    }
}
