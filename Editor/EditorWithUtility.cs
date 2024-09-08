using UnityEditor;

namespace Slax.Utils.Editor
{
    public class EditorWithUtility : UnityEditor.Editor
    {
        #region IMGUI Utility

        /// <summary>
        /// Only accessible within an OnGUI call.
        /// </summary>
        public static float GetEditorWidth()
        {
            return EditorGUIUtility.currentViewWidth;
        }

        #endregion
    }
}