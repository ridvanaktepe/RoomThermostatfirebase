using firebase.Models;

namespace firebase.Database
{
    public interface IDbOperation
    {
         Task Create(List<Room> rooms);
    }
}