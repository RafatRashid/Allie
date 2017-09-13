using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllieEntity;

namespace AllieData.DataAccessors
{
    class JournalDataAccessor : DataAccessorInterfaces.IJournalDataAccessor
    {
        private AllieContext Context;

        public JournalDataAccessor(AllieContext Context)
        {
            this.Context = Context;
        }

        public bool Delete(int id)
        {
            Journal c = Context.Journals.SingleOrDefault(x => x.Id == id);
            Context.Journals.Remove(c);
            Context.SaveChanges();
            return true;
        }

        public Journal Get(int id)
        {
            return Context.Journals.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Journal> GetAll()
        {
            return Context.Journals.ToList();
        }

        public bool Insert(Journal journal)
        {
            Context.Journals.Add(journal);
            Context.SaveChanges();
            //return Context.Journals.SingleOrDefault(x => x.JournalName == journal.JournalName);
            return true;
        }

        public bool Update(Journal journal)
        {
            this.Delete(journal.Id);
            this.Insert(journal);
            Context.SaveChanges();
            return true;
        }
    }
}
