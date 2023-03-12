namespace DDDTemplate.Domain
{
    public class Order : Entity, IAggregateRoot
    {
        public int OrderNr { get; set; }
        public ICollection<OrderLine>? OrderLines { get; set; }
    }
}