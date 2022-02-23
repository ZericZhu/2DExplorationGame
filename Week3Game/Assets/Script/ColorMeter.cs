using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMeter : MonoBehaviour
{
    public Vector3 OriginalPosition;
    public float meter, percentage;
    public GameObject Player;

    private void Start()
    {
        OriginalPosition = this.GetComponent<RectTransform>().anchoredPosition;
    }
    private void Update()
    {
        percentage = (1 - Player.GetComponent<SpriteRenderer>().color.b)/0.75f;
        meter = Mathf.Lerp(0, 275.5f, percentage);
        this.GetComponent<RectTransform>().anchoredPosition = OriginalPosition + new Vector3(meter,0);
    }
}
