using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    private GameObject playerCharacter;
    private Vector3 _spawnPoint;
    [SerializeField]
    private List<Vector3> _spawnPoints = new List<Vector3>();
    
    private void Start()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {       
        if (!isServer)
        {
            return;
        }
        if (_spawnPoints != null)
        {
            _spawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)];            
        }
        else
        {
            _spawnPoint = Vector3.zero;
        }
        playerCharacter = Instantiate(playerPrefab, _spawnPoint, transform.rotation);
        NetworkServer.SpawnWithClientAuthority(playerCharacter,
        connectionToClient);
    }
}
