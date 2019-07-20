using System;

namespace ContosoUniversity.Domain.Abstracts
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        public byte[] Timestamp { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}