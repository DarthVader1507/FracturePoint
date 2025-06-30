using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]private Transform previous_room;
    [SerializeField]private Transform next_room;
    [SerializeField]private CameraControler cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            previous_room.gameObject.SetActive(false);
            next_room.gameObject.SetActive(true);
        }
    }
}
