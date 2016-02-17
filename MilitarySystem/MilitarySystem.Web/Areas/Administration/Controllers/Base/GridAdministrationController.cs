using MilitarySystem.Services.Contracts;
using MilitarySystem.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using MilitarySystem.Models;
using AutoMapper.QueryableExtensions;
using MilitarySystem.Web.Areas.Administration.Models.InputModels;

namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    public abstract class GridAdministrationController<TDbModel, TViewModel> : BaseController
    {
        private IDataService<TDbModel> test;

        public GridAdministrationController(IDataService<TDbModel> weapons)
        {
            this.test = weapons;
        }

        [HttpPost]
        public virtual ActionResult Read([DataSourceRequest]DataSourceRequest request, Guid? id = null)
        {
            var data = this.test
                .GetAll().ProjectTo<WeaponInputModel>()
                .ToDataSourceResult(request);

            return this.Json(data);
        }

        [HttpPost]
        public virtual void Update([DataSourceRequest]DataSourceRequest request, TViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.Mapper.Map<TDbModel>(model);
                this.test.Update(dbModel);
            }
        }

        [HttpPost]
        public virtual void Destroy(object id)
        {
            this.test.Delete(id);
        }

        [HttpPost]
        public virtual void Destroy(TViewModel model)
        {

        }

        public JsonResult GridOperation(TViewModel model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        protected override IAsyncResult BeginExecute(System.Web.Routing.RequestContext requestContext, AsyncCallback callback, object state)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}