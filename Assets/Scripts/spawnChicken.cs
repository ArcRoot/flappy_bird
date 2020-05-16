using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnChicken : MonoBehaviour
{
    public float spawnPoint;
    public float pspawnPoint;
    public float pspawnRange;
    public float accel;
    public float g;
    private static float fspd;
    float limit_time;
    public float spawnTime;
    public float pipespd;
    public GameObject chicken;
    public List<GameObject> p;
    public float wspd;
    public float reset_wspd;
    public float jump_wspd;
    bool game_over=false;
    GameObject wall1;
    GameObject wall2;
    
    
    // Start is called before the first frame update
    void fly()
    {
        GameObject wing1 = chicken.transform.Find("날개").gameObject;
        GameObject wing2 = chicken.transform.Find("날개 (1)").gameObject;
        if (wing1.transform.rotation.x < -0.40)
        {
            wspd = reset_wspd;
        }
        if (wing1.transform.rotation.x > 0.15)
        {
            wspd = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wspd = jump_wspd;
        }
        wing1.transform.Rotate(wspd * Time.deltaTime, 0, 0);
        wing2.transform.Rotate(-wspd * Time.deltaTime, 0, 0);
    }
    void jumping()
    {
        fspd = fspd - g * Time.deltaTime;
        chicken.transform.Translate(0, fspd * Time.deltaTime, 0, Space.World);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fspd = fspd + accel;
        }
    }
    void pipemove()
    {
        for(int i=0;i<p.Count;i++)
        {
            p[i].transform.Translate(pipespd * Time.deltaTime, 0, 0);
        }
    }
    void pipesqawn()
    {
        limit_time -= Time.deltaTime;
        if (limit_time <= 0)
        {
            p.Add(Instantiate<GameObject>(Resources.Load<GameObject>("pipe"), new Vector3(pspawnPoint, Random.Range(-pspawnRange, pspawnRange), 0), Quaternion.identity));
            limit_time = Random.Range(1.5f, spawnTime);
        }
    }
    void destroyPipe()
    {
        for (int i = 0; i < p.Count; i++)
        {
            if (p[i].transform.position.x < -30)
            {
                Destroy(p[i]);
                p.RemoveAt(i);
            }
        }
    }
    public void destroyevr()
    {
        Destroy(chicken);
        while(p.Count!=0)
        {
            Destroy(p[0]);
            p.RemoveAt(0);
        }

        game_over = true;
    }

    void Start()
    {
        chicken = Instantiate<GameObject>(Resources.Load<GameObject>("닭"), new Vector3(spawnPoint, 0, 0), Quaternion.identity);
        wall1 = Instantiate<GameObject>(Resources.Load<GameObject>("wall"), new Vector3(0, 20, 0), Quaternion.identity);
        wall2 = Instantiate<GameObject>(Resources.Load<GameObject>("wall"), new Vector3(0, -20, 0), Quaternion.identity);
        limit_time = 0;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(game_over == false)
        {
            fly();
            jumping();
            pipesqawn();
            pipemove();
            destroyPipe();
        }
    }
}
