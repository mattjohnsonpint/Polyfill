#if !NET7_0_OR_GREATER

#pragma warning disable

// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedMember.Global

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices;

/// <summary>
/// Disables the built-in runtime managed/unmanaged marshalling subsystem for
/// P/Invokes, Delegate types, and unmanaged function pointer invocations.
/// </summary>
/// <remarks>
/// The built-in marshalling subsystem has some behaviors that cannot be changed due to
/// backward-compatibility requirements. This attribute allows disabling the built-in
/// subsystem and instead uses the following rules for P/Invokes, Delegates,
/// and unmanaged function pointer invocations:
///
/// - All value types that do not contain reference type fields recursively (<c>unmanaged</c> in C#) are blittable
/// - Value types that recursively have any fields that have <c>[StructLayout(LayoutKind.Auto)]</c> are disallowed from interop.
/// - All reference types are disallowed from usage in interop scenarios.
/// - SetLastError support in P/Invokes is disabled.
/// - varargs support is disabled.
/// - LCIDConversionAttribute support is disabled.
/// </remarks>
[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
[AttributeUsage(AttributeTargets.Assembly)]
#if PolyPublic
public
#endif
sealed class DisableRuntimeMarshallingAttribute :
    Attribute
{
}

#endif