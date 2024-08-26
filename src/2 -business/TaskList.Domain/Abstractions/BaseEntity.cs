namespace TaskList.Domain.Abstractions
{
    public record BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDelete { get; set; }

        public void SetId(Guid id)
        {
            if (Guid.Empty.Equals(id))
                throw new ArgumentException("Id is not valid");
            Id = id;
        }

        public bool SetDeleted() => IsDelete = true;
    }
}
