using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dialogue : MonoBehaviour
{
    public Text text;
    public string[] lines;
    public float speed;
    int index;
    public Transform determinator;
    public bool levelEndsHere;

    void Start()
    {
        index = 0;
        StartCoroutine (Type());
    }

    void Update()
    {
        // ॥ कोड करने के दौरान ग्लिच आ रही थी इसलिए ये किया ॥
        if (text.text == string.Empty) NextLine();
        if (Input.GetButtonDown("Fire1"))
        {
            if (text.text == lines[index]) NextLine();
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine (Type());
        }
        else 
        {
            Vector3 moveDeterminator = determinator.position;
            moveDeterminator.x++;
            determinator.position = moveDeterminator;
            gameObject.SetActive (false);
            if (levelEndsHere == true)
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator Type()
    {
        // ॥ एकएक अक्षर टाइप करेगा ॥
        foreach (char i in lines[index].ToCharArray())
        {
            text.text += i;
            yield return new WaitForSeconds (speed);
        }
    }
}