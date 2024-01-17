
namespace Data.Concrete
{
    #region usings
    using Data.Abstract;
    using Data.Concrete.Base;
    using Data.Db;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    #endregion
    public class EfThesisDal : EfEntityRepositoryBase<Thesis, ThesesContext>, IThesisDal
    {
        public List<Thesis> GetAllOfModel()
        {
            using (var db = new ThesesContext())
            {
                var result = (from t in db.THESES
                              join u in db.UNIVERSITIES
                              on t.UNIVERSITYID equals u.UNIVERSITYID
                              join s in db.SUPERVISORS
                              on t.SUPERVISORID equals s.SUPERVISORID
                              join i in db.INSTITUTES
                              on t.INSTITUTEID equals i.INSTITUTEID
                              join a in db.AUTHORS
                              on t.AUTHORID equals a.AUTHORID
                              select new Thesis
                              {
                                  ABSTRACT = t.ABSTRACT,
                                  AUTHORID = t.AUTHORID,
                                  AUTHOR = a,
                                  INSTITUTE = i,
                                  INSTITUTEID = t.INSTITUTEID,
                                  LANGUAGE = t.LANGUAGE,
                                  NUMBER = t.NUMBER,
                                  PAGES = t.PAGES,
                                  SUBMISSIONDATE = t.SUBMISSIONDATE,
                                  SUPERVISOR = s,
                                  SUPERVISORID = t.SUPERVISORID,
                                  THESISID = t.THESISID,
                                  THESISYEAR = t.THESISYEAR,
                                  TITLE = t.TITLE,
                                  TYPE = t.TYPE,
                                  UNIVERSITY = t.UNIVERSITY,
                                  UNIVERSITYID = t.UNIVERSITYID,
                                  
                              }).ToList();
                return result;

            }
        }
        public List<Thesis> GetAllOfModelByNumber(int number)
        {
            using (var db = new ThesesContext())
            {
                var result = (from t in db.THESES
                              join u in db.UNIVERSITIES
                              on t.UNIVERSITYID equals u.UNIVERSITYID
                              join s in db.SUPERVISORS
                              on t.SUPERVISORID equals s.SUPERVISORID
                              join i in db.INSTITUTES
                              on t.INSTITUTEID equals i.INSTITUTEID
                              join a in db.AUTHORS
                              on t.AUTHORID equals a.AUTHORID
                              where t.NUMBER == number
                              select new Thesis
                              {
                                  ABSTRACT = t.ABSTRACT,
                                  AUTHORID = t.AUTHORID,
                                  AUTHOR = a,
                                  INSTITUTE = i,
                                  INSTITUTEID = t.INSTITUTEID,
                                  LANGUAGE = t.LANGUAGE,
                                  NUMBER = t.NUMBER,
                                  PAGES = t.PAGES,
                                  SUBMISSIONDATE = t.SUBMISSIONDATE,
                                  SUPERVISOR = s,
                                  SUPERVISORID = t.SUPERVISORID,
                                  THESISID = t.THESISID,
                                  THESISYEAR = t.THESISYEAR,
                                  TITLE = t.TITLE,
                                  TYPE = t.TYPE,
                                  UNIVERSITY = t.UNIVERSITY,
                                  UNIVERSITYID = t.UNIVERSITYID,
                                  
                              }).ToList();
                return result;

            }
        }

        public List<Thesis> GetAllByUsername(string username)
        {
            using (var db = new ThesesContext())
            {
                var result = (from t in db.THESES
                              join u in db.UNIVERSITIES
                              on t.UNIVERSITYID equals u.UNIVERSITYID
                              join s in db.SUPERVISORS
                              on t.SUPERVISORID equals s.SUPERVISORID
                              join i in db.INSTITUTES
                              on t.INSTITUTEID equals i.INSTITUTEID
                              join a in db.AUTHORS
                              on t.AUTHORID equals a.AUTHORID
                              where (a.AUTHORNAME + a.LASTNAME).Replace(" ","").ToLower() == username
                              select new Thesis
                              {
                                  ABSTRACT = t.ABSTRACT,
                                  AUTHORID = t.AUTHORID,
                                  AUTHOR = a,
                                  INSTITUTE = i,
                                  INSTITUTEID = t.INSTITUTEID,
                                  LANGUAGE = t.LANGUAGE,
                                  NUMBER = t.NUMBER,
                                  PAGES = t.PAGES,
                                  SUBMISSIONDATE = t.SUBMISSIONDATE,
                                  SUPERVISOR = s,
                                  SUPERVISORID = t.SUPERVISORID,
                                  THESISID = t.THESISID,
                                  THESISYEAR = t.THESISYEAR,
                                  TITLE = t.TITLE,
                                  TYPE = t.TYPE,
                                  UNIVERSITY = t.UNIVERSITY,
                                  UNIVERSITYID = t.UNIVERSITYID,

                              }).ToList();
                return result;

            }
        }
    }
}
