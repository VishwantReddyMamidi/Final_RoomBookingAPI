
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using RoomBookingDataAccessLayer;
using RoomBookingEntityFrameworkDataAccess;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {
        private RoomBookingContext _context;

        public EFGenericRepository()
        {
            _context = new RoomBookingContext();
        }
        public void Add(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Added;
            }
            _context.SaveChanges();
        }


        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (Expression<Func<T, object>> property in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(property);
            }

            return dbQuery.ToList();
        }


        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Modified;

            }
            _context.SaveChanges();
        }
    }
}
