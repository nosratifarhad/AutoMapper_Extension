# AutoMapper Extension

### how to use ?
### you can user this extension in business layers .
#### i use in api for sample.

```csharp
[HttpGet("todbmodel")]
public WeatherForecastDto ToDBModel()
{
    WeatherForecastVM weatherForecastVM = new WeatherForecastVM();//get result from repository

    return weatherForecastVM.ToDBModel();
}

 [HttpGet("tobusinessobject")]
public WeatherForecastVM ToBusinessObject()
{
    WeatherForecastDto weatherForecastDto = new WeatherForecastDto();//get result from repository

    return weatherForecastDto.ToBusinessObject();
}

[HttpGet("tobusinessobject-tow")]
public WeatherForecastVM Get_WeatherForecastVM_To_WeatherForecastDto()
{
    WeatherForecastVM weatherForecastVM = new WeatherForecastVM();
    WeatherForecastDto weatherForecastDto = new WeatherForecastDto();//get result from repository

    return weatherForecastDto.ToBusinessObject(weatherForecastVM);
}

[HttpGet("tobusinessobjectlist")]
public IEnumerable<WeatherForecastVM> Get_WeatherForecastDtoList()
{
    List<WeatherForecastDto> weatherForecastDtos = new List<WeatherForecastDto>();//get result from repository

    return weatherForecastDtos.ToBusinessObjectList();
}

[HttpGet("tobusinessobjectpagedlist")]
public IPagedList<WeatherForecastVM> Get_IPagedList_WeatherForecastDtoList()
{
    IEnumerable<WeatherForecastDto> weatherForecastDtos = new List<WeatherForecastDto>();//get result from repository

    return new PagedList<WeatherForecastDto>(weatherForecastDtos, pageIndex: 0, pageSize: 0).ToBusinessObjectPagedList();
}
```
### 

```csharp
public static WeatherForecastDto ToDBModel(this WeatherForecastVM businessObject)
{
    return businessObject.MapTo<WeatherForecastVM, WeatherForecastDto>();
}

public static WeatherForecastVM ToBusinessObject(this WeatherForecastDto dbModel)
{
    return dbModel.MapTo<WeatherForecastDto, WeatherForecastVM>();
}

public static WeatherForecastVM ToBusinessObject(this WeatherForecastDto dbModel, WeatherForecastVM destination)
{
    return dbModel.MapTo(destination);
}

public static IEnumerable<WeatherForecastVM> ToBusinessObjectList(this IEnumerable<WeatherForecastDto> dbModelList)
{
    List<WeatherForecastVM> businessObjectList = new List<WeatherForecastVM>();

    foreach (var dbModel in dbModelList)
        businessObjectList.Add(dbModel.MapTo<WeatherForecastDto, WeatherForecastVM>());
    return businessObjectList;
}

public static IPagedList<WeatherForecastVM> ToBusinessObjectPagedList(this PagedList<WeatherForecastDto> dbModelPagedList)
{
    PagedList<WeatherForecastVM> businessObjectPagedList = new PagedList<WeatherForecastVM>();

    businessObjectPagedList.DataList.AddRange(dbModelPagedList.DataList.ToBusinessObjectList());

    businessObjectPagedList.PageIndex = dbModelPagedList.PageIndex;
    businessObjectPagedList.PageSize = dbModelPagedList.PageSize;
    businessObjectPagedList.TotalCount = dbModelPagedList.TotalCount;
    businessObjectPagedList.TotalPages = dbModelPagedList.TotalPages;

    return businessObjectPagedList;
}

```
