using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienURL : MonoBehaviour
{
    [SerializeField] string link;

    public string GetURL()
    {
        return link;
    }
}
