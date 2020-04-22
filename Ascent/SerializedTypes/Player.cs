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
    public class PlayerSerialized/* : ActorSerialised*/
    {
        [DataMember] public int AttackPower;
        [DataMember] public int Attack;
        [DataMember] public int Defense;
        public static implicit operator PlayerSerialized(Player player)
        {
            var serializedObject = new PlayerSerialized()
            {
                AttackPower = player.AttackPower,
                Attack = player.Attack,
                Defense = player.Defense
            };

            return serializedObject;
        }

        public static implicit operator Player(PlayerSerialized serializedObject)
        {
            var player = new Player(Color.Yellow, Color.Transparent);
            player.AttackPower = serializedObject.AttackPower;
            player.Attack = serializedObject.Attack;
            player.Defense = serializedObject.Defense;
            return player;
        }
    }    
}
