# AutoMapper_Extension

##

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
