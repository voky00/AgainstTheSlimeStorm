using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingText : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (GetComponent<CanvasGroup>().alpha > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            GetComponent<CanvasGroup>().alpha -= 0.01f;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
