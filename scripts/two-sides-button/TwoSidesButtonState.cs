using UnityEngine;

    namespace TwoSidesButton {
    /// <summary>
    ///
    /// Interface <c>TwoSidesButtonState</c> defines the initial state of the <c>TwoSidesButton</c> object (on or off)
    /// and should implement additional logic on object clicks. For example, mute and unmute music.
    ///
    /// </summary>
    public abstract class TwoSidesButtonState : MonoBehaviour
    {

        /// <summary>
        /// Depends on this method <c>TwoSidesButtonState</c> object will initiate its state.
        /// </summary>
        public abstract bool IsStateOn();
        
        /// <summary>
        /// This method is called on every click on <c>TwoSidesButtonState</c> object.
        /// Implementation should change the state. For example, mute or unmute music.
        /// </summary>
        public abstract void SwitchState();
    }
}
