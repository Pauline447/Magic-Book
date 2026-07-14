using Unity.Cinemachine;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float followSpeed = 10f;

    [SerializeField] private Transform topLeft;
    [SerializeField] private Transform bottomRight;

    [Header("CameraTarget")]
    [SerializeField] private CinemachineCamera m_cam;
    [SerializeField] private Transform m_cameraTargetPageTurn;

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

        // Restrict target position

        target.x = Mathf.Clamp(target.x, topLeft.position.x, bottomRight.position.x);
        target.y = Mathf.Clamp(target.y, bottomRight.position.y, topLeft.position.y);

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            followSpeed * Time.deltaTime
        );
    }

    public void SetCameraFollowTarget(bool pageTurnStart)
    {
        if(pageTurnStart)
        {
            m_cam.Follow = m_cameraTargetPageTurn;
        }
        else
        {
            m_cam.Follow = transform;
        }
    }
}
