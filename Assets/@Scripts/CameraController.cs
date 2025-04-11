using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController Player;

    Vector3 _offset;

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (Player.Flip)
            _offset = Vector3.right * 4f;
        else
            _offset = Vector3.left * 4f;
        transform.position = Vector3.Lerp(transform.position, Player.transform.position + _offset, 5 * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
