using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.CurrentPlatform = this;
            Destroy(gameObject, 2.5f);
            var audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
