using System;
using CroweDemo.Web.Areas.Demo.Models.Base;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Configuration.Fluent;


namespace CroweDemo.Web.Areas.Demo.Models.Pages
{
    [SitecoreType]
    public interface IHelloWorld : IBasePage
    {
        /// <summary>
        /// Gets or sets the title (The Hello World field in this instance)
        /// </summary>
        [SitecoreField(FieldName = "Title")]
        string Title { get; set; }


        /// <summary>
        ///  Base Template
        /// </summary>
        IBasePage CurrentPage { get; set; }
    }

    [SitecoreType]
    public class HelloWorld : IHelloWorld
    {
        public Guid Id { get; set; }
        public Guid TemplateId { get; set; }
        public string Name { get; set; }
        public string PageTitle { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public IBasePage CurrentPage { get; set; }
    }
}