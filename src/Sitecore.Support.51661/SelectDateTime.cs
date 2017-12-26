using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.PageCodes;
using System.Globalization;

namespace Sitecore.ExperienceEditor.Speak.Dialogs
{
  public class SelectDateTime : PageCodeBase
  {
    private const string IsAmPmFormatParameter = "IsAMPMFormat";

    public Rendering SelectedTime
    {
      get;
      set;
    }

    public override void Initialize()
    {
      this.InitializeIsAmPmFormat();
    }

    private void InitializeIsAmPmFormat()
    {
      CultureInfo culture = Context.User.Profile.Culture;
      Assert.IsNotNull(culture, "Culture info iis null.");
      this.SelectedTime.Parameters["IsAMPMFormat"] = (!string.IsNullOrEmpty(culture.DateTimeFormat.AMDesignator) && !string.IsNullOrEmpty(culture.DateTimeFormat.PMDesignator)).ToString();
    }
  }
}