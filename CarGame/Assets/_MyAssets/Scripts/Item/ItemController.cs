using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemController : MonoBehaviour
{
    [Inject]
    private IPlayerParametor _playerParametor = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;

        _playerParametor.SetEnergy(10);
        gameObject.SetActive(false);
    }
}
