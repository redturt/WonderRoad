using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserController : MonoBehaviour {
	private string secretKey = "FakePasswordToUseForOpenSourceVersion"; // Edit this value and make sure it's the same as the one stored on the server
    private string addUserURL = "http://lahamonim.com/games/wonderoad/adduser.php?"; //be sure to add a ? to your url
    private string addQuestionURL = "http://lahamonim.com/games/wonderoad/addquestion.php?"; 
    private string getUsersURL = "http://lahamonim.com/games/wonderoad/getusers.php";
    private string getQuestionsURL = "http://lahamonim.com/games/wonderoad/getquestions.php";
    public List<User> users = new List<User>();

    public void Connect(string email, string password, Action callback)
    {
        StartCoroutine(PostUser(email, password, callback));
    }

    public void GetData(Action callback)
    {
        StartCoroutine(GetUsers(callback));
    }

    // remember to use StartCoroutine when calling this function!
    IEnumerator PostUser(string email, string password, Action callback)
	{
		//This connects to a server side php script that will add the email and password to a MySQL DB.
		// Supply it with a string representing the players email and the players password.
		string hash = MD5Test.Md5Sum(email + password + secretKey);
		string post_url = addUserURL + "email=" + WWW.EscapeURL(email) + "&password=" + password + "&hash=" + hash;

		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done

		if (hs_post.error != null)
		{
			Debug.LogError("There was an error posting the high password: " + hs_post.error);
		}
        else
        {
            Debug.LogWarning(hs_post.text);
            callback();
        }
	}

    // Get the passwords from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetUsers(Action callback)
    {
        Debug.Log(getUsersURL);
        WWW hs_get = new WWW(getUsersURL);
        yield return hs_get;
        Debug.Log("returned");

        if (hs_get.error != null)
        {
            Debug.LogError("There was an error getting the high password: " + hs_get.error);
        }
        else
        {
            Debug.Log(hs_get.text);

            users.Clear();

            foreach(string userData in hs_get.text.Split('\n'))
            {
                //string[] extracted = userData.Split('\t');
                //User user = new User();
                //user.email = extracted[1];
                //int pos = Int32.Parse(extracted[2]);
                //user.posX = pos / 1000;
                //user.posY = pos % 1000;
                //users.Add(user);
            }

            // Get Questions
            hs_get = new WWW(getQuestionsURL);
            yield return hs_get;

            if (hs_get.error != null)
            {
                Debug.LogError("There was an error getting the high password: " + hs_get.error);
            }
            else
            {
                Debug.Log(hs_get.text);

                foreach (string userData in hs_get.text.Split('\n'))
                {
                    string[] extracted = userData.Split('\t');
                    int i = Int32.Parse(extracted[0]);
                }

            }

            callback();
        }
    }

  
}
