using UnityEngine;

[SelectionBase]
public class Player_Controller : MonoBehaviour
{
    #region Editor Data
    [Header("Movement Attributes")]
    [SerializeField] float _moveSpeed = 50f;
    #endregion

    #region Editor Data
    [Header("Dependencies")]
    [SerializeField] Rigidbody2D _rb;
    #endregion

    #region Internal Data
    private Vector2 _moveDir = Vector2.zero;
    #endregion

    #region Tick
    

    private void Start()
    {
        // Get the spawn position from PlayerPrefs after the scene loads
        float spawnX = PlayerPrefs.GetFloat("SpawnX", 0f);  // Default to (0, 0) if not set
        float spawnY = PlayerPrefs.GetFloat("SpawnY", 0f);  // Default to (0, 0) if not set
        transform.position = new Vector2(spawnX, spawnY);  // Set the player’s position
    }

    private void Update()
    {
        GatherInput();
    }

    private void FixedUpdate()
    {
        MovementUpdate();
    }
    #endregion

    #region Input Logic
    private void GatherInput()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");
    }
    #endregion

    #region Movement Logic
    private void MovementUpdate()
    {
        _rb.linearVelocity = _moveDir * _moveSpeed * Time.fixedDeltaTime; 
    }
    #endregion
}
