using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offsetThirdView = new Vector3(0, 10, -13);
    public string inputID;
    //private Vector3 offsetFirstView = new Vector3(0, 4, 2);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (inputID == "1")
        {
            transform.position = player.transform.position + offsetThirdView;
        }
        else if (inputID == "2")
        {
            transform.position = player.transform.position + new Vector3(0, 10, 13);
        }

    }
}
