using UnityEngine;
using UnityEngine.SceneManagement;

public class EndWaypoint : MonoBehaviour
{
    [SerializeField] private Waypoint waypoint;

    private void Start()
    {
        waypoint.Completed += Completed;
    }

    private void Completed()
    {
        SceneManager.LoadScene(5);
    }
}
