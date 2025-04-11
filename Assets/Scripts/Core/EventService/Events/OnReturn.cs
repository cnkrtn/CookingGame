namespace Core.EventService.Events
{
    public class OnReturn
    {
        public bool Value;
        public int ValueSlider;
        public bool IsSlider;
        public bool ValueSetAvailable;
        public OnReturn(bool value)
        {
            Value = value;
            IsSlider = false;
        }
        public OnReturn(int valueSlider,bool valueSetAvailable)
        {
            ValueSlider = valueSlider;
            IsSlider = true;
            ValueSetAvailable = valueSetAvailable;
        }
    }
}