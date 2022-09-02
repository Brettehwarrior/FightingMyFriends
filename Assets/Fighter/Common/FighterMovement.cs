using UnityEngine;

namespace Fighter.Common
{
    public class FighterMovement : MonoBehaviour
    {
        [SerializeField] private Collider2D terrainCollider;
        [SerializeField] private LayerMask terrainLayer;
    
        public Vector2 CurrentVelocity { get; private set; }
        public bool IsGrounded { get; private set; }
    
        private Rigidbody2D _rb;
    
        private const float GroundCheckSkinWidth = 0.05f;
        private const int GroundCheckRayCount = 20;
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            CurrentVelocity = Vector2.zero;
        }

        private void Update()
        {
            CurrentVelocity = _rb.velocity;
        }
    
        private void FixedUpdate()
        {
            CheckGrounded();
        }
    
        public void SetGravityScale(float scale)
        {
            _rb.gravityScale = scale;
        }

        public void SetHorizontalVelocity(float velocity)
        {
            var newVelocity = new Vector2(velocity, CurrentVelocity.y);
            _rb.velocity = newVelocity;
            CurrentVelocity = newVelocity;
        }
    
        public void SetVerticalVelocity(float velocity)
        {
            var newVelocity = new Vector2(CurrentVelocity.x, velocity);
            _rb.velocity = newVelocity;
            CurrentVelocity = newVelocity;
        }
    
        public void Jump(float velocity)
        {
            var newVelocity = new Vector2(CurrentVelocity.x, velocity);
            _rb.velocity = newVelocity;
            CurrentVelocity = newVelocity;
        }

        private void CheckGrounded()
        {
            // Get collider bounds
            var bounds = terrainCollider.bounds;
        
            // Cast rays from center of collider to bottom of collider + skin width
            for (var horizontalOffset = -bounds.extents.x; horizontalOffset <= bounds.extents.x; horizontalOffset += bounds.extents.x * 2 / GroundCheckRayCount)
            {
                var origin = bounds.center + new Vector3(horizontalOffset, -bounds.extents.y, 0);
                var hit = Physics2D.Raycast(origin, Vector2.down, GroundCheckSkinWidth, terrainLayer);
            
                // Draw ray
                Debug.DrawRay(origin, Vector2.down * GroundCheckSkinWidth, Color.red);
            
                if (hit.collider != null)
                {
                    IsGrounded = true;
                    return;
                }
            }
        
            IsGrounded = false;
        }
    }
}
