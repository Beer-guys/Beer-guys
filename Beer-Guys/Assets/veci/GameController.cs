using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public Transform respawnPoint; // Odkaz na respawn bod

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Pokud hr�� koliduje s pikou
        {
            RespawnPlayer(other.transform); // Spust� respawn hr��e
        }
    }

    private void RespawnPlayer(Transform player)
    {
        player.position = respawnPoint.position; // Nastav� pozici hr��e na respawn bod
        // M��ete tak� prov�st dal�� akce p�i respawnu, jako nap��klad obnoven� zdrav� hr��e.
    }





}
