[![Build status](https://ci.appveyor.com/api/projects/status/gg99gx59nlb493hb?svg=true)](https://ci.appveyor.com/project/lillheaton/eserializer)
[![NuGet](https://img.shields.io/nuget/v/ESerializer.svg)](https://www.nuget.org/packages/ESerializer/)

# ESerializer
A serializer specific for EPiServers content types and objects. This tool comes with a standard set of "converters" that allows you to serialize IContent objects or objects containing IContent.
This tool builds on top of [JsonContractSimplifier](https://github.com/lillheaton/JsonContractSimplifier) which in turn builds on top of [Json.NET](https://www.newtonsoft.com/json/)

### Installation
    PM> Install-Package ESerializer

### Usage
Usage documentation would be referring to [JsonContractSimplifier](https://github.com/lillheaton/JsonContractSimplifier). 
The key difference here is another interface to implement converters IEPropertyConverter<> that implements IObjectConverter<> from [JsonContractSimplifier](https://github.com/lillheaton/JsonContractSimplifier).
This project utilizes EPiServer IoC/DI container to register and find all converters. So you need to register them on IConverter

```C#
[ServiceConfiguration(typeof(IConverter), Lifecycle = ServiceInstanceScope.Singleton)]
public class LinkItemCollectionPropertyConverter : IEPropertyConverter<LinkItemCollection>
{
    public object Convert(LinkItemCollection target)
    {
        return target?.Select(s => new { s.Title, s.Text, s.Href, s.Attributes, s.Target }).ToArray();
    }
}
```

##### Hide specific properties
This project builds on top of Json.NET so you can utilize all already existing Json.NET attributes

