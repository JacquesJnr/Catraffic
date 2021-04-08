public class CarClass
{

    private CarClass()
    {    
       // You can have private contructors that only the public contructor can call from
    }

    public CarClass(int lane) : this()
    {
        // This is a public contructor that calls from the private one
    }
}

public class Pedestrian : CarClass
{

    // Use the 'base' syntax to refer to the base class
    public Pedestrian(int lane):base(lane)
    {
        CarClass obj = new CarClass(1);
        // Cannot be created using: CarClass obj = new CarClass();
    }   
}

public class mySampleClass
{
    public mySampleClass() : this(10)
    {
        // This is the no parameter constructor method.
        // This contructor calls the second one (because we passed)
    }

    public mySampleClass(int Age)
    {
        // This is the constructor with one parameter.
        // Second Constructor
    }
}
