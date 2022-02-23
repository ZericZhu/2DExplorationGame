using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>().Ismoving == false)
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color.b - this.gameObject.GetComponent<SpriteRenderer>().color.b <= 0.01)
            {
                this.gameObject.SetActive(false);
            }
        }
    }


}
