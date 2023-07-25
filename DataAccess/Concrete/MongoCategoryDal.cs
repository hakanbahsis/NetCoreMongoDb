using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Repository;
using DataAccess.Settings;
using Entity.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class MongoCategoryDal : MongoRepositoryBase<Category>, ICategoryDal
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<Category> _collection;
        public MongoCategoryDal(IOptions<MongoSettings> settings) : base(settings)
        {
            _context = new MongoDbContext(settings);
            _collection=_context.GetCollection<Category>();
        }

        public async Task<IEnumerable<Category>> GetAl()
        {
            //var values = await _aboutCollection.Find(value => true).ToListAsync();
            //return Response<List<ResultAboutDto>>.Success(_mapper.Map<List<ResultAboutDto>>(values), 200);

            return await _collection.Find(_=>true).ToListAsync();
        }
    }
}
