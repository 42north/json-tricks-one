using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FTN.JsonTricks
{
    public class SimpleObjTwo : ISimpleObj
    {
        public string Name { get; set; }

        public string Color;

        public double Val;

        [JsonPropertyAttribute(PropertyName = "version")]
        public int Version;

        public List<string> Attributes;

        public SimpleObjTwo()
        {

        }

        public void Go()
        {
            Console.WriteLine("I am two");
        }
    }
}