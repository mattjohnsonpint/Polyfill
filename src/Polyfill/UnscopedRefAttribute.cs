#if !NET7_0_OR_GREATER

#pragma warning disable

// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedMember.Global

using System.Diagnostics;

namespace System.Diagnostics.CodeAnalysis;

using Targets = AttributeTargets;

/// <summary>
/// Used to indicate a byref escapes and is not scoped.
/// </summary>
/// <remarks>
/// <para>
/// There are several cases where the C# compiler treats a <see langword="ref"/> as implicitly
/// <see langword="scoped"/> - where the compiler does not allow the <see langword="ref"/> to escape the method.
/// </para>
/// <para>
/// For example:
/// <list type="number">
///   <item><see langword="this"/> for <see langword="struct"/> instance methods.</item>
///   <item><see langword="ref"/> parameters that refer to <see langword="ref"/> <see langword="struct"/> types.</item>
///   <item><see langword="out"/> parameters.</item>
/// </list>
/// </para>
/// <para>
/// This attribute is used in those instances where the <see langword="ref"/> should be allowed to escape.
/// </para>
/// <para>
/// Applying this attribute, in any form, has impact on consumers of the applicable API. It is necessary for
/// API authors to understand the lifetime implications of applying this attribute and how it may impact their users.
/// </para>
/// </remarks>
[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
[AttributeUsage(
    validOn: Targets.Method |
             Targets.Property |
             Targets.Parameter,
    Inherited = false)]
#if PolyPublic
public
#endif
sealed class UnscopedRefAttribute :
    Attribute
{
}

#endif