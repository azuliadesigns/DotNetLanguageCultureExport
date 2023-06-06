using System.Globalization;
using System.Text;
using System.Web;

CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
StringBuilder data = new StringBuilder();
data.AppendLine("ID,\"Country\",\"Language\",\"TwoLetterISORegionName\",\"ThreeLetterISORegionName\",\"TwoLetterISOLanguageName\",\"ThreeLetterISOLanguageName\",\"CultureInfo\"");
int c = 1;

foreach (CultureInfo cul in cinfo)
{
    try
    {
        RegionInfo ri = new RegionInfo(cul.Name);   

        string Country = HttpUtility.HtmlEncode(ri.EnglishName);
        string Language = HttpUtility.HtmlEncode(cul.EnglishName);
        string Native = HttpUtility.HtmlEncode(cul.NativeName);
        string TwoLetterISORegionName = ri.TwoLetterISORegionName;
        string ThreeLetterISORegionName = ri.ThreeLetterISORegionName;
        string TwoLetterISOLanguageName = cul.TwoLetterISOLanguageName;
        string ThreeLetterISOLanguageName = cul.ThreeLetterISOLanguageName;
        string CultureInfo = cul.Name;

        data.AppendLine(string.Format("{0},\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"", c, Country, Language, TwoLetterISORegionName, ThreeLetterISORegionName, TwoLetterISOLanguageName, ThreeLetterISOLanguageName, CultureInfo));
        c++;
    }
    catch
    {
        continue;
    }
}

File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DotNetLanguagesAndCultures.csv"), data.ToString());
