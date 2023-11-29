using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmpProfileRepository : IRepository<EmpProfile>
    {
        private readonly EmsContext context;
        public EmpProfileRepository(EmsContext dbContext)
        {
            this.context = dbContext;
        }

        public IEnumerable<EmpProfile> GetAll()
        {
            return context.EmpProfiles.ToList();
        }

        public EmpProfile GetByCode(int code)
        {
            return context.EmpProfiles.FirstOrDefault(e => e.EmpCode == code);
        }

        public void Insert(EmpProfile entity)
        {
            context.EmpProfiles.Add(entity);
            Save();
        }

        public void Update(EmpProfile entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Delete(int code)
        {
            var entity = context.EmpProfiles.Find(code);
            if (entity != null)
            {
                context.EmpProfiles.Remove(entity);
                Save();
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
