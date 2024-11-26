using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameLight))] // Replace with the target script class
public class SetLightsInactive : Editor
{
    private bool toggleInactive = false;

    public override void OnInspectorGUI()
    {
        // Draw default inspector elements
        DrawDefaultInspector();

        // Add a checkbox to toggle GameObject active states
        toggleInactive = EditorGUILayout.Toggle("Deactivate GameObjects", toggleInactive);

        // When checkbox is checked, set multiple GameObjects inactive
        if (toggleInactive)
        {
            // Get the target script (in this case, assume it's a GameManager with a list of GameObjects)
            GameLight gameLight = (GameLight)target;

            // Loop through each GameObject and set it inactive
            foreach (GameObject go in gameLight.gameObjectsToDeactivate)
            {
                go.SetActive(false);
            }
        }
        else
        {
            // If unchecked, make GameObjects active again
            GameLight gameLight = (GameLight)target;
            foreach (GameObject go in gameLight.gameObjectsToDeactivate)
            {
                go.SetActive(true);
            }
        }

        // Mark the editor as dirty to apply changes
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}