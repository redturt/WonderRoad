using UnityEngine;
using UnityEngine.UI;

public class ToggleMeditation : MonoBehaviour {
    public GameObject input;
    private InputField field;

    void Awake()
    {
        field = input.GetComponent<InputField>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {

            input.SetActive(!input.activeSelf);
            if (input.activeSelf)
            {
                field.text = "";
                Time.timeScale = 0;
            }
            else if (field.text.Length > 0)
            {
                InitialPlayers.AddPlayer(field.text);
                Application.LoadLevel("MainMenuEnd");
            }
            else
            {
                Time.timeScale = 1;
            }
        }

    }
}
