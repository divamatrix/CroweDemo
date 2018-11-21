using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;
using NSubstitute;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CroweDemo.Tests.Areas.Controllers
{
    public class GlassControllerTestHarnessBase
    {
        public GlassControllerTestHarnessBase()
        {
            RequestContext = Substitute.For<IRequestContext>();
            GlassHtml = Substitute.For<IGlassHtml>();
            RenderingContext = Substitute.For<RenderingContext>();
            HttpContext = Substitute.For<HttpContextBase>();
        }

        public RenderingContext RenderingContext { get; }
        public IGlassHtml GlassHtml { get; }
        public IRequestContext RequestContext { get; }
        public HttpContextBase HttpContext { get; }
    }
}
