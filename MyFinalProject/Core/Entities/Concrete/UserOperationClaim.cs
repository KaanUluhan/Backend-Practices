namespace Core.Entities.Concrete          //northwind de 3 tane tablo oluşturduk onları burada tanımladık dosyalara ayırdık
{
    public class UserOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
