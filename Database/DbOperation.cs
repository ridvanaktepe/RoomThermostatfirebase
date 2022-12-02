using Microsoft.EntityFrameworkCore;
using firebase.Models;

namespace firebase.Database
{
    public class DbOperation: IDbOperation
    {
        private readonly DatabaseContext dbcontext;

        public DbOperation(DatabaseContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public async Task Create(List<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                await dbcontext.Set<Room>().AddAsync(room);
            }
            await dbcontext.SaveChangesAsync();
        }
    }
}