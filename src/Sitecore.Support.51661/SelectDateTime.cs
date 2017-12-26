using Sitecore.Mvc.Presentation;
using Sitecore.StringExtensions;
using System.Globalization;

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
        CultureInfo culture = Context.User.Profile.Culture;
        if (culture != null && culture.DateTimeFormat != null)
        {
          this.SelectedDate.Parameters["Format"] = culture.DateTimeFormat.ShortDatePattern;
        }
      }
    }
  }
}