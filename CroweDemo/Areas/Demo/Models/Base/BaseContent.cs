using System;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CroweDemo.Web.Areas.Demo.Models.Base
{
    [SitecoreType]
    public interface IBaseContent
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [SitecoreId]
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the template id.
        /// </summary>
        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        Guid TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [SitecoreInfo(SitecoreInfoType.Name)]
        string Name { get; set; }
    }
}