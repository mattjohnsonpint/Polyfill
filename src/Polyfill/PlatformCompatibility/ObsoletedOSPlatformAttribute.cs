﻿#if !NET7_0_OR_GREATER

#pragma warning disable

// ReSharper disable RedundantUsingDirective
// ReSharper disable PartialTypeWithSinglePart

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

#nullable enable

namespace System.Runtime.Versioning;

using Targets = AttributeTargets;

/// <summary>
/// Marks APIs that were obsoleted in a given operating system version.
/// </summary>
/// <remarks>
/// Primarily used by OS bindings to indicate APIs that should not be used anymore.
/// </remarks>
[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
[AttributeUsage(
    validOn: Targets.Assembly |
             Targets.Class |
             Targets.Constructor |
             Targets.Enum |
             Targets.Event |
             Targets.Field |
             Targets.Interface |
             Targets.Method |
             Targets.Module |
             Targets.Property |
             Targets.Struct,
    AllowMultiple = true,
    Inherited = false)]
#if PolyPublic
public
#endif
sealed class ObsoletedOSPlatformAttribute :
    OSPlatformAttribute
{
    public ObsoletedOSPlatformAttribute(string platformName) :
        base(platformName)
    {
    }

    public ObsoletedOSPlatformAttribute(string platformName, string? message) :
        base(platformName) =>
        Message = message;

    public string? Message { get; }
    public string? Url { get; set; }
}

#endif