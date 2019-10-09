using GraphQL.Types;
using hiroyukims.graphql.netcore.api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hiroyukims.graphql.netcore.api.GraphQL
{
    public class EatMoreQuery : ObjectGraphType
    {
        public EatMoreQuery(ApplicationDbContext db)
        {

            Field<ListGraphType<WeatherForecastType>>(

                "WF",
                resolve: context =>
                {
                    var weatherForecast = db.WeatherForecast;
                    return weatherForecast;
                });

        }
    }
}
