using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour
{
    GameObject gameover_text;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("crash");
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<spawnChicken>().destroyevr();
            gameover_text = Instantiate<GameObject>(Resources.Load<GameObject>("gameover"), new Vector3(0, 0, -2), Quaternion.identity);
        }
    }
    private void Start()
    {
    }
}
