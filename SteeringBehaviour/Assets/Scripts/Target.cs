using UnityEngine;

public class Target : MonoBehaviour
{
    /*
    Random Movement

    float tx = 0;
    float ty = 0;

    void Update()
    {
        tx += 0.01f;
        ty += 0.01f;

        float x = -5 + 10 * Mathf.PerlinNoise(tx, 0);
        float y = -5 + 10 * Mathf.PerlinNoise(0, ty);

        transform.position = new Vector3(x, y, 0);
    }
    */

    //Mouse
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.Scale(new Vector3(1,1,0));
        transform.position = mousePosition;
    }
}
