using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildAndroid : BaseBuild
{
    private const string kPlatform = "/Android";        
    private const string kBuildName = "/FPS_Demo.apk";
    private static void SetupKeystoreOfAndroid()
    {
        PlayerSettings.Android.keystoreName = "KeyStore/user.keystore";
        PlayerSettings.Android.keystorePass = "12345678";
        PlayerSettings.Android.keyaliasName = "fpsdemo";
        PlayerSettings.Android.keyaliasPass = "12345678";
    }

    [MenuItem("Tool/Build/Android/Debug")]
    public static void AndroidBuildDebug()
    {
        var config = CreateBuildConfig(kPlatform, kDevBuild, kBuildName);
        Build(config);
    }

    [MenuItem("Tool/Build/Android/Release")]
    public static void AndroidBuildRelease()
    {
        SetupKeystoreOfAndroid();
        var config = CreateBuildConfig(kPlatform, kReleaseBuild, kBuildName);
        Build(config);
    }
}