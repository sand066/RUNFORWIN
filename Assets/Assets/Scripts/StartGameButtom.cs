using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    public string SampleScene; // Name of the scene to load

    void Start()
    {
        // Get the Button component attached to this GameObject
        Button btn = GetComponent<Button>();
        // Add a listener to the button to call the LoadGameScene method when clicked
        btn.onClick.AddListener(LoadGameScene);
    }

    void LoadGameScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(SampleScene);
    }
}
