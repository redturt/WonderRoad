using UnityEngine;
using System.Collections;

public class DBConnect : MonoBehaviour {
    private UserController DB;

    void Awake ()
    {
        Debug.Log("Connecting");
        DB = GetComponent<UserController>();
        DB.GetData(delegate { Debug.Log("Got Data: " + DB.users.Count); });
    }
}
