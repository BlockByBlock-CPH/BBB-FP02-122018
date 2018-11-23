using NetTopologySuite.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Converters
{
    public class NetTopologySuiteConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(string));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            //check if the value is empty
            if (obj.Count > 0)
            {

                var srid = obj["srid"].Value<int>();
                var wkt = obj["wellKnownText"].Value<string>();

                try
                {
                    WKTReader wKTReader = new WKTReader();
                    wKTReader.DefaultSRID = srid;
                    wKTReader.RepairRings = true;

                    var geom = wKTReader.Read(wkt);

                    return geom;

                }
                catch (Exception e)
                {
                    string stack = e.StackTrace;
                }

                return null;

            }
            else
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var geom = (NetTopologySuite.Geometries.Geometry)value;

            var obj = new JObject();

            obj.Add("wellKnownText", geom.ToText());
            obj.Add("srid", geom.SRID);

            serializer.Serialize(writer, obj);
        }
    }
}
