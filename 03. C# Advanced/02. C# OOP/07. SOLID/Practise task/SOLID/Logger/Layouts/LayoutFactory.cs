using SOLID.Layouts.Interfaces;
using System;

namespace SOLID.Layouts
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout = null;
            type = type.ToLower();

            if (type == "simplelayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "xmllayout")
            {
                layout = new XmlLayout();

            }

            if (layout != null)
            {
                return layout;
            }
            else
            {
                throw new InvalidOperationException("Invalid layout type!");
            }

        }
    }
}
