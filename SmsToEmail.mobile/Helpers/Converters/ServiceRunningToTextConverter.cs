using CommunityToolkit.Maui.Converters;

namespace SmsToEmail.mobile.Helpers.Converters
{
    public class ServiceRunningToTextConverter : BaseConverterOneWay<bool, string>
    {
        public override string ConvertFrom(bool isRunning, CultureInfo culture)
        {
            if (isRunning)
            {
                return "running";
            }
            return "not running";
        }

        public override string DefaultConvertReturnValue { get; set; }
    }
}
