using StudentRideManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Repositories
{
    public interface IRiderRepository
    {
        Rider GetRider(int id);
        IEnumerable<Rider> GetAllRiders();
        Rider Add(Rider rider);
        Rider Update(Rider riderChanges);
        Rider Delete(int id);
    }
}
