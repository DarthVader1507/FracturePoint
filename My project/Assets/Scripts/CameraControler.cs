using UnityEngine;

public class CameraControler : MonoBehaviour
{
    //Follow player
    [SerializeField] private float speed;
    [SerializeField]private Transform player;
    [SerializeField]private float aheadDistance;
    private float lookAhead;
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), speed * Time.deltaTime);
    }
}
