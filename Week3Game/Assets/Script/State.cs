using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    private bool isTouched = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isTouched == false)
        {
            if (collision.gameObject.GetComponent<PlayerController>().Ismoving == false)
            {
                collision.gameObject.GetComponent<PlayerController>().CheckPoint = this.transform.position;
                PlayerController.CheckColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
                PlayerController.CheckScale = collision.transform.localScale;
                this.GetComponent<SpriteRenderer>().color = Color.white;
            }
            isTouched = true;
        }
    }
}
