

using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class LocalMultiplayerManager : MonoBehaviour
{
    public List<Sprite> possiblePlayerVisuals;
    public List<PlayerInput> existingPlayers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayerJoined(PlayerInput newPlayer)
    {
        //ASSIGN VISUALS TO THIS NEW PLAYER
        SpriteRenderer newPlayerRenderer = newPlayer.GetComponent<SpriteRenderer>();
        newPlayerRenderer.sprite = possiblePlayerVisuals[existingPlayers.Count];

        existingPlayers.Add(newPlayer);

        LocalMultiPlayer playerScript = newPlayer.GetComponent<LocalMultiPlayer>();
        playerScript.manager = this;

        //THIS IS THE SAME THING:
        //playerScript.manager = gameObject.GetComponent<LocalMultiplayerManager>();



    }
}