#if !NET6_0_OR_GREATER

#pragma warning disable

// ReSharper disable RedundantUsingDirective
// ReSharper disable PartialTypeWithSinglePart

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.Versioning;

using Targets = AttributeTargets;

/// <summary>
/// Annotates the custom guard field, property or method with an unsupported platform name and optional version.
/// Multiple attributes can be applied to indicate guard for multiple unsupported platforms.
/// </summary>
/// <remarks>
/// Callers can apply a <see cref="System.Runtime.Versioning.UnsupportedOSPlatformGuardAttribute " /> to a field, property or method
/// and use that  field, property or method in a conditional or assert statements as a guard to safely call APIs unsupported on those platforms.
///
/// The type of the field or property should be boolean, the method return type should be boolean in order to be used as platform guard.
/// </remarks>
[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
[AttributeUsage(
    validOn: Targets.Field |
             Targets.Method |
             Targets.Property,
    AllowMultiple = true,
    Inherited = false)]
#if PolyPublic
public
#endif
sealed class UnsupportedOSPlatformGuardAttribute :
    OSPlatformAttribute
{
    public UnsupportedOSPlatformGuardAttribute(string platformName) :
        base(platformName)
    {
    }
}

#endif