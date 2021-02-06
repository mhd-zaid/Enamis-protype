using UnityEngine;

namespace _enamis_prototype.Scripts.Player
{
	public class DontGoThroughThings : MonoBehaviour
	{
		private Vector2 _previousPosition; 
		private Rigidbody2D _myRigidbody;
		private Collider2D _myCollider;
	
		private float _minimumExtent; 
		private float _partialExtent; 
		private float _sqrMinimumExtent;

		public LayerMask layerMask = -1; //make sure we aren't in this layer 
		public float skinWidth = 0.1f; //probably doesn't need to be changed 

 
		//initialize values 
		void Start() 
		{ 
			_myRigidbody = GetComponent<Rigidbody2D>();
			_myCollider = GetComponent<Collider2D>();
			_previousPosition = _myRigidbody.position;
			var bounds = _myCollider.bounds;
			_minimumExtent = Mathf.Min(Mathf.Min(bounds.extents.x, bounds.extents.y), _myCollider.bounds.extents.z); 
			_partialExtent = _minimumExtent * (1.0f - skinWidth); 
			_sqrMinimumExtent = _minimumExtent * _minimumExtent; 
		} 
 
		void FixedUpdate() 
		{ 
			//have we moved more than our minimum extent? 
			Vector3 movementThisStep = _myRigidbody.position - _previousPosition; 
			float movementSqrMagnitude = movementThisStep.sqrMagnitude;
 
			if (movementSqrMagnitude > _sqrMinimumExtent) 
			{ 
				float movementMagnitude = Mathf.Sqrt(movementSqrMagnitude);

				//check for obstructions we might have missed 
				if (Physics.Raycast(_previousPosition, movementThisStep, out var hitInfo, movementMagnitude, layerMask.value))
				{
					if (!hitInfo.collider)
						return;
 
					if (hitInfo.collider.isTrigger) 
						hitInfo.collider.SendMessage("OnTriggerEnter", _myCollider);
 
					if (!hitInfo.collider.isTrigger)
						_myRigidbody.position = hitInfo.point - (movementThisStep / movementMagnitude) * _partialExtent;
				}
			}
			_previousPosition = _myRigidbody.position; 
		}
	}
}