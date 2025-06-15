using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBlock : MonoBehaviour
{
    //CHOOSE BLOCK
    private Camera cam;
    public float mousePositionZ;
    public float range;
    public LayerMask groundMask;
    public Color mainBlockColor;
    public GameObject selectedGround;
    public GameObject chooseTowerCanvas;
    public static ChooseBlock chooseBlock;

    //BUILD SAND
    public Transform groundParent;
    public GameObject groundSandPrefab;


    private void Awake()
    {
        chooseBlock = this;
    }

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
   //     UpdateSelectedGround();
        Choose();
    }

    private void Choose()   
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) )
        {
            if (Physics.Raycast(ray, out hit, range, groundMask))
            {
                //  hit.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                selectedGround = hit.transform.gameObject;
                chooseTowerCanvas.SetActive(true);
                UpdateSelectedGround();

                hit.transform.gameObject.GetComponent<Ground>().isSelected = true;
            }
        }
    }
    private void UpdateSelectedGround()
    {
        if (selectedGround != null)
        {
            selectedGround.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = Color.red;

            /*  GameObject previousGround = selectedGround;
              previousGround.GetComponent<Renderer>().material.color = mainBlockColor;*/
        }
       

    }


    //BUILDER
    private void BuildSand()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, range, groundMask))
            {
                Destroy(hit.transform.gameObject);
                Instantiate(groundSandPrefab, hit.transform.position, Quaternion.identity, groundParent);
                //   hit.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                //  chooseTowerCanvas.SetActive(true);
            }
        }
    }
}
