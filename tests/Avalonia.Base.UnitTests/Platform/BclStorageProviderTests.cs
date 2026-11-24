using System;
using System.IO;
using Avalonia.Platform.Storage;
using Xunit;

namespace Avalonia.Base.UnitTests;

public class BclStorageProviderTests
{
    [Fact]
    public void Downloads_Folder_Is_An_Absolute_Path_On_Unix()
    {
        Assert.SkipUnless(OperatingSystem.IsLinux() || OperatingSystem.IsMacOS(), "Linux and macOS only");

        var path = DownloadsProbe.GetDownloads();

        Assert.NotNull(path);
        Assert.True(Path.IsPathRooted(path), path);
    }

    private class DownloadsProbe : NoopStorageProvider
    {
        public static string? GetDownloads() => GetDownloadsWellKnownFolder();
    }
}
