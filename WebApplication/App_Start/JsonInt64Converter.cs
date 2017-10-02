using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gentex.MES.WebApplication
{
    public class JsonInt64Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long) || objectType == typeof(long?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long result = 0;
            if (reader.Value != null && Int64.TryParse(reader.Value.ToString(), out result))
            {
                if (objectType == typeof(long))
                    return result;
                else
                    return new Nullable<long>(result);
            }
            else
            {
                if (objectType == typeof(long))
                    throw new JsonSerializationException("Failed to parse int 64 from string.");
                else
                    return null as long?;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteRawValue("null");
            else
                writer.WriteRawValue(string.Concat("\"", value.ToString(), "\""));
        }
    }
}