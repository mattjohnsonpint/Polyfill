#if !NET5_0_OR_GREATER

#pragma warning disable

// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedMember.Global

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices;

using Targets = AttributeTargets;

/// <summary>
/// Used to indicate to the compiler that the <c>.locals init</c>
/// flag should not be set in method headers.
/// </summary>
/// <remarks>
/// This attribute is unsafe because it may reveal uninitialized memory to
/// the application in certain instances (e.g., reading from uninitialized
/// stackalloc'd memory). If applied to a method directly, the attribute
/// applies to that method and all nested functions (lambdas, local
/// functions) below it. If applied to a type or module, it applies to all
/// methods nested inside. This attribute is intentionally not permitted on
/// assemblies. Use at the module level instead to apply to multiple type
/// declarations.
/// </remarks>
[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
[AttributeUsage(
    validOn: Targets.Module |
             Targets.Class |
             Targets.Struct |
             Targets.Interface |
             Targets.Constructor |
             Targets.Method |
             Targets.Property |
             Targets.Event,
    Inherited = false)]
#if PolyPublic
public
#endif
sealed class SkipLocalsInitAttribute :
    Attribute
{
}

#endif