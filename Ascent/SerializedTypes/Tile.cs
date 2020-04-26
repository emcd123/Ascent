using Ascent.Tiles;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using SadConsole.SerializedTypes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ascent.SerializedTypes
{
    public class TileJsonConverter : JsonConverter<Tile>
    {
        public override void WriteJson(JsonWriter writer, Tile value, JsonSerializer serializer) => serializer.Serialize(writer, (TileSerialized)value);

        public override Tile ReadJson(JsonReader reader, Type objectType, Tile existingValue,
                                        bool hasExistingValue, JsonSerializer serializer) => serializer.Deserialize<TileSerialized>(reader);
    }

    /// <summary>
    /// Serialized instance of a <see cref="Entity"/>.
    /// </summary>
    [DataContract]
    class TileSerialized : CellSerialized
    {
        [DataMember] public bool IsBlockingMove;
        [DataMember] public bool IsBlockingLOS;
        [DataMember] protected string Name;

        public static implicit operator TileSerialized(Tile baseTile)
        {
            var serializedObject = new TileSerialized()
            {
                IsBlockingLOS = baseTile.IsBlockingLOS,
                IsBlockingMove = baseTile.IsBlockingMove,
                Name = baseTile.Name,
                Foreground = baseTile.Foreground,
                Background = baseTile.Background,
                Glyph = baseTile.Glyph,
            };

            return serializedObject;
        }

        public static implicit operator Tile(TileSerialized serializedObject)
        {
            var baseTile = new Tile(Color.DarkGray, Color.Transparent, '.', "");

            baseTile.IsBlockingLOS = serializedObject.IsBlockingLOS;
            baseTile.IsBlockingMove = serializedObject.IsBlockingMove;
            baseTile.Name = serializedObject.Name;
            baseTile.Glyph = serializedObject.Glyph;
            baseTile.Foreground = serializedObject.Foreground;
            baseTile.Background = serializedObject.Background;
            return baseTile;
        }
    }
}
