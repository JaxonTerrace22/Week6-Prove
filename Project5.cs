namespace prove_06;

using System.Collections.Generic;

public class FeatureCollection {
    public string Type { get; set; } = ""; // default to the empty string
    public Metadata Metadata { get; set; } = new Metadata(); // this is initialized instance
    public List<Feature> Features { get; set; } = new List<Feature>(); // for new empty list
    public List<double> Bbox { get; set; } = new List<double>(); // new empty list
}

public class Metadata {
    public long Generated { get; set; }
    public string Url { get; set; } = ""; // default to the empty string
    public string Title { get; set; } = "";
    public int Status { get; set; }
    public string Api { get; set; } = "";
    public int Count { get; set; }
}

public class Feature {
    public string Type { get; set; } = "";
    public Properties Properties { get; set; } = new Properties();
    public Geometry Geometry { get; set; } = new Geometry();
    public string Id { get; set; } = "";
}

public class Properties {
    public double? Mag { get; set; } 
    public string Place { get; set; } = "";
}

public class Geometry {
    public string Type { get; set; } = "";
    public List<double> Coordinates { get; set; } = new List<double>();
}
