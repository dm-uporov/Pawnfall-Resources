using UnityEngine;

namespace TwoSidesButton {
    
    /// <summary>
    ///
    /// Class <c>TwoSidesButton</c> defines the angle of 3D-object it's attached to, 
    /// implements mechanism to turn smoothly to another side
    ///
    /// In order to turn the object call the method <c>OnMouseDown</c>
    ///
    /// </summary>
    public class TwoSidesButton : MonoBehaviour
    {

        /// <value>Property <c>durationSec</c> represents the duration of turning animation</value>
        [SerializeField] private float durationSec = 0.3f;

        /// <value>Property <c>degreesToTurn</c> represents the amount of degrees to turn the object on every click</value>
        /// Default value 180 means that you have only 2 representative sides of your object
        [SerializeField] private float degreesToTurn = 180f;

        /// <value>Property <c>_state</c> is the object-helper</value>
        /// Interface <c>TwoSidesButtonState</c> defines the initial state of the object (on or off)
        /// and should implement additional logic on object clicks. For example, mute and unmute music.
        [SerializeField] private TwoSidesButtonState _state;

        private float leftDegreesToTurn = 0f;

        private float turnedOnAngle;
        private float turnedOffAngle;

        void Start()
        {
            var eulerAngles = transform.eulerAngles;
            turnedOnAngle = eulerAngles.z;
            if (turnedOnAngle <= 180)
            {
                turnedOffAngle = turnedOnAngle + 180;
            }
            else 
            {
                turnedOffAngle = turnedOnAngle - 180;
            }

            transform.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, _state.IsStateOn() ? turnedOnAngle : turnedOffAngle);
        }

        void Update()
        {
            if (leftDegreesToTurn <= 0f) return;

            float rotationDelta;
            if (leftDegreesToTurn < degreesToTurn)
            {
                rotationDelta = Time.smoothDeltaTime / durationSec * degreesToTurn;
            }
            else
            {
                rotationDelta = Time.smoothDeltaTime / durationSec * leftDegreesToTurn;
            }
            
            transform.Rotate(new Vector3(0, 0, rotationDelta), Space.Self);
            leftDegreesToTurn -= rotationDelta;
        }

        /// <summary>
        /// Method <c>OnMouseDown</c> should be called on every click on the object this script is attached to.
        /// 
        /// This method increases the angle of object by <c>degreesToTurn</c> (180 degrees by default). In other words, your object will smoothly turn to the other side.
        /// </summary>
        public void OnMouseDown()
        {
            leftDegreesToTurn += degreesToTurn;
            _state.SwitchState();
        }
    }
}