﻿// ReSharper disable RedundantUsingDirective
#nullable enable

using System;
using System.Collections.Concurrent;
using System.Reflection;

/// <summary>
/// Static and thread safe wrapper around NullabilityInfoContext.
/// </summary>
#if PolyPublic
public
#endif
static partial class PolyfillExtensions
{
    static ConcurrentDictionary<ParameterInfo, NullabilityInfo> parameterCache = new();
    static ConcurrentDictionary<PropertyInfo, NullabilityInfo> propertyCache = new();
    static ConcurrentDictionary<EventInfo, NullabilityInfo> eventCache = new();
    static ConcurrentDictionary<FieldInfo, NullabilityInfo> fieldCache = new();

    public static NullabilityInfo GetNullabilityInfo(this MemberInfo info)
    {
        if (info is PropertyInfo propertyInfo)
        {
            return propertyInfo.GetNullabilityInfo();
        }

        if (info is EventInfo eventInfo)
        {
            return eventInfo.GetNullabilityInfo();
        }

        if (info is FieldInfo fieldInfo)
        {
            return fieldInfo.GetNullabilityInfo();
        }

        throw new ArgumentException($"Unsupported type:{info.GetType().FullName}");
    }

    public static NullabilityState GetNullability(this MemberInfo info) =>
        GetReadOrWriteState(info.GetNullabilityInfo());

    public static bool IsNullable(this MemberInfo info)
    {
        var nullability = info.GetNullabilityInfo();
        return IsNullable(info.Name, nullability);
    }

    public static NullabilityInfo GetNullabilityInfo(this FieldInfo info) =>
        fieldCache.GetOrAdd(info, inner =>
        {
            var context = new NullabilityInfoContext();
            return context.Create(inner);
        });

    public static NullabilityState GetNullability(this FieldInfo info) =>
        GetReadOrWriteState(info.GetNullabilityInfo());

    public static bool IsNullable(this FieldInfo info)
    {
        var nullability = info.GetNullabilityInfo();
        return IsNullable(info.Name, nullability);
    }

    public static NullabilityInfo GetNullabilityInfo(this EventInfo info) =>
        eventCache.GetOrAdd(info, inner =>
        {
            var context = new NullabilityInfoContext();
            return context.Create(inner);
        });

    public static NullabilityState GetNullability(this EventInfo info) =>
        GetReadOrWriteState(info.GetNullabilityInfo());

    public static bool IsNullable(this EventInfo info)
    {
        var nullability = info.GetNullabilityInfo();
        return IsNullable(info.Name, nullability);
    }

    public static NullabilityInfo GetNullabilityInfo(this PropertyInfo info) =>
        propertyCache.GetOrAdd(info, inner =>
        {
            var context = new NullabilityInfoContext();
            return context.Create(inner);
        });

    public static NullabilityState GetNullability(this PropertyInfo info) =>
        GetReadOrWriteState(info.GetNullabilityInfo());

    public static bool IsNullable(this PropertyInfo info)
    {
        var nullability = info.GetNullabilityInfo();
        return IsNullable(info.Name, nullability);
    }

    public static NullabilityInfo GetNullabilityInfo(this ParameterInfo info) =>
        parameterCache.GetOrAdd(info, inner =>
        {
            var context = new NullabilityInfoContext();
            return context.Create(inner);
        });

    public static NullabilityState GetNullability(this ParameterInfo info) =>
        GetReadOrWriteState(info.GetNullabilityInfo());

    public static bool IsNullable(this ParameterInfo info)
    {
        var nullability = info.GetNullabilityInfo();
        return IsNullable(info.Name!, nullability);
    }

    static NullabilityState GetReadOrWriteState(NullabilityInfo nullability)
    {
        if (nullability.ReadState == NullabilityState.Unknown)
        {
            return nullability.WriteState;
        }

        return nullability.ReadState;
    }

    static NullabilityState GetKnownState(string name, NullabilityInfo nullability)
    {
        var readState = nullability.ReadState;
        if (readState != NullabilityState.Unknown)
        {
            return readState;
        }

        var writeState = nullability.WriteState;
        if (writeState != NullabilityState.Unknown)
        {
            return writeState;
        }

        throw new($"The nullability of '{nullability.Type.FullName}.{name}' is unknown. Assembly: {nullability.Type.Assembly.FullName}.");
    }

    static bool IsNullable(string name, NullabilityInfo nullability) =>
        GetKnownState(name, nullability) == NullabilityState.Nullable;
}