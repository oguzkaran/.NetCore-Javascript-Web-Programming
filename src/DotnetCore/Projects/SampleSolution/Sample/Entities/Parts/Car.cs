namespace CSD.Application.Entities
{
    public partial class Car
    {
        public override string ToString()
        {
            return $"Vin:{Vin}, RegisterDate:{TrafficRegisterDate.ToShortDateString()}, Make:{Make}, Model:{Model}";
        }
    }
}
