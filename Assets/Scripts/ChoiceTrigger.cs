using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceTrigger : MonoBehaviour
{
    public string choice1;
    public string choice2;
    public string scene1;
    public string scene2;
    private bool displayChoices = false;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            displayChoices = true;
            collision.gameObject.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void OnGUI()
    {
        if (displayChoices)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 25, 150, 50), choice1))
            {
                SceneManager.LoadScene(scene1);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 + 25, 150, 50), choice2))
            {
                SceneManager.LoadScene(scene2);
            }
        }
    }
}