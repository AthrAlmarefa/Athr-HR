using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Athr.Domain.BuildingBlocks;

namespace Athr.Infrastructure.Outbox;

public class DomainEventConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(IDomainEvent).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);
        string? typeName = jsonObject["$type"]?.Value<string>();

        if (string.IsNullOrEmpty(typeName))
        {
            throw new JsonSerializationException("$type property not found or empty.");
        }

        var type = Type.GetType(typeName);
        if (type != null)
        {
            object? target = Activator.CreateInstance(type);

            // Populate the object properties
            serializer.Populate(jsonObject.CreateReader(), target!);

            return target;
        }

        // Create an instance of the target type
        throw new JsonSerializationException($"Unable to find type: {typeName}");
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotImplementedException("Not needed for this example.");
    }
}
