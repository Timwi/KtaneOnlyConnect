using System;
using System.Collections.Generic;
using System.Linq;
using OnlyConnect;
using UnityEngine;
using Rnd = UnityEngine.Random;

/// <summary>
/// On the Subject of Only Connect
/// Created by Timwi
/// </summary>
public class OnlyConnectModule : MonoBehaviour
{
    public KMBombInfo Bomb;
    public KMBombModule Module;
    public KMAudio Audio;

    void Start()
    {
        Debug.Log("[Only Connect] Started");
    }

    void ActivateModule()
    {
        Debug.Log("[Only Connect] Activated");
    }
}
