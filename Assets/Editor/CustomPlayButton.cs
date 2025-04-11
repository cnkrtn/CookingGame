using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    [InitializeOnLoad]
    public static class CustomPlayButton
    {
        private const string TargetScenePath = "Assets/Scenes/MainScene.unity"; // 🎯 Your startup scene
        private const string PreviousSceneKey = "ScenePlaySwitcher.PreviousScene";

        static CustomPlayButton()
        {
            EditorApplication.playModeStateChanged += OnPlayModeChanged;
        }

        [MenuItem("PlayTools/Start From GameStartScene %#g")] // Ctrl + Shift + G
        public static void StartFromTargetScene()
        {
            if (EditorApplication.isPlaying)
            {
                Debug.LogWarning("Already in Play Mode.");
                return;
            }

            // Save current scene path
            var currentScene = SceneManager.GetActiveScene().path;
            EditorPrefs.SetString(PreviousSceneKey, currentScene);

            // Save current scene changes
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                // Open target scene
                EditorSceneManager.OpenScene(TargetScenePath);
                EditorApplication.isPlaying = true;
            }
        }

        private static void OnPlayModeChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredEditMode)
            {
                // We're returning from play mode
                string previousScene = EditorPrefs.GetString(PreviousSceneKey, "");
                if (!string.IsNullOrEmpty(previousScene))
                {
                    EditorPrefs.DeleteKey(PreviousSceneKey);
                    EditorSceneManager.OpenScene(previousScene);
                }
            }
        }
    }
}