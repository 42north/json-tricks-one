using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FTN.JsonTricks
{
    public class SimpleObj : ISimpleObj
    {
        [JsonPropertyAttribute(PropertyName = "name")]
        public string Name { get; set; }

        [JsonPropertyAttribute(PropertyName = "color")]
        public string Color;

        public int version;

        [JsonPropertyAttribute(PropertyName = "attributes")]
        public List<string> Attributes;

        public SimpleObj()
        {

        }

        public void Go()
        {
            Console.WriteLine("I am one");
        }
    }
}