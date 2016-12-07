using UnityEngine;
using System.Collections.Generic;

public class InitialPlayers : MonoBehaviour {
    public static List<User> users;

    public GameObject dialog;
    public GameObject[] characters;
    public string[] questions;
    public Vector3[] locations;

    void Awake()
    {
        if (characters.Length != questions.Length || questions.Length != locations.Length)
        {
            Debug.LogError("Wrong set up!");
        }

        if (users == null)
        {
            users = new List<User>();
        }
    }

	// Use this for initialization
	void Start () {
	    for(int i = 0; i < questions.Length; i++)
        {
            GameObject charect = Instantiate(characters[i]);
            charect.GetComponentInChildren<TrollBridge.Area_Dialogue>().dialogue = new string[] {questions[i]};
            charect.transform.parent = transform.parent;
            charect.transform.position = locations[i];
            users.Add(new User(charect));
        }
	}
}
