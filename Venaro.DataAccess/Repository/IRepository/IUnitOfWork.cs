﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venaro.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IClothRepository Clothes { get; }

        ICategoryRepository Category { get; }

        ICompanyRepository Company { get; }

        IShoppingCartRepository ShoppingCart { get; }

        IApplicationUserRepository ApplicationUser { get; }

		ISizeRepository Size { get; }

		IColorRepository Color { get; }

		IOrderHeaderRepository OrderHeader { get; }

		IOrderDetailsRepository OrderDetails { get; }

		//IMensWearRepository MensWear { get; }

		//IWomensWearRepository WomensWear { get; }

		void Save();
    }
}
