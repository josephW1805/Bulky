﻿using Bulky.DataAccess.Data.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Data.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company obj)
        {
            _db.Company.Update(obj);
        }
    }
}
