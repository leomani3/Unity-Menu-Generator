using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ButtonManager))]
public class ButtonEditor : Editor
{
    private string sceneName;
    private string newSceneName;
    private Object obj;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        ButtonManager buttonManager = (ButtonManager)target;

        buttonManager.SetActionIndex(GUILayout.Toolbar(buttonManager.GetActionIndex(), new string[] { "Load Scene", "Quit" }));

        if (buttonManager.GetActionIndex() == 0)
        {
            buttonManager.SetAction(ButtonManager.ACTIONS.LoadScene);

            GUILayout.BeginHorizontal();
            if (!Application.isPlaying)
            {
                GUILayout.Label("Scene Name : ", GUILayout.Width(100));
                newSceneName = GUILayout.TextField(sceneName);
                if (sceneName != newSceneName)
                {
                    sceneName = newSceneName;
                    buttonManager.SetSceneName(sceneName);
                }
            }
            Debug.Log(sceneName);

            GUILayout.EndHorizontal();
        }
        else if (buttonManager.GetActionIndex() == 1)
        {
            buttonManager.SetAction(ButtonManager.ACTIONS.Quit);
        }

    }
}
