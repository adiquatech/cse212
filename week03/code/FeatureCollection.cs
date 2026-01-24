public class FeatureCollection
{
    public List<Feature> Features { get; set; } = new List<Feature>();
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
}

public class Feature
{
    public Properties Properties { get; set; } = new Properties();
}

public class Properties
{
    public double? Mag { get; set; }
    public string? Place { get; set; }
}