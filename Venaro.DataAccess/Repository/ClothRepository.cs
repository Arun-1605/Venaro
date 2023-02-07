using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venaro.Data;
using Venaro.DataAccess.Repository.IRepository;
using Venaro.Models;

namespace Venaro.DataAccess.Repository
{
    public class ClothRepository : Repository<Clothes>, IClothRepository
    {
        private ApplicationDbContext _db;

        public ClothRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Clothes obj)
        {
            
        }
    }
}
