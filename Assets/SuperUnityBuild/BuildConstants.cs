using System;

// This file is auto-generated. Do not modify or move this file.

namespace SuperUnityBuild.Generated
{
    public enum ReleaseType
    {
        None,
        DefaultRelease,
    }

    public enum Platform
    {
        None,
        WebGL,
        PC,
        macOS,
    }

    public enum ScriptingBackend
    {
        None,
        IL2CPP,
        Mono,
    }

    public enum Architecture
    {
        None,
        WebGL,
        Windows_x64,
        macOS,
    }

    public enum Distribution
    {
        None,
    }

    public static class BuildConstants
    {
        public static readonly DateTime buildDate = new DateTime(638626304922214360);
        public const string version = "2024-09-22-4699";
        public const ReleaseType releaseType = ReleaseType.DefaultRelease;
        public const Platform platform = Platform.macOS;
        public const ScriptingBackend scriptingBackend = ScriptingBackend.Mono;
        public const Architecture architecture = Architecture.macOS;
        public const Distribution distribution = Distribution.None;
    }
}

