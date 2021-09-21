using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cinor : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
