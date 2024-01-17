
namespace Data.Concrete
{
    using Data.Abstract;
    using Data.Concrete.Base;
    using Data.Db;
    using Data.Models;
    using System.Collections.Generic;

    public class EfAccountDal : EfEntityRepositoryBase<Account, ThesesContext>, IAccountDal
    {
        public List<Account> GetModelById(int id)
        {
            using (var db = new ThesesContext())
            {
                var result = (from a in db.ACCOUNTS
                              join r in db.ROLES
                              on a.ROLEID equals r.ROLEID
                              where a.ID == id
                              select new Account
                              {
                                  ID = a.ID,
                                  PASSWORD = a.PASSWORD,
                                  Role = r,
                                  ROLEID = r.ROLEID,
                                  USERNAME = a.USERNAME,
                              }

                              ).ToList();
                return result;
            }
            
        }
        public List<Account> GetModelByUsername(string username)
        {
            using (var db = new ThesesContext())
            {
                var result = (from a in db.ACCOUNTS
                              join r in db.ROLES
                              on a.ROLEID equals r.ROLEID
                              where a.USERNAME == username
                              select new Account
                              {
                                  ID = a.ID,
                                  PASSWORD = a.PASSWORD,
                                  Role = r,  // Burada Role nesnesine ROLEID atandı
                                  ROLEID = r.ROLEID,  // Burada ROLEID tekrar atanıyor
                                  USERNAME = a.USERNAME,
                              }).ToList();

                return result; 
            }

        }
    }
}
