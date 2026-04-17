using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Sitrep.ApiService.Utils;

public static class SlugHelper
{
    public static string Slugify(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        // Normalize (remove accents)
        var normalized = input.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        foreach (var c in normalized)
        {
            var unicodeCategory = Char.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }

        var cleaned = sb.ToString().Normalize(NormalizationForm.FormC);

        // Lowercase
        cleaned = cleaned.ToLowerInvariant();

        // Remove invalid chars
        cleaned = Regex.Replace(cleaned, @"[^a-z0-9\s-]", "");

        // Convert multiple spaces into one
        cleaned = Regex.Replace(cleaned, @"\s+", " ").Trim();

        // Replace spaces with hyphens
        cleaned = cleaned.Replace(" ", "-");

        // Collapse multiple hyphens
        cleaned = Regex.Replace(cleaned, @"-+", "-");

        return cleaned;
    }
}