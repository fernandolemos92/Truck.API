namespace Truck.API.Entities;

public class TruckEvent
{

    public TruckEvent()
    {
        isDeleted = false;
    }


    public Guid Id { get; set; }

    public string Brand { get; set; }
    public string Model { get; set; }

    public int ManafactureYear { get; set; }

    public int ModelYear { get; set; }

    public bool isDeleted { get; set; }

    public void Update(string model, string brand, int manafactureyear, int modelyear)
    {
        Model = model;
        Brand = brand;
        ManafactureYear = manafactureyear;
        ModelYear = modelyear;
    }

    public void Delete()
    {
        isDeleted = true;
    }

}
