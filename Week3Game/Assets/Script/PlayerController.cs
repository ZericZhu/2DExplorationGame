using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _rollSpeed = 5;
    public bool Ismoving;
    public Vector3 CheckPoint;
    public static List<GameObject> StateArray = new List<GameObject>();
    public static Color CheckColor;
    public static Vector3 CheckScale;

    private void Start()
    {
        CheckColor = Color.white;
        CheckScale = new Vector3(1, 1, 1);
        Ismoving = false;
    }

    private void Update()
    {
        if (Ismoving == false)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(CubeRoll(Vector3.right));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(CubeRoll(Vector3.left));
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                this.transform.position = CheckPoint;
                this.transform.localScale = CheckScale;
                this.GetComponent<SpriteRenderer>().color = CheckColor;
                for (int i =0; i < StateArray.Count; i++)
                {
                    StateArray[i].SetActive(true);
                }
            }
        }
    }



    public IEnumerator CubeRoll(Vector3 Direction)
    {
        Ismoving = true;
            var anchor = transform.position + (Vector3.down + Direction) * this.transform.localScale.x/2;
            var axis = Vector3.Cross(Vector3.up, Direction);
            for (var i = 0; i < 90 / _rollSpeed; i++)
            {
                transform.RotateAround(anchor, axis, _rollSpeed);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(0.01f);
        Ismoving = false;
    }


}
