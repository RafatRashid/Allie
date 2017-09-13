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

        public Journal Get(int companyId, DateTime period)
        {
            return Context.Journals.SingleOrDefault
                (x => x.JournalPeriod.Month == period.Month &&
                x.JournalPeriod.Year == period.Year &&
                x.CompanyId == companyId);
        }

        public IEnumerable<Journal> GetAll()
        {
            return Context.Journals.ToList();
        }

        public IEnumerable<Journal> GetAll(int companyId)
        {
            return Context.Journals.Where(x => x.CompanyId == companyId).ToList();
        }

        public bool Insert(Journal journal)
        {
            Context.Journals.Add(journal);
            Context.SaveChanges();
            return true;
        }

        public bool Update(Journal journal)
        {
            Journal j = Context.Journals.SingleOrDefault(x => x.Id == journal.Id);

            j.JournalDescription = journal.JournalDescription;
            j.LedgerId = journal.LedgerId;

            Context.SaveChanges();
            return true;
        }
    }
}
