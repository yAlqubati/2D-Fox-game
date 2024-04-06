using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealController.instance.Heal();
            this.gameObject.SetActive(false);
            AudioManager.instance.effectToPlay(7);
        }
    }
}
