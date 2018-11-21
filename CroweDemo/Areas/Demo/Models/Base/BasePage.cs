using System;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CroweDemo.Web.Areas.Demo.Models.Base
{
    [SitecoreType]
    public interface IBasePage : IBaseContent
    {
        /// <summary>
        /// Gets or sets the page title.
        /// </summary>
        [SitecoreField(FieldName = "PageTitle")]
        string PageTitle { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        [SitecoreInfo(SitecoreInfoType.Url)]
        string Url { get; set; }
    }
}