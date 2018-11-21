using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using CroweDemo.Web.Areas.Demo.Models.Base;
using CroweDemo.Web.Areas.Demo.Models.Pages;
using CroweDemo.Web.Extensions;

namespace CroweDemo.Web.Areas.Demo.Repositories
{
    public interface IHelloWorldRepository
    {
        IHelloWorld Get(Item contextItem);
    }
    public class HelloWorldRepository : IHelloWorldRepository
    {
        public IHelloWorld Get(Item contextItem)
        {
            if (contextItem.TemplateName != "HelloWorld")
            {
                throw new ArgumentNullException(nameof(contextItem));
            }

            return new HelloWorld()
            {
                Id = contextItem.ID.ToGuid(),
                TemplateId = contextItem.TemplateID.ToGuid(),
                Name = contextItem.Name,
                PageTitle = contextItem.Fields["PageTitle"].HasValue ? contextItem["PageTitle"] : contextItem.Name,
                Url = LinkManager.GetDynamicUrl(contextItem),
                Title = contextItem.Fields["Title"].ToString()
            };

        }
    }
}