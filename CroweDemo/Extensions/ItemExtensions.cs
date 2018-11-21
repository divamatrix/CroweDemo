using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CroweDemo.Web.Extensions
{
    public static class ItemExtensions
    {
        public static bool IsDerivedFromTemplate(this Item item, ID templateId)
        {
            if (item == null) return false;

            if (templateId.IsNull) return false;

            var templateItem = item.Database.Templates[templateId];
            var returnValue = false;

            if (templateItem != null)
            {
                var template = TemplateManager.GetTemplate(item);
                if (template != null
                    && (template.ID == templateItem.ID || template.DescendsFrom(templateItem.ID)))
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }
    }
}