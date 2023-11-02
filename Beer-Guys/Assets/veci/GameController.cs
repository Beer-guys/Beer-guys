using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public Transform respawnPoint; // Odkaz na respawn bod

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Pokud hráè koliduje s pikou
        {
            RespawnPlayer(other.transform); // Spustí respawn hráèe
        }
    }

    private void RespawnPlayer(Transform player)
    {
        player.position = respawnPoint.position; // Nastaví pozici hráèe na respawn bod
        // Mùžete také provést další akce pøi respawnu, jako napøíklad obnovení zdraví hráèe.
    }





}
