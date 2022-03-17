using System;

namespace Alura.Loja.Testes.ConsoleApp.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public bool Deleted { get; protected set; }
        public DateTime CreatedAt { get; protected set; } = DateTime.Now;
        public DateTime UpdatedAt { get; protected set; }

        protected void SetUpdatedAt()
        {
            UpdatedAt = DateTime.Now;
        }

        public void Delete()
        {
            Deleted = true;
        }
    }

}
