using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace CoreDomain.Scripts.Editor.DefaultSceneSelector
{
    [InitializeOnLoad]
    public static class DefaultSceneSelector
    {
        private const string DEFAULT_SCENE_PATH_KEY = "DefaultScenePathKey";
        private const string HAS_OPENED_PROJECT_BEFORE_KEY = "HasOpenedProjectBeforeKey";
        private const string CORE_SCENE_FILE = "Assets/ElephantKarter/MovingThings/Core/Assets/Scenes/CoreScene.unity";
        private const string GAME_SCENE_FILE = "Assets/ElephantKarter/MovingThings/Core/Game/Assets/Scenes/GameScene.unity";

        static DefaultSceneSelector()
        {
            EditorApplication.delayCall += OnLoad;
        }
        private static void OnLoad()
        {
            OpenCoreSceneIfHaventBefore();
            SetSavedSceneAsStarting();
        }
        private static void OpenCoreSceneIfHaventBefore()
        {
            var didOpenProjectBefore = EditorPrefs.HasKey(HAS_OPENED_PROJECT_BEFORE_KEY);
            if (didOpenProjectBefore)
            {
                return;
            }
            EditorSceneManager.OpenScene(CORE_SCENE_FILE);
            EditorPrefs.SetBool(HAS_OPENED_PROJECT_BEFORE_KEY, true);
        }
        private static void SetSavedSceneAsStarting()
        {
            var path = EditorPrefs.GetString(DEFAULT_SCENE_PATH_KEY, CORE_SCENE_FILE);
            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(path);
            EditorSceneManager.playModeStartScene = sceneAsset;
        }

        [MenuItem("Tools/ElephantKarter/Select Default Scene", false, 1)]
        private static void SelectDefaultScene()
        {
            var absolutePath = EditorUtility.OpenFilePanel("Select default scene", GetSelectedFolder(), "*");
            if (absolutePath.IsNullOrEmpty())
            {
                return;
            }
            var path = GetProjectRelativePath(absolutePath);
            EditorPrefs.SetString(DEFAULT_SCENE_PATH_KEY, path);
            SetSavedSceneAsStarting();
        }

        [MenuItem("Tools/ElephantKarter/Scene/Reset Default Scene", false, 2)]
        private static void ResetDefaultScene()
        {
            EditorPrefs.DeleteKey(DEFAULT_SCENE_PATH_KEY);
            EditorSceneManager.playModeStartScene = null;
        }

        [MenuItem("Tools/ElephantKarter/Scene/Open/Core &2", false, 3)]
        private static void OpenRootScene()
        {
            EditorApplication.ExitPlaymode();
            EditorSceneManager.OpenScene(CORE_SCENE_FILE);
        }

        [MenuItem("Tools/ElephantKarter/Scene/Open/Game &3", false, 4)]
        private static void OpenGameScene()
        {
            EditorApplication.ExitPlaymode();
            EditorSceneManager.OpenScene(GAME_SCENE_FILE);
        }
        // TODO:: Adding Scenes :: When you add scene - put it here following the pattern above.
        private static string GetSelectedFolder()
        {
            var obj = Selection.activeObject;
            return obj == null ? "Assets" : AssetDatabase.GetAssetPath(obj.GetInstanceID()); ;
        }
        private static string GetProjectRelativePath(string absolutePath)
        {
            if (absolutePath.StartsWith(Application.dataPath))
            {
                return "Assets" + absolutePath.Substring(Application.dataPath.Length);
            }
            Debug.LogError("Selected file is not within the project's Assets folder.");
            return null;
        }
    }
}