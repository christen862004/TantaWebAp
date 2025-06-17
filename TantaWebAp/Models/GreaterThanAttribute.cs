using System.ComponentModel.DataAnnotations;

namespace TantaWebAp.Models
{
    public class GreaterThanAttribute:ValidationAttribute
    {
        public int Number { get; set; }
        public GreaterThanAttribute()
        {
                
        }
        public GreaterThanAttribute(int Number)
        {
            this.Number=Number;
        }
        public override bool IsValid(object? value)
        {
            int salary = int.Parse(value.ToString());
            if (salary > this.Number)
                return true;
            return false;
        }
    }
}
