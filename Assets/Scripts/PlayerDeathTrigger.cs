using UnityEngine;

public class PlayerDeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            FindObjectOfType<LevelManager>().ResetLevel(false);
        }
    }
}
