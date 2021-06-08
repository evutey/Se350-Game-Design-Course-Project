using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DeleteCameraFollow());
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
    IEnumerator DeleteCameraFollow()
    {
        yield return new WaitForSeconds(0);
        player = GameObject.Find("Fisherman");
    }
}