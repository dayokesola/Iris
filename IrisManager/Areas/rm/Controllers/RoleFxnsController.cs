using com.iris;
using com.iris.RoleManager.DTO;
using com.iris.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IrisManager.Areas.rm.Controllers
{
    public class RoleFxnsController : IrisController
    {
        private IrisDbContext db = new IrisDbContext();
        //
        // GET: /rm/RoleFxns/1
        public ActionResult Role(int? roleId)
        {
            if (roleId == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                roleId = 1;
            }

            var fxns = db.Fxns.ToList();
            var roleFxns = db.RoleFxns.Where(x => x.RoleId == roleId).ToList();

            //f.Id, f.FxnName, f.AppId, f.FxnUrl, f.FxnSecured, rf.RoleId

            var query = from f in fxns
                        join r in roleFxns on f.Id equals r.FxnId into rs
                        from cl in rs.DefaultIfEmpty()
                        select new RoleFxnDTO
                        {
                            Id = f.Id,
                            FxnName = f.FxnName,
                            FxnUrl = f.FxnUrl,
                            AppId = f.AppId,
                            FxnSecured = f.FxnSecured,
                            RoleAllowed = (rs.Select(z => z.FxnId).SingleOrDefault() != 0)
                        };

            ViewBag.DataList = query.ToList();
            return View();
        }
	}
}