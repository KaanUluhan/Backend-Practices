namespace Core.Entities.Concrete          //northwind de 3 tane tablo oluşturduk onları burada tanımladık dosyalara ayırdık
{
    public class OperationClaim:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
