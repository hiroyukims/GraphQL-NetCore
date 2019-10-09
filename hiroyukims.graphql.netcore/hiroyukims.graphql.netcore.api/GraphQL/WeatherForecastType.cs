using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hiroyukims.graphql.netcore.api.GraphQL
{
    public class WeatherForecastType : ObjectGraphType<WeatherForecast> 
    {
        public WeatherForecastType()
        {
            Name = "WF";
            
            Field(x => x.Date).Description("Data");
            Field(x => x.Summary).Description("Resumo");
            Field(x => x.TemperatureC).Description("Temperatura em graus celsius Cº");
            Field(x => x.TemperatureF).Description("Temperatura em fahrenheit Fº");

        }
    }
}
