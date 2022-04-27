using UnityEngine;

public class GroundCheck : MonoBehaviour
{
        [SerializeField] 
        private float _groundCheckRadius = 0.05f;
        [SerializeField] 
        private LayerMask _collisionMask;
        
        public bool Check()
        {
                return Physics2D.OverlapCircle(
                        transform.position, 
                        _groundCheckRadius, 
                        _collisionMask);
        }
}