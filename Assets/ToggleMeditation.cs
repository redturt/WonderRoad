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
                GameObject g = GameObject.FindGameObjectWithTag("Player");
                field.text = ""+ g.transform.position;
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

    }
}
