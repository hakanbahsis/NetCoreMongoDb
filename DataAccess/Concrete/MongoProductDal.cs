using DataAccess.Abstract;
using DataAccess.Repository;
using DataAccess.Settings;
using Entity.Concrete;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class MongoProductDal : MongoRepositoryBase<Product>, IProductDal
    {
        public MongoProductDal(IOptions<MongoSettings> settings) : base(settings)
        {
        }
    }
}
