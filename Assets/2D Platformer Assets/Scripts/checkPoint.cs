using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite checkPointOn, checkPointOff;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SpriteRenderer.sprite = checkPointOn;
            PlayerHealController.instance.LastCheckPointPos = transform.position;
        }
    }
}
