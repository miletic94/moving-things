using UnityEditor;

namespace CoreDomain.Scripts.Editor.EditorPrefsTab
{
    public static class EditorPrefsTab
    {
        [MenuItem("Eidt/Clear All EditorPrefs")]
        public static void DeleteAllEditorPrefs()
        {
            if (EditorUtility.DisplayDialog(
                "Clear all EditorPrefs?",
                "This will delete ALL EditorPrefs on this machine",
                "Yes, delete all from this machine",
                "No"
            ))
            {
                EditorPrefs.DeleteAll();
            }
        }
    }
}