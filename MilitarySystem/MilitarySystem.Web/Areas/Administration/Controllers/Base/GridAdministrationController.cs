﻿using MilitarySystem.Services.Contracts;
using MilitarySystem.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Kendo.Mvc.UI;
//using Kendo.Mvc.Extensions;

namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    public abstract class GridAdministrationController<TDbModel, TViewModel> : BaseController
    {
        private IDataService<TDbModel> weapons;

        public GridAdministrationController(IDataService<TDbModel> weapons)
        {
            this.weapons = weapons;
        }

        //[HttpPost]
        //public virtual ActionResult Read(/*[DataSourceRequest]DataSourceRequest request, Guid? id = null*/)
        //{
        //    var data = this.weapons
        //        .GetAll()
        //        .AsQueryable()
        //        .Project()
        //        .To<TViewModel>()
        //        .ToDataSourceResult(request);

        //    return this.Json(data);
        //}

        //[NonAction]
        //protected virtual void Update(TViewModel model)
        //{
        //    if (model != null && ModelState.IsValid)
        //    {
        //        var dbModel = this.administrationService.Get(model.Id);
        //        Mapper.Map<TViewModel, TDbModel>(model, dbModel);
        //        this.administrationService.Update(dbModel);
        //    }
        //}

        //[NonAction]
        //protected virtual void Destroy(object id)
        //{
        //    this.administrationService.Delete(id);
        //}

        //[NonAction]
        //protected virtual void Destroy(TViewModel model)
        //{
        //    if (model != null && ModelState.IsValid)
        //    {
        //        this.administrationService.Delete(model.Id);
        //    }
        //}

        //protected JsonResult GridOperation(TViewModel model, [DataSourceRequest]DataSourceRequest request)
        //{
        //    return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        //}

        //protected override IAsyncResult BeginExecute(System.Web.Routing.RequestContext requestContext, AsyncCallback callback, object state)
        //{
        //    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        //    return base.BeginExecute(requestContext, callback, state);
        //}
    }
}