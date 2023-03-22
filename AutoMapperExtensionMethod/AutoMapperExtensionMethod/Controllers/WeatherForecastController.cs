using AutoMapperExtensionMethod.Dtos;
using AutoMapperExtensionMethod.Extensions;
using AutoMapperExtensionMethod.Framework.Cmn;
using AutoMapperExtensionMethod.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperExtensionMethod.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("todbmodel")]
        public WeatherForecastDto ToDBModel()
        {
            WeatherForecastVM weatherForecastVM = new WeatherForecastVM();

            return weatherForecastVM.ToDBModel();
        }

        [HttpGet("tobusinessobject")]
        public WeatherForecastVM ToBusinessObject()
        {
            WeatherForecastDto weatherForecastDto = new WeatherForecastDto();

            return weatherForecastDto.ToBusinessObject();
        }

        [HttpGet("tobusinessobject-tow")]
        public WeatherForecastVM Get_WeatherForecastVM_To_WeatherForecastDto()
        {
            WeatherForecastVM weatherForecastVM = new WeatherForecastVM();
            WeatherForecastDto weatherForecastDto = new WeatherForecastDto();

            return weatherForecastDto.ToBusinessObject(weatherForecastVM);
        }

        [HttpGet("tobusinessobjectlist")]
        public IEnumerable<WeatherForecastVM> Get_WeatherForecastDtoList()
        {
            List<WeatherForecastDto> weatherForecastDtos = new List<WeatherForecastDto>();

            return weatherForecastDtos.ToBusinessObjectList();
        }

        [HttpGet("tobusinessobjectpagedlist")]
        public IPagedList<WeatherForecastVM> Get_IPagedList_WeatherForecastDtoList()
        {
            IEnumerable<WeatherForecastDto> weatherForecastDtos = new List<WeatherForecastDto>();

            return new PagedList<WeatherForecastDto>(weatherForecastDtos, pageIndex: 0, pageSize: 0).ToBusinessObjectPagedList();
        }

    }
}