using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAPROC_RanchoNuevo.Controllers;
using SAPROC_RanchoNuevo.Models;

namespace SAPROC_RanchoNuevo.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var Ouser = (usuario)HttpContext.Current.Session["Usuario"];

            if (Ouser == null)
            {
                if (filterContext.Controller is AccesController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acces/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccesController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}