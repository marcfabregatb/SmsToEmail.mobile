using CommunityToolkit.Maui.Converters;
using SmsToEmail.mobile.Infrastructure;

namespace SmsToEmail.mobile.Helpers.Converters
{
    public class ServiceRunningToColorConverter : BaseConverterOneWay<bool, Color>
    {
        public override Color ConvertFrom(bool isRunning, CultureInfo culture)
        {
            if (isRunning)
            {
                return StyleResourcesProvider.GetColorResource("Green600") as Color;
            }
            return StyleResourcesProvider.GetColorResource("Red600") as Color;
        }

        public override Color DefaultConvertReturnValue { get; set; }
    }
}
