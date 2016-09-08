using com.iris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IrisDbContext db = new IrisDbContext();
            var fxns = db.Fxns.ToList();
            var roleFxns = db.RoleFxns.Where(x => x.RoleId == 1).ToList();

            var query = from f in fxns
                        join r in roleFxns on f.Id equals r.FxnId into rs
                        from cl in rs.DefaultIfEmpty()
                        select new
                        {
                            f.Id,
                            f.FxnName,
                            f.FxnUrl,
                            f.AppId,
                            f.FxnSecured,
                            RoleAllowed = (rs.Select(z =>z.FxnId).SingleOrDefault() == 0)
                        };

            var dt = query.ToList();



        }
    }
}
