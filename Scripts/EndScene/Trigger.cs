using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{ 

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        EndGame();
    }

    public void EndGame()
    {
        PlayerManager.Instance.Player.controller.ToggleCursor();
        SceneManager.LoadScene("EndingScene");
    }   
}

