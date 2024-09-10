using UnityEditor;

namespace Slax.Utils.Editor
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Setup/Folder Structure")]
        public static void SetupProjectFolderStructure() => ProjectSetup.CreateFolderStructure();

        [MenuItem("Tools/Setup/Packages/Load Preconfigured Manifest")]
        public static async void SetupPackages() => await PackageLoader.ReplacePackagesFromGist("");

        [MenuItem("Tools/Setup/Packages/Quick Installs/New Input System")]
        public static void InstallNewInputSystem() => PackageLoader.InstallUnityPackage("inputsystem");

        [MenuItem("Tools/Setup/Packages/Quick Installs/TextMesh Pro")]
        public static void InstallTextMeshPro() => PackageLoader.InstallUnityPackage("textmeshpro");

        [MenuItem("Tools/Setup/Packages/Quick Installs/Cinemachine")]
        public static void InstallCinemachine() => PackageLoader.InstallUnityPackage("cinemachine");

        [MenuItem("Tools/Setup/Packages/Quick Installs/Localization")]
        public static void InstallLocalization() => PackageLoader.InstallUnityPackage("localization");

        [MenuItem("Tools/Setup/Packages/Quick Installs/Post Processing")]
        public static void InstallPostProcessing() => PackageLoader.InstallUnityPackage("postprocessing");

        [MenuItem("Tools/Setup/Packages/Add 2D Packages")]
        public static void Add2DPackages() => PackageLoader.InstallUnityPackage("feature.2d");
    }
}