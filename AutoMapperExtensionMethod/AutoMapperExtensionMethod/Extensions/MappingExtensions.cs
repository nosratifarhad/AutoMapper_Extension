using AutoMapperExtensionMethod.Dtos;
using AutoMapperExtensionMethod.Framework.Cmn;
using AutoMapperExtensionMethod.Framework.Infrastructure.Mapper;
using AutoMapperExtensionMethod.ViewModels;

namespace AutoMapperExtensionMethod.Extensions
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #region WeatherForecastDto

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

        #endregion
    }
}
