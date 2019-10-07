using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IResturantData
    {
        IEnumerable<Resturant> GetResturantsByName(string name = null);
        Resturant getById(int id);
        Resturant update(Resturant updatedResturant);
        Resturant Add(Resturant newResturant);
        Resturant delete(int resturantId);
        int commit();
        int getResturantCount();
    }
}
