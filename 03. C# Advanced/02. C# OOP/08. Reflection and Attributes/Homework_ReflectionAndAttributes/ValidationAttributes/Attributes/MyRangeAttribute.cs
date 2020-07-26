using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.ValidateRange(minValue, maxValue);

            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            if (obj is Int32)
            {
                return minValue <= (int)obj && (int)obj <= maxValue;
            }
            else
            {
                throw new InvalidOperationException("Can not validate given data type!");
            }
        }

        private void ValidateRange(int minValue, int maxvalue)
        {
            if (minValue > maxvalue)
            {
                throw new ArgumentException("Invalid range");
            }
        }
    }
}
