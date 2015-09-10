using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddDemo.Contracts;
using TddDemo.DataAccess;
using AutoMapper;
using System.ServiceModel;

namespace TddDemo
{
    public class SchoolService : ISchoolService
    {
        static SchoolService()
        {
            Mapper.CreateMap<DataAccess.Person, DataContracts.Person>().ForMember(m => m.Id, opt => opt.MapFrom(src => src.PersonID));
            Mapper.CreateMap<DataContracts.Person, DataAccess.Person>().ForMember(m => m.PersonID, opt => opt.MapFrom(src => src.Id));
        }

        private SchoolContext db;

        public SchoolService(SchoolContext db)
        {
            this.db = db;
        }

        public SchoolService() 
            :this (new SchoolContext())
        {
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public DataContracts.Person AddPerson(DataContracts.Person person)
        {
            var input = Mapper.Map<DataAccess.Person>(person);
            db.People.Add(input);
            db.SaveChanges();

            var result = Mapper.Map<DataContracts.Person>(input);
            return result;
        }
    }
}
