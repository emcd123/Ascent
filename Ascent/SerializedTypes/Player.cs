using Ascent.Entities;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ascent.SerializedTypes
{
    public class PlayerJsonConverter : JsonConverter<Player>
    {
        public override void WriteJson(JsonWriter writer, Player value, JsonSerializer serializer) => serializer.Serialize(writer, (PlayerSerialized)value);

        public override Player ReadJson(JsonReader reader, Type objectType, Player existingValue,
                                        bool hasExistingValue, JsonSerializer serializer) => serializer.Deserialize<PlayerSerialized>(reader);
    }

    /// <summary>
    /// Serialized instance of a <see cref="Entity"/>.
    /// </summary>
    [DataContract]
    public class PlayerSerialized : ActorSerialised
    {
        public static implicit operator PlayerSerialized(Player player)
        {
            var serializedObject = new PlayerSerialized()
            {
                Attack = player.Attack,
                AttackChance = player.AttackChance,
                Defense = player.Defense,
                DefenseChance = player.DefenseChance,
                Position = player.Position,
                Name = player.Name,
            };

            return serializedObject;
        }

        public static implicit operator Player(PlayerSerialized serializedObject)
        {
            var player = new Player(Color.Yellow, Color.Transparent);
            player.Attack = serializedObject.Attack;
            player.AttackChance = serializedObject.AttackChance;
            player.Defense = serializedObject.Defense;
            player.DefenseChance = serializedObject.DefenseChance;
            player.Name = serializedObject.Name;
            player.Position = serializedObject.Position;

            return player;
        }
    }    
}
