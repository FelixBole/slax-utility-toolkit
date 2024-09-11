using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace Slax.Utils.Editor
{
    public class AssetGuidExplorerEditorWindow : EditorWindow
    {
        Object _selectedAsset;
        string _assetGuid;
        string _localId;

        [MenuItem("Tools/GUID Explorer")]
        public static void ShowWindow()
        {
            GetWindow(typeof(AssetGuidExplorerEditorWindow), false, "GUID Explorer");
        }

        void OnGUI()
        {
            GUILayout.Label("Select an asset to view its GUID", EditorStyles.boldLabel);

            // Field to select an asset from the project
            _selectedAsset = EditorGUILayout.ObjectField("Asset", _selectedAsset, typeof(Object), false);

            // When an asset is selected, fetch its GUID
            if (_selectedAsset != null)
            {
                string assetPath = AssetDatabase.GetAssetPath(_selectedAsset);
                _assetGuid = AssetDatabase.AssetPathToGUID(assetPath);

                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Asset GUID:", _assetGuid);

                // Add field for local identifier in file
                PropertyInfo inspectorModeInfo = typeof(SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);

                SerializedObject serializedObject = new SerializedObject(_selectedAsset);
                inspectorModeInfo.SetValue(serializedObject, InspectorMode.Debug, null);

                SerializedProperty localIdProp =
                    serializedObject.FindProperty("m_LocalIdentfierInFile");
                _localId = localIdProp.intValue.ToString();

                EditorGUILayout.LabelField("Local Identifier:", _localId);
            }

            // Add copy button
            if (!string.IsNullOrEmpty(_assetGuid))
            {
                if (GUILayout.Button("Copy GUID"))
                {
                    EditorGUIUtility.systemCopyBuffer = _assetGuid;
                }

                if (GUILayout.Button("Copy Local Identifier"))
                {
                    EditorGUIUtility.systemCopyBuffer = _localId;
                }
            }
        }
    }
}