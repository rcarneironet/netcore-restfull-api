using Architecture.Demo.Core.Entities.Base;

namespace Architecture.Demo.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; private set; }

        public Customer(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }

    }
}
