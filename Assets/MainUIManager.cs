using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUIManager : MonoBehaviour
{
    public TMP_Text coinText;
    public static MainUIManager mainUIManager;
    private int currentCoins = 100;

    //SPAWN TOWER
    public GameObject[] towers;
    public float range;
    public LayerMask groundMask;
    public Transform towerParent;
    public Transform spawnPosition;

    private void Awake()
    {
        mainUIManager = this;
    }
    private void Start()
    {
        AddCoins(0);
    }

    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;
        coinText.text = "Coins: " + currentCoins.ToString();
    }

    public void SpawnTower1()
    {
        spawnPosition = ChooseBlock.chooseBlock.selectedGround.transform;

        if(!spawnPosition.gameObject.GetComponent<Ground>().hasTower)
        {
            Instantiate(towers[0], new Vector3(spawnPosition.transform.position.x, spawnPosition.transform.position.y + 1, spawnPosition.transform.position.z),
                Quaternion.identity, towerParent);
            Debug.Log("Instantiated Tower");

        }
        spawnPosition.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color =
            ChooseBlock.chooseBlock.mainBlockColor;     //RETURNS TO NORMAL COLOR AFTER CLICKING
    }
    public void SpawnTower2()
    {
        spawnPosition = ChooseBlock.chooseBlock.selectedGround.transform;

        Instantiate(towers[1], new Vector3(spawnPosition.transform.position.x, spawnPosition.transform.position.y + 1, spawnPosition.transform.position.z),
            Quaternion.identity, towerParent);

        ChooseBlock.chooseBlock.selectedGround.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = 
            ChooseBlock.chooseBlock.mainBlockColor;
    }
    public void SpawnTower3()
    {
        spawnPosition = ChooseBlock.chooseBlock.selectedGround.transform;

        Instantiate(towers[2], new Vector3(spawnPosition.transform.position.x, spawnPosition.transform.position.y + 1, spawnPosition.transform.position.z),
            Quaternion.identity, towerParent);

        ChooseBlock.chooseBlock.selectedGround.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = 
            ChooseBlock.chooseBlock.mainBlockColor;
    }
    public void SpawnTower4()
    {
        spawnPosition = ChooseBlock.chooseBlock.selectedGround.transform;

        Instantiate(towers[3], new Vector3(spawnPosition.transform.position.x, spawnPosition.transform.position.y + 1, spawnPosition.transform.position.z),
            Quaternion.identity, towerParent);

        ChooseBlock.chooseBlock.selectedGround.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = 
            ChooseBlock.chooseBlock.mainBlockColor;
    }
}
