using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using static System.IO.Path;
using static UnityEngine.Application;

namespace Slax.Utils.Editor
{
    public static class PackageLoader
    {
        public static async Task ReplacePackagesFromGist(string id, string user = "felixbole")
        {
            var url = GetGistUrl(id, user);
            var contents = await GetContents(url);
            ReplacePackageFile(contents);
        }

        public static void InstallUnityPackage(string packageName)
        {
            UnityEditor.PackageManager.Client.Add($"com.unity.{packageName}");
        }

        static async Task<string> GetContents(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        static void ReplacePackageFile(string contents)
        {
            var existing = Combine(dataPath, "../Packages/manifest.json");
            File.WriteAllText(existing, contents);
            UnityEditor.PackageManager.Client.Resolve();
        }

        static string GetGistUrl(string id, string user = "felixbole") => $"https://gist.githubusercontent.com/{user}/{id}/raw";

    }
}