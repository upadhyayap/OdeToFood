using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlResturantData : IResturantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlResturantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Resturant Add(Resturant newResturant)
        {
            db.Add(newResturant);
            commit();

            return newResturant;
        }

        public int commit()
        {
           return  db.SaveChanges();
        }

        public Resturant delete(int resturantId)
        {
            var resturant = getById(resturantId);
            if (resturant != null)
            {
                db.Remove(resturant);
                commit();
            }

            return resturant;
        }

        public Resturant getById(int id)
        {
            return db.Resturants.Find(id);
        }

        public int getResturantCount()
        {
            return db.Resturants.Count();
        }

        public IEnumerable<Resturant> GetResturantsByName(string name = null)
        {
            return from r in db.Resturants
                   where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                   orderby r.Name
                   select r;
        }

        public Resturant update(Resturant updatedResturant)
        {
            var entity = db.Resturants.Attach(updatedResturant);
            entity.State = EntityState.Modified;

            commit();

            return updatedResturant;
        }
    }
}
