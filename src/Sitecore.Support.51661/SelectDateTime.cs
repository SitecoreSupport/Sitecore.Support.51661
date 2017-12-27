using Sitecore.Mvc.Presentation;
using Sitecore.StringExtensions;
using System.Globalization;
using Sitecore.Globalization;

namespace Sitecore.Support.ExperienceEditor.Speak.Dialogs
{
  public class SelectDateTime : Sitecore.ExperienceEditor.Speak.Dialogs.SelectDateTime
  {
    private const string IsAmPmFormatParameter = "IsAMPMFormat";

    public Rendering SelectedDate { get; set; }

    public override void Initialize()
    {
      base.Initialize();
      if (this.SelectedDate.Parameters["Format"].IsNullOrEmpty())
      {
        string culture = Context.User.Profile.RegionalIsoCode.ToLowerInvariant();
        CultureInfo currentCulture = Language.CreateCultureInfo(culture, false);
        if (currentCulture != null)
        {
          this.SelectedDate.Parameters["Format"] = currentCulture.DateTimeFormat.ShortDatePattern.ToLowerInvariant();
        }
      }
    }
  }
}