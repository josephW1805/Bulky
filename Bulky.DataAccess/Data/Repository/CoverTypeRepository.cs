using Bulky.DataAccess.Data;
using Bulky.DataAccess.Data.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository;

public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
{
	private ApplicationDbContext _db;
	public CoverTypeRepository(ApplicationDbContext db) : base(db)
	{
		_db = db;
	}

	public void Update(CoverType obj)
	{
		_db.CoverType.Update(obj);
	}
}
