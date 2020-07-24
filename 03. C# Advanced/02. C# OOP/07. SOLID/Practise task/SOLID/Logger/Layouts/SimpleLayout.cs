using SOLID.Layouts.Interfaces;

namespace SOLID.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string FormattedMessage()
        {
            return "{0} - {1} - {2}";
        }

    }
}
