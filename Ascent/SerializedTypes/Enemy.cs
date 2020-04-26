using Ascent.Entities;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ascent.SerializedTypes
{
    public class EnemyJsonConverter : JsonConverter<Enemy>
    {
        public override void WriteJson(JsonWriter writer, Enemy value, JsonSerializer serializer) => serializer.Serialize(writer, (EnemySerialized)value);

        public override Enemy ReadJson(JsonReader reader, Type objectType, Enemy existingValue,
                                        bool hasExistingValue, JsonSerializer serializer) => serializer.Deserialize<EnemySerialized>(reader);
    }

    /// <summary>
    /// Serialized instance of a <see cref="Entity"/>.
    /// </summary>
    [DataContract]
    public class EnemySerialized : ActorSerialised
    {
        public static implicit operator EnemySerialized(Enemy enemy)
        {
            var serializedObject = new EnemySerialized()
            {
                MaxHealth = enemy.MaxHealth,
                Health = enemy.Health,
                Attack = enemy.Attack,
                AttackChance = enemy.AttackChance,
                Defense = enemy.Defense,
                DefenseChance = enemy.DefenseChance,
                Position = enemy.Position,
                Name = enemy.Name,
            };

            return serializedObject;
        }

        public static implicit operator Enemy(EnemySerialized serializedObject)
        {
            var enemy = new Enemy(Color.Blue, Color.Transparent);
            enemy.MaxHealth = serializedObject.MaxHealth;
            enemy.Health = serializedObject.Health;
            enemy.Attack = serializedObject.Attack;
            enemy.AttackChance = serializedObject.AttackChance;
            enemy.Defense = serializedObject.Defense;
            enemy.DefenseChance = serializedObject.DefenseChance;
            enemy.Name = serializedObject.Name;
            enemy.Position = serializedObject.Position;

            return enemy;
        }
    }
}
