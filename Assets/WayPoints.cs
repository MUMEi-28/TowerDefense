using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static WayPoints Instance;

    public Transform[] waypoints;
    private void Awake()
    {
        Instance = this;
    }

}
