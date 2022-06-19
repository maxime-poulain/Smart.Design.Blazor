using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Smart.Design.Blazor;

public partial class SmartSideMenuItem : ComponentBase
{
    private bool _isActive;

    private List<string?>? _hrefAbsolutes;

    [CascadingParameter]
    internal SideMenuContext? CascadedSideMenuContext { get; set; } = default!;

    [Parameter]
    public string Label { get; set; } = string.Empty;

    [Parameter]
    public string HRef { get; set; } = string.Empty;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    public override Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        if (CascadedSideMenuContext is null)
        {
            throw new InvalidOperationException($"{GetType()} requires a cascading parameter " +
                                                $"of type {nameof(SmartSideMenu.SideMenuContext)}. For example, you can use {GetType().FullName} inside " +
                                                $"an {nameof(SmartSideMenu)}.");
        }

        MakeHrefAbsolutes();
        _isActive = ShouldMatch(NavigationManager.Uri);

        return base.SetParametersAsync(parameters);
    }

    private static readonly char[] PluralSuffix = { 's', 'S' };

    private void MakeHrefAbsolutes()
    {
        if (string.IsNullOrEmpty(HRef))
        {
            return;
        }

        _hrefAbsolutes ??= new List<string?>();
        _hrefAbsolutes.Clear();

        var uri = NavigationManager.ToAbsoluteUri(HRef);
        _hrefAbsolutes.Add(uri.AbsoluteUri);

        var lastCharOfLastSegment = uri.Segments[^1][^1];
        if (PluralSuffix.Contains(lastCharOfLastSegment))
        {
            MakeSingularAbsoluteHref(uri);
        }
    }

    private void MakeSingularAbsoluteHref(Uri uri)
    {
        var segments = uri.Segments;
        var lastSegments = segments[^1];
        var uriBuilder = new UriBuilder(uri);
        segments[^1] = lastSegments.TrimEnd('s');

        var pathBuilder = new StringBuilder(segments[0]);
        for (var i = 1; i < segments.Length; i++)
        {
            pathBuilder.Append(segments[i]);
        }

        uriBuilder.Path = pathBuilder.ToString();
        _hrefAbsolutes!.Add(uriBuilder.Uri.AbsoluteUri);
    }

    /// <summary>
    /// Gets or sets a value representing the URL matching behavior.
    /// </summary>
    [Parameter]
    public NavLinkMatch Match { get; set; }

    private bool ShouldMatch(string currentUriAbsolute)
    {
        if (_hrefAbsolutes == null)
        {
            return false;
        }

        foreach (var hrefAbsolute in _hrefAbsolutes)
        {
            if (hrefAbsolute == null)
            {
                continue;
            }

            if (EqualsHrefExactlyOrIfTrailingSlashAdded(hrefAbsolute, currentUriAbsolute))
            {
                return true;
            }

            if (Match == NavLinkMatch.Prefix
                && IsStrictlyPrefixWithSeparator(currentUriAbsolute, hrefAbsolute))
            {
                return true;
            }
        }

        return false;
    }

    private bool EqualsHrefExactlyOrIfTrailingSlashAdded(string hrefAbsolute, string currentUriAbsolute)
    {
        Debug.Assert(hrefAbsolute != null);

        if (string.Equals(currentUriAbsolute, hrefAbsolute, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        if (currentUriAbsolute.Length == hrefAbsolute.Length - 1)
        {
            // Special case: highlight links to http://host/path/ even if you're
            // at http://host/path (with no trailing slash)
            //
            // This is because the router accepts an absolute URI value of "same
            // as base URI but without trailing slash" as equivalent to "base URI",
            // which in turn is because it's common for servers to return the same page
            // for http://host/vdir as they do for host://host/vdir/ as it's no
            // good to display a blank page in that case.
            if (hrefAbsolute[hrefAbsolute.Length - 1] == '/'
                && hrefAbsolute.StartsWith(currentUriAbsolute, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsStrictlyPrefixWithSeparator(string value, string prefix)
    {
        var prefixLength = prefix.Length;
        if (value.Length > prefixLength)
        {
            return value.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
                   && (
                       // Only match when there's a separator character either at the end of the
                       // prefix or right after it.
                       // Example: "/abc" is treated as a prefix of "/abc/def" but not "/abcdef"
                       // Example: "/abc/" is treated as a prefix of "/abc/def" but not "/abcdef"
                       prefixLength == 0
                       || !char.IsLetterOrDigit(prefix[prefixLength - 1])
                       || !char.IsLetterOrDigit(value[prefixLength])
                   );
        }
        else
        {
            return false;
        }
    }
}
