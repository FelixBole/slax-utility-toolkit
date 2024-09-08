using UnityEditor;
using UnityEngine.UIElements;

namespace Slax.Utils.Editor
{
    /// <summary>
    /// Utility class for creating custom editor elements and functionality.
    /// </summary>
    public static class CustomEditorUtility
    {
        /// **********************************************************************************************
        /// *                                      LAYOUTING                                             *
        /// **********************************************************************************************

        #region Layouting

        /// <summary>
        /// Set the class name of a VisualElement based on the current width of the window.
        /// </summary>
        public static VisualElement SetResponsiveClassName(VisualElement element, float currentWidth, float limit, string wideClassName, string narrowClassName)
        {
            if (currentWidth >= limit)
            {
                element.AddToClassList(wideClassName);
                element.RemoveFromClassList(narrowClassName);
            }
            else
            {
                element.AddToClassList(narrowClassName);
                element.RemoveFromClassList(wideClassName);
            }

            return element;
        }

        #endregion

        /// **********************************************************************************************
        /// *                                      STYLING                                               *
        /// **********************************************************************************************
        
        #region Styling

        /// <summary>
        /// Set the display style of a VisualElement to none if the condition is false, otherwise set it to flex.
        /// </summary>
        public static VisualElement ToggleDisplay(VisualElement element, bool display)
        {
            if (display)
            {
                element.style.display = DisplayStyle.Flex;
            }
            else
            {
                element.style.display = DisplayStyle.None;
            }

            return element;
        }

        /// <summary>
        /// Set the display style of multiple VisualElements to none if the condition is false, otherwise set it to flex.
        /// </summary>
        public static VisualElement[] ToggleDisplay(VisualElement[] elements, bool display)
        {
            foreach (VisualElement element in elements)
            {
                ToggleDisplay(element, display);
            }

            return elements;
        }

        #endregion

        /// **********************************************************************************************
        /// *                                      BUTTONS                                               *
        /// **********************************************************************************************
        
        #region Buttons

        /// <summary>
        /// Create a VisualElement button that will show a dialog when clicked and execute the action if the user confirms.
        /// <para>For UI Toolkit, not IMGUI</para>
        /// </summary>
        public static VisualElement MakeButtonWithDialog(string buttonText, string dialogTitle, string dialogMessage, string dialogConfirmButton, string dialogCancelButton, System.Action onConfirm)
        {
            Button button = new Button();
            button.text = buttonText;
            button.clicked += () =>
            {
                if (EditorUtility.DisplayDialog(dialogTitle, dialogMessage, dialogConfirmButton, dialogCancelButton))
                {
                    onConfirm();
                }
            };

            return button;
        }

        #endregion
    }
}