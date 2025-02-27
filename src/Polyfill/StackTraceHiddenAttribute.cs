#if !NET6_0_OR_GREATER

#pragma warning disable

// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedMember.Global

using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics;

using Targets = AttributeTargets;

/// <summary>
/// Types and Methods attributed with StackTraceHidden will be omitted from the stack trace text shown in StackTrace.ToString()
/// and Exception.StackTrace
/// </summary>
[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
[AttributeUsage(
    validOn: Targets.Class |
             Targets.Method |
             Targets.Constructor |
             Targets.Struct,
    Inherited = false)]
#if PolyPublic
public
#endif
sealed class StackTraceHiddenAttribute :
    Attribute
{
}

#endif