using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FTN.JsonTricks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program p = new Program();

            string simpleJson = File.ReadAllText("json/single-obj.json");
            string multipleJson = File.ReadAllText("json/multiple-obj.json");

            dynamic obj = p.DynamicJsonObject(simpleJson);
            Console.WriteLine("-=-=-=-=- Single Dynamic Object -=-=-=-=-");
            Console.WriteLine("Type: {0}", obj.GetType());
            Console.WriteLine("Name: {0}", obj.name);
            Console.WriteLine("Color: {0}", obj.color);
            Console.WriteLine("Version: {0}", obj.version);
            Console.WriteLine("Attributes: {0}", obj.attributes);
            Console.WriteLine("Attributes Type: {0}", obj.attributes.GetType());

            SimpleObj so = p.SimpleObj(simpleJson);
            Console.WriteLine("-=-=-=-=- Single Typed Object -=-=-=-=-");
            Console.WriteLine("Type: {0}", so.GetType());
            Console.WriteLine("Name: {0}", so.Name);
            Console.WriteLine("Color: {0}", so.Color);
            Console.WriteLine("Version: {0}", so.version);
            Console.WriteLine("Attributes: {0}", so.Attributes);
            Console.WriteLine("Attributes Type: {0}", so.Attributes.GetType());

            List<ISimpleObj> sl = p.SimpleObjList(multipleJson);
            Console.WriteLine("-=-=-=-=- Multiple Typed Object -=-=-=-=-");

            sl.ForEach((sl1) =>
            {
                Console.WriteLine("Type: {0}", sl1.GetType());
                Console.WriteLine("Name: {0}", sl1.Name);
                sl1.Go();
            });
        }

        public dynamic DynamicJsonObject(string json)
        {
            return JsonConvert.DeserializeObject<dynamic>(json);
        }

        public SimpleObj SimpleObj(string json)
        {
            return JsonConvert.DeserializeObject<SimpleObj>(json);
        }

        public List<ISimpleObj> SimpleObjList(string json)
        {
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);
            List<ISimpleObj> list = new List<ISimpleObj>();

            foreach (dynamic o in obj.jsonObjects)
            {
                if (o.version == 1)
                    list.Add((ISimpleObj)JsonConvert.DeserializeObject<SimpleObj>(o.ToString()));
                else if (o.version == 2)
                    list.Add((ISimpleObj)JsonConvert.DeserializeObject<SimpleObjTwo>(o.ToString()));
            }

            return list;
        }
    }
}
