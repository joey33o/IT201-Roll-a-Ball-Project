using UnityEngine;
public class Rotator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
        if(gameObject.CompareTag("Spin"))
        {
            transform.Rotate (new Vector3 (0, 90, 0) * Time.deltaTime);
        }
    }

}
