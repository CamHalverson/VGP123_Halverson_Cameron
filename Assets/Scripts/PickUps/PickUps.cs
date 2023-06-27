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
        //if (!myController) return;

        if (collision.gameObject.CompareTag("Player"))
        {


            if (currentPickup == PickupType.speedBoost)
            {
                PlayerController myController = collision.gameObject.GetComponent<PlayerController>();
                myController.StartSpeedChange();
                Destroy(gameObject);
                return;
            }

            if (currentPickup == PickupType.Life)
            {
                //do something
                GameManager.Instance.Lives++;
                Destroy(gameObject);
                return;
            }



            


        }
    }



}
