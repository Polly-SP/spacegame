using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    GameObject curentWeapon;
    bool canPickup;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))Pickup();
    }

    private void Pickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if(hit.transform.tag == "weapon")
            {
                //if (canPickup) Drop();
                curentWeapon = hit.transform.gameObject;
                curentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                curentWeapon.transform.parent = transform;
                curentWeapon.transform.localPosition = Vector3.zero;
                curentWeapon.transform.localEulerAngles = new Vector3(20f,0,0);
                canPickup = true;
            }
        }
    }
}
