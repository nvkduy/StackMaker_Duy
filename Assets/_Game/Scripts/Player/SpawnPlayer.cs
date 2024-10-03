
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;

    private GameObject currentPlayer;
    // Start is called before the first frame update
    private void OnEnable()
    {
        SpwanPlayers();
    }

    private void OnDisable()
    {
        Destroy(currentPlayer);
    }

    // Update is called once per frame
    private void SpwanPlayers()
    {
        
        if (playerPrefab != null && spawnPoint != null)
        {
            
            currentPlayer = Instantiate(playerPrefab, new Vector3(spawnPoint.position.x, spawnPoint.position.y + 3f, spawnPoint.position.z), spawnPoint.rotation,this.transform);
            
        }
       
    }

}
