using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace OdeToFood.Data
{
    public class InMemoryResturantData : IResturantData
    {
        readonly List<Resturant> resturants;
        public InMemoryResturantData()
        {
            resturants = new List<Resturant>()
               {
                   new Resturant {Id = 1, Name = "Scott Pizza", Location = "Maryland", Cuisine = CuisineType.Mexican },
                   new Resturant {Id = 2, Name = "Break the fast", Location = "Hyderabad", Cuisine = CuisineType.Indian }
               };
        }

        public Resturant Add(Resturant newResturant)
        {
            resturants.Add(newResturant);
            newResturant.Id = resturants.Max((r) => r.Id);

            return newResturant;
        }

        public int commit()
        {
            return 0;
        }

        public Resturant delete(int resturantId)
        {
            Resturant resturant = resturants.FirstOrDefault((r) => r.Id == resturantId);
            resturants.Remove(resturant);

            return resturant;
        }

        public Resturant getById(int id)
        {
            return resturants.Find((resturant) => resturant.Id == id);
        }

        public int getResturantCount()
        {
            return resturants.Count;
        }

        public IEnumerable<Resturant> GetResturantsByName(string name = null)
        {
            return from r in resturants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Resturant update(Resturant updatedResturant)
        {
            Resturant resturant = resturants.SingleOrDefault((r) => r.Id == updatedResturant.Id);
            if(resturant != null)
            {
                resturant.Id = updatedResturant.Id;
                resturant.Name = updatedResturant.Name;
                resturant.Location = updatedResturant.Location;
                resturant.Cuisine = updatedResturant.Cuisine;
            }

            return resturant;
        }
    }
}
