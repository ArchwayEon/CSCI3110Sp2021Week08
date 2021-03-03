using LINQLecture.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQLecture.Services
{
	public class DbSupplierPartsRepository : ISupplierPartsRepository
	{
		private readonly SupplierPartDbContext _db;

		public DbSupplierPartsRepository(SupplierPartDbContext db)
		{
			_db = db;
		}

		public IQueryable<SupplierPart> ReadAllSupplierParts()
		{
			return _db.SupplierParts
			  .Include(sp => sp.Supplier)
			  .Include(sp => sp.Part);
		}
	}
}
