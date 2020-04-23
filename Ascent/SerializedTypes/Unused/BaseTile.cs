using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using SadConsole.SerializedTypes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ascent.SerializedTypes
{
    public class BaseTileJsonConverter : JsonConverter<BaseTile>
    {
        public override void WriteJson(JsonWriter writer, BaseTile value, JsonSerializer serializer) => serializer.Serialize(writer, (BaseTileSerialized)value);

        public override BaseTile ReadJson(JsonReader reader, Type objectType, BaseTile existingValue,
                                        bool hasExistingValue, JsonSerializer serializer) => serializer.Deserialize<BaseTileSerialized>(reader);
    }

    /// <summary>
    /// Serialized instance of a <see cref="Entity"/>.
    /// </summary>
    [DataContract]
    class BaseTileSerialized : CellSerialized
    {
        [DataMember]public bool IsBlockingMove;
        [DataMember] public bool IsBlockingLOS;
        [DataMember] protected string Name;

        public static implicit operator BaseTileSerialized(BaseTile baseTile)
        {
            var serializedObject = new BaseTileSerialized()
            {
            };

            return serializedObject;
        }

        public static implicit operator BaseTile(BaseTileSerialized serializedObject)
        {
            var baseTile = new BaseTile(Color.DarkGray, Color.Transparent, '.', false, false);
            return baseTile;
        }
    }
}
