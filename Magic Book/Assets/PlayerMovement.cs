using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform topLeft;
    [SerializeField] private Transform bottomRight;

    private Vector3 velocity = Vector3.zero;

    PlayerController m_playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_playerController = PlayerController.Instance;
    }

    // Update is called once per frame

    void Update()
    {
        Vector3 target = m_playerController.GetPlayerPos();

        target.x = Mathf.Clamp(target.x, topLeft.position.x, bottomRight.position.x);
        target.y = Mathf.Clamp(target.y, bottomRight.position.y, topLeft.position.y);

        transform.position = target;
    }
}
