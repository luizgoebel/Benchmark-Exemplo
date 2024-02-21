using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<CarBenchmark>();

[MemoryDiagnoser]
public class CarBenchmark
{
    private List<Car> cars;

    [GlobalSetup]
    public void GlobalSetup()
    {
        cars =
        [
            new Car { Make = "Ford" },
            new Car { Make = "Toyota" },
            new Car { Make = "Chevrolet" },
            new Car { Make = "BMW" },
            new Car { Make = "Tesla" },
            new Car { Make = "Honda" },
            new Car { Make = "Nissan" },
            new Car { Make = "Hyundai" },
            new Car { Make = "Volkswagen" },
            new Car { Make = "Mercedes-Benz" }
        ];
    }

    [Benchmark]
    public bool HasTeslaUsingCount() => cars.Count(car => car.Make == "Tesla") > 0;
    [Benchmark]
    public bool HasTeslaUsingAny() => cars.Any(car => car.Make == "Tesla");
}

public class Car
{
    public string Make { get; set; }
}