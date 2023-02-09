using System;
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

		void Save();
    }
}
