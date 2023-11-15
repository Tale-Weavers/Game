using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVolumeObserver : MonoBehaviour, IObserver<bool>
{
    public void UpdateObserver(bool data)
    {
        this.gameObject.SetActive(data);
    }

    public void Start()
    {
        GameManager.instance.player.AddObserver(this);
        this.gameObject.SetActive(false);
    }
}
