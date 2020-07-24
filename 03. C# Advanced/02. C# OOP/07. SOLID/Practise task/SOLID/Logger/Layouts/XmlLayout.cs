using SOLID.Layouts.Interfaces;
using System;

namespace SOLID.Layouts
{
    public class XmlLayout : ILayout
    {
        public string FormattedMessage()
        {
            string result = "<log>" + Environment.NewLine;
            result += "   <date>{0}</date>" + Environment.NewLine;
            result += "   <level>{1}</level>" + Environment.NewLine;
            result += "   <message>{2}</message>" + Environment.NewLine;
            result += "</log";

            return result;
        }
    }
}
