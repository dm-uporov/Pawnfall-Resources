namespace TwoSidesButton {

    /// <summary>
    ///
    /// This is just a dumm realization of possible state under the music button
    ///
    /// </summary>
    public class SimpleButtonStateImpl : TwoSidesButtonState
    {

        private bool IsStateOn = true;

        public override bool IsStateOn() => IsStateOn;
        
        public override void SwitchState() => IsStateOn = !IsStateOn;

    }
}
