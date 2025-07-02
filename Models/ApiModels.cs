using Newtonsoft.Json;

namespace SimplePokedex.Models
{
    public class Pokemon
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("types")]
        public List<TypeSlot> Types { get; set; }

        [JsonProperty("stats")]
        public List<StatSlot> Stats { get; set; }
    }

    public class TypeSlot
    {
        [JsonProperty("type")]
        public NamedResource Type { get; set; }
    }

    public class StatSlot
    {
        [JsonProperty("base_stat")]
        public int BaseStat { get; set; }

        [JsonProperty("stat")]
        public NamedResource Stat { get; set; }
    }

    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cost")]
        public int Cost { get; set; }

        [JsonProperty("effect_entries")]
        public List<EffectEntry> EffectEntries { get; set; }
    }

    public class EffectEntry
    {
        [JsonProperty("effect")]
        public string Effect { get; set; }

        [JsonProperty("language")]
        public NamedResource Language { get; set; }
    }

    public class Move
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("power")]
        public int? Power { get; set; }

        [JsonProperty("pp")]
        public int PP { get; set; }

        [JsonProperty("accuracy")]
        public int? Accuracy { get; set; }

        [JsonProperty("type")]
        public NamedResource Type { get; set; }

        [JsonProperty("damage_class")]
        public NamedResource DamageClass { get; set; }
    }

    public class NamedResource
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
