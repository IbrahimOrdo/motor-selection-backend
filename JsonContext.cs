using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using motor_selection_backend.Models;

[JsonSourceGenerationOptions(WriteIndented = true, GenerationMode = JsonSourceGenerationMode.Metadata)]
[JsonSerializable(typeof(User))]
[JsonSerializable(typeof(List<User>))]
[JsonSerializable(typeof(Motorcycle))]
[JsonSerializable(typeof(List<Motorcycle>))]
internal partial class JsonContext : JsonSerializerContext
{
    //public JsonContext(JsonSerializerOptions? options) : base(options)
    //{
    //}

    //protected override JsonSerializerOptions? GeneratedSerializerOptions => throw new NotImplementedException();

    //public override JsonTypeInfo? GetTypeInfo(Type type)
    //{
    //    throw new NotImplementedException();
    //}
}