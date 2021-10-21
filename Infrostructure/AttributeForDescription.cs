using System;

namespace Infrostructure
{
    [AttributeUsage(AttributeTargets.Class |
    AttributeTargets.Constructor |
    AttributeTargets.Field |
    AttributeTargets.Method |
    AttributeTargets.Property,
    AllowMultiple = true)]
    public class AttributeForDescription : System.Attribute
    {
        public AttributeForDescription(string description, int number)
        {
            Description = description;
            Number = number;
        }
        public string Description { get; set; }
        public int Number { get; set; }
    }
}
