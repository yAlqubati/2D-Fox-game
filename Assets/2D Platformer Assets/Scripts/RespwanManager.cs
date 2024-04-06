using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespwanManager : MonoBehaviour
{
    public static RespwanManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerHealController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        PlayerHealController.instance.transform.position = PlayerHealController.instance.LastCheckPointPos;
        PlayerHealController.instance.gameObject.SetActive(true);
        PlayerHealController.instance.currentHealth = PlayerHealController.instance.maxHealth;
        HeartBarAnim.instance.updateHeartBar();
    }
}
