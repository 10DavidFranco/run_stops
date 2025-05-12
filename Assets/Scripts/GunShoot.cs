using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] GameObject referenceProjectile;
    [SerializeField] Transform barrel;

    Vector3 destination;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Onfire();
        }
    }

    void CreateProjectile()
    {
        GameObject projectile = Instantiate(referenceProjectile,barrel.position,Quaternion.identity);
        Destroy(projectile, 10);
        projectile.GetComponent<Rigidbody>().AddForce((destination-projectile.transform.position).normalized*50.0f,ForceMode.Impulse);

    }

    void Onfire()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit,Mathf.Infinity))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);

        CreateProjectile();
    }
}
