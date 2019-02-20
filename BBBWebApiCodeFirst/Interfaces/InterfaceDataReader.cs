using BBBWebApiCodeFirst.DataTransferObjects;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Interfaces
{
    interface InterfaceDataReader
    {
        TopDayDTO ReadTopDayDTO(NpgsqlDataReader reader);

        MainChartDTO ReadMainChartDTO(NpgsqlDataReader reader);

        TopDTO ReadTopDTO(NpgsqlDataReader reader);

        TableHomeDayDTO ReadTableHomeDayDTO(NpgsqlDataReader reader);

        TableHomeWeekDTO ReadTableHomeWeekDTO(NpgsqlDataReader reader);

        AreaOfInfluenceDTO ReadAreaOfInfluenceDTO(NpgsqlDataReader reader);

        HomeZoneWheelDTO ReadHomeZoneWheelDTO(NpgsqlDataReader reader)

    }
}
