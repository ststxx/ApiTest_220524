namespace ApiTest.Utils
{
    public class LIstEnumStringConvertor
    {
    }
    //public class RoleUpdateManyDto
    //{
    //    public string UserId { get; set; }

    //    [JsonConverter(typeof(ListStringConvertor))]
    //    //[JsonConverter(typeof(RoleListEnumConvertor))]
    //    public IEnumerable<string> Roles { get; set; }
    //}
    //public class RoleListEnumConvertor : JsonConverter<IEnumerable<Roles>>
    //{
    //    public override IEnumerable<Roles>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        var json = JsonSerializer.Deserialize<JsonDocument>(ref reader);
    //        var roles = new List<Roles>();
    //        foreach (var elem in json.RootElement.EnumerateArray())
    //            roles.Add(Enum.Parse<Roles>(elem.GetString()));
    //        return roles;
    //    }
    //    public override void Write(Utf8JsonWriter writer, IEnumerable<Roles> value, JsonSerializerOptions options)
    //    {
    //        writer.WriteStartArray();
    //        foreach (var role in value)
    //            writer.WriteStringValue(role.ToString());
    //        writer.WriteEndArray();
    //    }
    //}

    //public class ListStringConvertor : JsonConverter<IEnumerable<string>>
    //{
    //    public override IEnumerable<string>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        var json = JsonSerializer.Deserialize<JsonDocument>(ref reader);
    //        var rolesStr = new List<string>();
    //        foreach (var elem in json.RootElement.EnumerateArray())
    //            rolesStr.Add(elem.GetString());
    //        return rolesStr;
    //    }
    //    public override void Write(Utf8JsonWriter writer, IEnumerable<string> value, JsonSerializerOptions options)
    //    {
    //        writer.WriteStartArray();
    //        foreach (var str in value)
    //            writer.WriteStringValue(str.ToString());
    //        writer.WriteEndArray();
    //    }
    //}
}
