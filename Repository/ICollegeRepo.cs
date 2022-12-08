using TryWebAPI.Models;

namespace TryWebAPI.Repository
{
    public interface ICollegeRepo
    {
        College AddCollegeData(College colz);
        IEnumerable<College> GetAllCollegeData();
        College GetCollegeData(int id);
        College UpdateCollegeData(int id, College c);
        College DeleteCollegeData(int id);
    }
}
