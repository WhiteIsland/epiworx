using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epiworx.WebMvc.Helpers
{
    public class XmlResult : ActionResult
    {
        public object Data { get; set; }
        public string TableName { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (this.Data != null)
            {
                context.HttpContext.Response.Clear();

                var oa = new Csla.Data.ObjectAdapter();
                var ds = new DataSet();

                oa.Fill(ds, this.TableName, this.Data);

                var xs = new System.Xml.Serialization.XmlSerializer(ds.GetType());

                context.HttpContext.Response.ContentType = "text/xml";

                xs.Serialize(context.HttpContext.Response.Output, ds);
            }
        }
    }
}