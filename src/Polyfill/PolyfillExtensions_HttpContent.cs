﻿#if ((NETFRAMEWORK && HTTPREFERENCED) || NETSTANDARD || NETCOREAPP2X || NETCOREAPP3X)

#pragma warning disable

// ReSharper disable RedundantUsingDirective
// ReSharper disable RedundantAttributeSuffix
// ReSharper disable UnusedMember.Global

using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

static partial class PolyfillExtensions
{
    /// <summary>
    /// Serializes the HTTP content and returns a stream that represents the content.
    /// </summary>
    /// <remarks>
    /// Note that this method will internally buffer the content unless <c>CreateContentReadStreamAsync()</c> has been
    /// implemented to do otherwise.
    /// </remarks>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.
    /// </param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    [DescriptionAttribute("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpcontent.readasstreamasync#system-net-http-httpcontent-readasstreamasync(system-threading-cancellationtoken)")]
    public static Task<Stream> ReadAsStreamAsync(
        this HttpContent httpContent,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return httpContent.ReadAsStreamAsync();
    }

    /// <summary>
    /// Serializes the HTTP content to a byte array as an asynchronous operation.
    /// </summary>
    /// <remarks>
    /// Note that this method will internally buffer the content unless <c>CreateContentReadStreamAsync()</c> has been
    /// implemented to do otherwise.
    /// </remarks>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.
    /// </param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    [DescriptionAttribute("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpcontent.readasbytearrayasync#system-net-http-httpcontent-readasbytearrayasync(system-threading-cancellationtoken)")]
    public static Task<byte[]> ReadAsByteArrayAsync(
        this HttpContent httpContent,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return httpContent.ReadAsByteArrayAsync();
    }

    /// <summary>
    /// Serializes the HTTP content to a string as an asynchronous operation.
    /// </summary>
    /// <remarks>
    /// Note that this method will internally buffer the content unless <c>CreateContentReadStreamAsync()</c> has been
    /// implemented to do otherwise.
    /// </remarks>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.
    /// </param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    [DescriptionAttribute("https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpcontent.readasstringasync#system-net-http-httpcontent-readasstringasync(system-threading-cancellationtoken)")]
    public static Task<string> ReadAsStringAsync(
        this HttpContent httpContent,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return httpContent.ReadAsStringAsync();
    }
}
#endif