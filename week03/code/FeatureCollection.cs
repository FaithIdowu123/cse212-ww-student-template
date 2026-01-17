using System.Collections.Generic;
using System.Text.Json.Serialization;

public class FeatureCollection
{
    public List<Feature> features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string place { get; set; }
    public decimal mag { get; set; }
}
