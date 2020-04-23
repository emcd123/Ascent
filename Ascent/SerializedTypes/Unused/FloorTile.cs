using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ascent.SerializedTypes
{
    public class FloorTileJsonConverter : JsonConverter<FloorTile>
    {
        public override void WriteJson(JsonWriter writer, FloorTile value, JsonSerializer serializer) => serializer.Serialize(writer, (FloorTileSerialized)value);

        public override FloorTile ReadJson(JsonReader reader, Type objectType, FloorTile existingValue,
                                        bool hasExistingValue, JsonSerializer serializer) => serializer.Deserialize<FloorTileSerialized>(reader);
    }

    /// <summary>
    /// Serialized instance of a <see cref="Entity"/>.
    /// </summary>
    [DataContract]
    class FloorTileSerialized : BaseTileSerialized
    {
        public static implicit operator FloorTileSerialized(FloorTile floorTile)
        {
            var serializedObject = new FloorTileSerialized()
            {
                IsBlockingMove = floorTile.IsBlockingMove,
                IsBlockingLOS = floorTile.IsBlockingLOS,
                Name = floorTile.Name,
            };

            return serializedObject;
        }

        public static implicit operator FloorTile(FloorTileSerialized serializedObject)
        {
            var floorTile = new FloorTile(false, false);
            floorTile.IsBlockingLOS = serializedObject.IsBlockingLOS;
            floorTile.IsBlockingMove = serializedObject.IsBlockingMove;
            floorTile.Name = serializedObject.Name;
            return floorTile;
        }
    }
}
