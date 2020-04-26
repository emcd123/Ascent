using Ascent.Entities;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using SadConsole.SerializedTypes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ascent.SerializedTypes
{
    public class StairJsonConverter : JsonConverter<Stair>
    {
        public override void WriteJson(JsonWriter writer, Stair value, JsonSerializer serializer) => serializer.Serialize(writer, (StairSerialized)value);

        public override Stair ReadJson(JsonReader reader, Type objectType, Stair existingValue,
                                        bool hasExistingValue, JsonSerializer serializer) => serializer.Deserialize<StairSerialized>(reader);
    }

    /// <summary>
    /// Serialized instance of a <see cref="Entity"/>.
    /// </summary>
    [DataContract]
    public class StairSerialized : EntitySerialized
    {
        [DataMember] public bool DownStair { get; set; }

        public static implicit operator StairSerialized(Stair stair)
        {
            var serializedObject = new StairSerialized()
            {
                Name = stair.Name,
                DownStair = stair.DownStair,
                Position = stair.Position,
            };

            return serializedObject;
        }

        public static implicit operator Stair(StairSerialized serializedObject)
        {
            var stair = new Stair(Color.White, Color.Black, "Down Stairs", true, '>');
            stair.Name = serializedObject.Name;
            stair.DownStair = serializedObject.DownStair;
            stair.Position = serializedObject.Position;

            return stair;
        }
    }
}
