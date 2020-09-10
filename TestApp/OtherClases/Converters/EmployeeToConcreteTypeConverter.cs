using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using TestApp.Models;

namespace TestApp.OtherClases.Converters
{
    public class EmployeeToConcreteTypeConverter : Newtonsoft.Json.Converters.CustomCreationConverter<Employee>
    {
        public override Employee Create(Type objectType)
        {
            throw new NotImplementedException();
        }
        public Employee Create(Type type, JObject jObject)
        {
            var tp = (string)jObject.Property("position");
            switch (tp)
            {
                case "manager":
                    return new ManagerModel();
                case "technician":
                    return new TechnicalModel();
                case "driver":
                    return new DriverModel();
            }
            throw new ApplicationException("No such type");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var target = Create(objectType, jObject);
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
    }
}
