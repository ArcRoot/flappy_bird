using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorecheck : MonoBehaviour
{
    GameObject gameover_text;
    private Text score_text;
    private int score;
    void scoretext()
    {
        score_text.text = "[Score]:" + score;
    }

    // Start is called before the first frame update
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("crash");
            score++;
        }
    }
    private void Start()
    {
        score_text = GameObject.Find("score").GetComponent<Text>();
    }
    private void Update()
    {
        scoretext();
    }
}