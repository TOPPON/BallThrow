using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text angle;
    public Text SpeedResult;
    private Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        angle.text = Input.gyro.attitude.eulerAngles.ToString();
        if (Input.touches[0].phase == TouchPhase.Began)
        {
        }
        if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary)
        {
            speed=Input.gyro.attitude * new Vector3(1, 0, 0);
            SpeedResult.text = (speed * 100.0f).ToString();
        }
        if (Input.touches[0].phase == TouchPhase.Ended)
        {
        }

    }
}
