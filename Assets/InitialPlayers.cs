using UnityEngine;
using System.Collections.Generic;

public class InitialPlayers : MonoBehaviour {
    public static List<User> users;
    public static Color[] allcolors;
    public static GameObject staticplayer;
    public static Transform parent;

    public GameObject player;
    public Color[] playercolors;
    private static int currentplayer = 0;

    public static Color GetNextColor()
    {
        currentplayer++;
        return allcolors[currentplayer % allcolors.Length];
    }

    public Color[] colors;
    public GameObject[] characters;
    public string[] questions;
    public Vector3[] locations;

    void Awake()
    {
        if (characters.Length != questions.Length || questions.Length != locations.Length || questions.Length != colors.Length)
        {
            Debug.LogError("Wrong set up!");
        }

        if (users == null)
        {
            users = new List<User>();
            allcolors = playercolors;
            staticplayer = player;
            parent = this.transform;
        }
    }

	// Use this for initialization
	void Start () {
	    for(int i = 0; i < questions.Length; i++)
        {
            GameObject charect = Instantiate(characters[i]);
            charect.GetComponentInChildren<TrollBridge.Area_Dialogue>().dialogue = new string[] {questions[i]};
            charect.GetComponentInChildren<SpriteRenderer>().color = colors[i];
            charect.transform.parent = transform.parent;
            charect.transform.position = locations[i];
            users.Add(new User(charect));
        }
	}

    private static string lastquestion;
    private static Color lastcolor;
    public static void AddPlayer(string question)
    {
        lastquestion = question;
        lastcolor = allcolors[currentplayer % allcolors.Length];
        GameObject charect = Instantiate(staticplayer);
        charect.GetComponentInChildren<TrollBridge.Area_Dialogue>().dialogue = new string[] { question };
        charect.GetComponentInChildren<SpriteRenderer>().color = allcolors[currentplayer % allcolors.Length];
        charect.transform.parent = parent;
        charect.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        users.Add(new User(charect));
    }

    public static void SetQuestion(UnityEngine.UI.Text question)
    {
        question.text = lastquestion;
        question.color = lastcolor;
    }
}
