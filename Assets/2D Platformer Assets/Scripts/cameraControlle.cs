using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControlle : MonoBehaviour
{
    // config params
    public Transform player;
    public Transform farBackGround;
    public Transform midBackGround;

    
    private Vector2 lastPosXY;

    // this parm is for limiting the camera
    public float minCameraY;
    public float maxCameraY;

    // Start is called before the first frame update
    void Start()
    {
        lastPosXY = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // here is the camera follow the player
        // we used Mathf.Clamp to limit the camera
        transform.position = new Vector3(player.position.x ,Mathf.Clamp(player.position.y, minCameraY, maxCameraY), transform.position.z);

        // here is the background follow the camera
        Vector2 amountToMove = new Vector2(transform.position.x - lastPosXY.x, transform.position.y - lastPosXY.y);
        farBackGround.position += new Vector3( amountToMove.x, amountToMove.y, 0f);
        midBackGround.position = new Vector3(amountToMove.x , amountToMove.y, 0f) * 0.5f;

        lastPosXY = transform.position;

    }
}
