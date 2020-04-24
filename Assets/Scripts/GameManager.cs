using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int point;
    public Text pointshow;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Addpoint()
    {
        point++;
        pointshow.text = point.ToString();
    }
}
