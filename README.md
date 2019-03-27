[![Build status](https://ci.appveyor.com/api/projects/status/qa0ut9qrbsa7k4wl?svg=true)](https://ci.appveyor.com/project/lillheaton/episerializer)
[![NuGet](https://img.shields.io/nuget/v/EPiSerializer.svg)](https://www.nuget.org/packages/EPiSerializer/)

# EPiSerializer
A serializer specific for EPiServers content types and objects. This tool comes with a standard set of "converters" that allows you to serialize IContent objects or objects containing IContent.
This tool builds on top of [EOls.Serialization](https://github.com/lillheaton/EOls.Serialization) which in turn builds on top of [Json.NET](https://www.newtonsoft.com/json/)

### Installation
    PM> Install-Package EPiSerializer

### Usage
Usage documentation would be referring to [EOls.Serialization](https://github.com/lillheaton/EOls.Serialization). 
The key difference here is another interface to implement converters IApiPropertyConverter<> that implements IObjectConverter<> from [EOls.Serialization](https://github.com/lillheaton/EOls.Serialization).

```C#
public class LinkItemCollectionPropertyConverter : IApiPropertyConverter<LinkItemCollection>
{
    public object Convert(LinkItemCollection target)
    {
        return target?.Select(s => new { s.Title, s.Text, s.Href, s.Attributes, s.Target }).ToArray();
    }
}
```

##### Hide specific properties
You can either you the JsonIgnore attribute or ApiPropertyAttribute. 

##### Setup a API
The tool https://github.com/lillheaton/eols.EPiContentApi is setting up a small API endpoint and controller to load and serialize content based on page ID.