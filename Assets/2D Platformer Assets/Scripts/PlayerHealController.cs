using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealController : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public static PlayerHealController instance;
    public Vector3 LastCheckPointPos;
    public float damageTime = 1f;
    public float damageTimeCounter = 0f, damageFlashTime = 0.2f;

    public SpriteRenderer theSR;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        LastCheckPointPos = transform.position;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(damageTimeCounter > 0)
        {
            damageTimeCounter -= Time.deltaTime;
        }

        if(damageTimeCounter <= 0)
        {
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
        }
    }

    public void Heal()
    {
        if(currentHealth < maxHealth)
        {
            currentHealth++;
        }

        HeartBarAnim.instance.updateHeartBar();
    }

    public void TakeDamage()
    {
        //ControllerForPlayer.instance.KnockBack();
        // the animation for the player to take damage doesn't work

        if(damageTimeCounter <= 0)
        {
            currentHealth--;
            if(currentHealth <= 0)
            {
                currentHealth = 0;
                RespwanManager.instance.Respawn();
                AudioManager.instance.effectToPlay(8);
            }
            damageTimeCounter = damageTime;
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.5f);
            
        }

        else{
            damageTimeCounter = damageTime;
        }

        HeartBarAnim.instance.updateHeartBar();
    }

}
