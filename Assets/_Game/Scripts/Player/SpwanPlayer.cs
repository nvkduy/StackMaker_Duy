
using UnityEngine;

public class SpwanPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spwanPoint;
    // Start is called before the first frame update
    void Start()
    {
        this.SpwanPlayers();
    }

    // Update is called once per frame
    private void SpwanPlayers()
    {
        
        if (playerPrefab != null && spwanPoint != null)
        {
            Instantiate(playerPrefab, new Vector3(spwanPoint.position.x, spwanPoint.position.y + 3f, spwanPoint.position.z), spwanPoint.rotation);

        }
       
    }

}
