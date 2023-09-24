using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Movement : MonoBehaviour
{
    public float offset;
    public Rigidbody2D rb;
    public GameObject Bullet;
    public int delay;
    public int BulletSpeed;
    public ParticleSystem Jets;
    // Start is called before the first frame update
    void Start()
    {
        delay = BulletSpeed;
        Jets.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(transform.up, ForceMode2D.Force);
        }
        if (Input.GetMouseButton(1))
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offset;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Quaternion slerp = Quaternion.Slerp(transform.rotation, rotation, 1f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, slerp, 5);
        }
        if (transform.position.y >= 5.5 || transform.position.y <= -5.5)
        {
            transform.position *= new Vector2(1, -1);
        }
        if (transform.position.x >= 9.5 || transform.position.x <= -9.5)
        {
            transform.position *= new Vector2(-1, 1);
        }
        if (Input.GetKey("space")) {
            if (delay >= BulletSpeed) {
                GameObject bullet = Instantiate(Bullet, transform.position, quaternion.identity);
                bullet.transform.rotation = transform.rotation;
                bullet.GetComponent<Rigidbody2D>().AddForce(transform.up*10, ForceMode2D.Impulse);
                delay = 0;
            }

        }
        delay += 1;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Jets.Play();
        }
        if (Input.GetMouseButtonUp(0)){
            Jets.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}