using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // -------- //
    // MOVEMENT //
    // -------- //

    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        SetAnimations();

    }

    // ---------- //
    // ANIMATIONS //
    // ---------- //

    public const string IDLE = "Idle";
    public const string WALK = "Walk";
    public const string ATTACK1 = "Attack 1";
    public const string ATTACK2 = "Attack 2";

    string currentAnimationState;

    Animator animator;

    public void ChangeAnimationState(string newState)
    {
        if (currentAnimationState == newState) return;

        currentAnimationState = newState;
        animator.CrossFadeInFixedTime(currentAnimationState, 0.2f);
    }

    void SetAnimations()
    {
        if (!attacking)
        {
            if (velocity.x == 0 && velocity.z == 0)
            { ChangeAnimationState(IDLE); }
            else
            { ChangeAnimationState(WALK); }
        }
    }

    // ------------------- //
    // ATTACKING BEHAVIOUR //
    // ------------------- //

    [SerializeField] private float attackDistance = 5f;
    [SerializeField] private float attackDelay = 0.4f;
    [SerializeField] private float attackSpeed = 0.65f;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private LayerMask attackLayer;
    [SerializeField] private Camera cam;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip swordSwing;
    [SerializeField] private AudioClip hitSound;

    bool attacking = false;
    int attackCount;

    public void Attack()
    {
        if (attacking) return;

        attacking = true;

        Invoke(nameof(ResetAttack), attackSpeed);
        Invoke(nameof(AttackRaycast), attackDelay);

        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(swordSwing);

        if (attackCount == 0)
        {
            ChangeAnimationState(ATTACK1);
            attackCount++;
        }
        else
        {
            ChangeAnimationState(ATTACK2);
            attackCount = 0;
        }
    }

    void ResetAttack()
    {
        attacking = false;
    }
    
    void AttackRaycast()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, attackDistance, attackLayer))
        {
            HitTarget();

            if (hit.transform.TryGetComponent<Enemy>(out Enemy T))
            { 
                T.TakeDamage(attackDamage);
            }
        }
    }

    void HitTarget()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(hitSound);
    }
}
