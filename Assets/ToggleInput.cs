using UnityEngine;
using UnityEngine.UI;

public class ToggleInput : MonoBehaviour {
    public GameObject input;
    private InputField field;

    void Awake()
    {
        field = input.GetComponent<InputField>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {

            input.SetActive(!input.activeSelf);
            if (input.activeSelf)
            {
                field.text = "";
                Time.timeScale = 0;
            } else
            {
                Time.timeScale = 1;
            }
        }

    }
}
