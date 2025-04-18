using UnityEngine;
using UnityEngine.Windows;

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
    public Animator anim;
    private bool moving;
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
        Animate();
    }

    private void FixedUpdate()
    {
        MovementUpdate();
    }
    #endregion

    #region Input Logic
    private void GatherInput()
    {
        _moveDir.x = UnityEngine.Input.GetAxisRaw("Horizontal");
        _moveDir.y = UnityEngine.Input.GetAxisRaw("Vertical");
    }
    #endregion

    #region Movement Logic
    private void MovementUpdate()
    {
        _rb.linearVelocity = _moveDir * _moveSpeed * Time.fixedDeltaTime; 
    }

    private void Animate()
    {
        if (_moveDir.magnitude > 0.1f || _moveDir.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            anim.SetFloat("x", _moveDir.x);
            anim.SetFloat("y", _moveDir.y);
        }

        anim.SetBool("Moving", moving);
    }
    #endregion
}
