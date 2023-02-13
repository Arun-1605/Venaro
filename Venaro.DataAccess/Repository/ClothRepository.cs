using Microsoft.EntityFrameworkCore;
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
    public class ClothRepository : Repository<Product>, IClothRepository
    {
        private ApplicationDbContext _db;

        public ClothRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Product obj)
        {
           var objfromDb = _db.Clothes.FirstOrDefault(u => u.Id == obj.Id);

            if (objfromDb != null)
            {
                objfromDb.Name = obj.Name;
                objfromDb.Description = obj.Description;
                objfromDb.Category = obj.Category;
                objfromDb.Price = obj.Price;
                objfromDb.ListPrice = obj.ListPrice;
                objfromDb.IsSold = obj.IsSold;
                

                if(obj.Image != null)
                {
                    objfromDb.Image = obj.Image;
                }

            }
            
        }
    }
}
