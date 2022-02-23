using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Changable : MonoBehaviour
{
    public Vector3 ChangeFactor;
    public bool IsBig, IsSmall;
    private void Start()
    {
        this.GetComponent<Collider2D>().isTrigger = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;

        if (IsBig)
        {
            StartCoroutine(EnlargeAnimation());
        }

        if (IsSmall)
        {
            StartCoroutine(EnsmallAnimation());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (collision.gameObject.GetComponent<PlayerController>().Ismoving == false)
            {
                collision.gameObject.transform.localScale += ChangeFactor;
                this.gameObject.SetActive(false);
                PlayerController.StateArray.Add(this.gameObject);
            }
        }
    }

    public IEnumerator EnlargeAnimation()
    {
        float time = 0, duration = 1.5f;
        float scaleModifier = 1, endValue = 3;
        float startValue = 1;
        Vector3 startScale = new Vector3(0.3f, 0.3f, 0.3f);
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = startScale * endValue;
        StartCoroutine(EnlargeAnimation());
    }

    public IEnumerator EnsmallAnimation()
    {
        float time = 0, duration = 1.5f;
        float scaleModifier = 3, endValue = 1;
        float startValue = scaleModifier;
        Vector3 startScale = new Vector3(0.3f, 0.3f, 0.3f);
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = startScale * endValue;
        StartCoroutine(EnsmallAnimation());
    }

}
