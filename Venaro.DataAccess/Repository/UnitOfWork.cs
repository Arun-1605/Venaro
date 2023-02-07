﻿
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
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Clothes = new ClothRepository(_db);
			Category = new CategoryRepository(_db);
        }
      
        public IClothRepository Clothes {  get; private set; }
      
		public ICategoryRepository Category { get; private set; }

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}