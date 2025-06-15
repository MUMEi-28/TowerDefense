using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Color mainBlockColor;
    public Renderer ren;

    public bool isSelected;

    public bool hasTower;
    public LayerMask towerMask;

    private void FixedUpdate()
    {
        CheckTower();
    }
    private void CheckTower()
    {
        Ray ray = new Ray(transform.position, transform.up);
        hasTower = Physics.Raycast(ray, 10, towerMask);

        Debug.Log(Physics.Raycast(ray, 10, towerMask));

        Debug.DrawRay(transform.position,transform.up);
    }

    private void OnMouseEnter()
    {
        ren = transform.GetChild(0).GetChild(0).GetComponent<Renderer>();
        ren.material.color = Color.red;
    }

    /*  private void OnMouseOver()
      {
          ren = transform.GetChild(0).GetChild(0).GetComponent<Renderer>();
          ren.material.color = Color.red;

          Debug.Log("Mouse Over");
      }*/
    private void OnMouseExit()
    {
        if (!isSelected)
            transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = mainBlockColor;//FIX COLOR UGLY CODE
    }
}
