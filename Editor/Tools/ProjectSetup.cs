using System.IO;
using UnityEngine;
using UnityEditor;

using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace Slax.Utils.Editor
{
    public static class ProjectSetup
    {
        public static void CreateFolderStructure()
        {
            CreateDirectories("_Project", "Animations", "Audio", "Localization", "Materials", "Models", "Prefabs", "Scenes", "ScriptableObjects", "Scripts", "Settings", "Sprites", "Textures", "VFX");

            CreateSubDirectories("_Project", "Scripts", "Editor", "Runtime");
            CreateSubDirectories("_Project", "Localization", "Locales");
            CreateSubDirectories("_Project", "ScriptableObjects", "Data", "Settings", "Gameplay", "EventChannels");
            CreateSubDirectories("_Project", "Settings", "Input");
            CreateSubDirectories("_Project", "Sprites", "UI", "Gameplay", "Characters", "Items", "Environment", "Effects");
            CreateSubDirectories("_Project", "VFX", "Particles", "Shaders");

            Refresh();
        }

        public static void CreateDirectories(string root, params string[] directories)
        {
            string fullPath = Combine(dataPath, root);

            foreach (var directory in directories)
            {
                CreateDirectory(Combine(fullPath, directory));
            }
        }

        public static void CreateSubDirectories(string root, string sub, params string[] directories)
        {
            string fullPath = Combine(dataPath, root, sub);

            foreach (var directory in directories)
            {
                CreateDirectory(Combine(fullPath, directory));
            }
        }
    }
}