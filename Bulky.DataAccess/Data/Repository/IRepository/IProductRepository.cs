﻿using Bulky.Models;

namespace Bulky.DataAccess.Data.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
