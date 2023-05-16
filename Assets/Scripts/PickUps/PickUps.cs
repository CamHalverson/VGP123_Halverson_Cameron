using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public enum PickupType
    {
        Powerup,
        Life,
        speedBoost,
        Score
    }

    public PickupType currentPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController myController = collision.gameObject.GetComponent<PlayerController>();
        //if (!myController) return;

        if (collision.gameObject.CompareTag("Player"))
        {


            if (currentPickup == PickupType.speedBoost)
            {
                myController.StartSpeedChange();
                Destroy(gameObject);
                return;
            }

            if (currentPickup == PickupType.Life)
            {
                //do something
                myController.lives++;
                Destroy(gameObject);
                return;
            }



            //do something
            myController.score++;
            Destroy(gameObject);


        }
    }

}
