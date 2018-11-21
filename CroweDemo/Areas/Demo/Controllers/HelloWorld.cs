using System.Web;
using System.Web.Mvc;
using CroweDemo.Web.Areas.Demo.Repositories;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;
using Sitecore.Mvc.Presentation;

namespace CroweDemo.Web.Areas.Demo.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly HelloWorldRepository helloWorldRepository;

        public HelloWorldController(IRequestContext requestContext, IGlassHtml glassHtml, RenderingContext renderingContextWrapper, HttpContextBase httpContext) 
        {
            helloWorldRepository = new HelloWorldRepository();
        }
        public HelloWorldController()
        {
            helloWorldRepository = new HelloWorldRepository();
        }

        public ActionResult Index()
        {
            var model = helloWorldRepository.Get(RenderingContext.CurrentOrNull.ContextItem);
            return View(model);
        }
    }
}