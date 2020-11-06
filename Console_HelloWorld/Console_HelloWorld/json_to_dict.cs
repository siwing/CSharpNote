using Markdig.Extensions.DefinitionLists;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;


namespace JsonIO
{
    public class MyData
    {
        public static Dictionary<string, string> ToDictionary(string jsonString)
        {
            var jsonObject = JObject.Parse(jsonString);
            var jTokens = jsonObject.Descendants().Where(p => !p.Any());
            var Dict = jTokens.Aggregate(new Dictionary<string, string>(),
                (properties, jToken) =>
                {
                    properties.Add(jToken.Path, jToken.ToString());
                    return properties;
                });
            return Dict;
        }
        public static Dictionary<string, int> Test2(string jsonString)
        {
            var Dict = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonString);
            return Dict;
        }
        public static void Test()
        {
            //ToDictionary(File.ReadAllText(jsonFilePath));
            //string jsonFilePath = @"C:\Users\two\Desktop\Project_Update\test.json";
            //Dictionary<string, string> jsonDict;
            //jsonDict = ToDictionary(File.ReadAllText(jsonFilePath));
            //Console.WriteLine(jsonDict);

            Dictionary<string, int> jsonIntDict;
            string jsonFilePath = @"C:\Users\two\Desktop\Project_Update\test_num.json";
            string a = File.ReadAllText(jsonFilePath);
            jsonIntDict = Test2(a);
            Console.WriteLine(jsonIntDict);
        }
    }
    public class JsonNet
    {
        class Product
        {
            public string Name { set; get; }
            public DateTime Expiry { set; get; }
            public string[] Sizes { set; get; }
        }
        /* 序列化一个类对象 */
        public static void SerializeJSON()
        {
            Product product = new Product();
            product.Name = "Apple";
            product.Expiry = new DateTime(2008, 12, 28);
            product.Sizes = new string[] { "Small" };

            string json = JsonConvert.SerializeObject(product);
            Console.WriteLine(json);
            // {
            //   "Name": "Apple",
            //   "Expiry": "2008-12-28T00:00:00",
            //   "Sizes": [
            //     "Small"
            //   ]
            // }
        }
        class Movie
        {
            public string Name { set; get; }
            public DateTime ReleaseDate { set; get; }
            public string[] Genres { set; get; }
            public string[] ALLEN { set; get; }
        }
        /* 反序列化到一个固定的类对象 */
        public static void DeserializeJSON()
        {
            string json = @"{'Name': 'Bad Boys','ReleaseDate': '1995-4-7T00:00:00', 'Genres': ['Action', 'Comedy']}";
            Movie m = JsonConvert.DeserializeObject<Movie>(json);
            Console.WriteLine($"{m.Name} {m.ReleaseDate} {m.Genres}");
        }
        /* 反序列化到一个匿名类型 × */
        public static void DeserializeAnonymous()
        {
            var definition = new { Name = "" };

            string json = @"{'Name':'James'}";
            var customer = JsonConvert.DeserializeAnonymousType(json, definition);

            Console.WriteLine(customer.Name);
            // James

            json = @"{'Name':'Mike'}";
            customer = JsonConvert.DeserializeAnonymousType(json, definition);

            Console.WriteLine(customer.Name);
            // Mike
            
            // json 中的变量可以比类型中的变量多, 但不能比类型中的变量少
            json = @"{'Name': 'Bad Boys','ReleaseDate': '1995-4-7T00:00:00', 'Genres': ['Action', 'Comedy']}";
            customer = JsonConvert.DeserializeAnonymousType(json, definition);
            Console.WriteLine(customer.Name);
        }
        //public static void Test()
        //{
        //    var json = "{\"response\":{\"a\":\"value of a\",\"b\":\"value of b\",\"c\":\"value of c\"}}";
        //    var x = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    var res = x.Deserialize<IDictionary<string, IDictionary<string, string>>>(json);

        //    foreach (var key in res.Keys)
        //    {
        //        foreach (var subkey in res[key].Keys)
        //        {
        //            Console.WriteLine(res[key][subkey]);
        //        }
        //    }
        //}

        /* 可能是有效的 */
        public static void DeserializeToDataSet()
        {
            // 原始示例
            string json = @"{'Table1': [{'id': 0, 'item': 'item 0'}, {'id': 1, 'item': 'item 1'}]}";
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);

            DataTable dataTable = dataSet.Tables["Table1"];

            Console.WriteLine(dataTable.Rows.Count);
            
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["id"] + " - " + row["item"]);
            }

            // 示例2
            json = @"{'Table1': [{'id': 0, 'item': 'item 0'}], 'Table2': [{'id': 1, 'item': 'item 1'}, {'id': 2, 'item': 'item 2'}]}";
            dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            
            dataTable = dataSet.Tables["Table1"];
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["id"] + " - " + row["item"]);
            }

            dataTable = dataSet.Tables["Table2"];
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["id"] + " - " + row["item"]);
            }

            // 示例3
            //json = @"{'Table1': [{'id': 0, 'item': 'item 0'}], 'Table2': 'item2'";
            //json = @"{'Table1': [{'id': 0, 'item': 'item 0'}], 'Table2': ['item2']";
            //dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            //dataTable = dataSet.Tables["Table1"];
            //foreach (DataRow row in dataTable.Rows)
            //{
            //    Console.WriteLine(row["id"] + " - " + row["item"]);
            //}
        }
        public static void DeserializeToDict()
        {
            string jsonFilePath = @"C:\Users\two\Documents\git\CSharpNote\Console_HelloWorld\Console_HelloWorld\file\json.json";
            string jsonString = File.ReadAllText(jsonFilePath);

            var jsonObject = JObject.Parse(jsonString);
            var jTokens = jsonObject.Descendants().Where(p => !p.Any());
            var Dict = jTokens.Aggregate(new Dictionary<string, string>(),
                (properties, jToken) =>
                {
                    properties.Add(jToken.Path, jToken.ToString());
                    return properties;
                });
            foreach (var item in Dict)
            {
                Console.WriteLine(item);
            }
        }
        /* Simple Dict */
        public static void DeserializeToDict2()
        {
            string jsonFilePath = @"D:\1.User\Desktop 2\Wiki\CSharpNote\Console_HelloWorld\Console_HelloWorld\file\json.json";
            string jsonString = File.ReadAllText(jsonFilePath);
            var Dict = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonString);
        }
        /* 反序列化到一个Collection × */
        public static void DeserializeCollection()
        {
            string jsonFilePath = @"D:\1.User\Desktop 2\Wiki\CSharpNote\Console_HelloWorld\Console_HelloWorld\file\json.json";
            string jsonString = File.ReadAllText(jsonFilePath);
            List<string> videogames = JsonConvert.DeserializeObject<List<string>>(jsonString);
        }
        //public dynamic GetObject()
        //{
        //    dynamic d = new ExpandoObject();
        //    // 将JSON字符串反序列化
        //    JavaScriptSerializer s = new JavaScriptSerializer();
        //    object resobj = s.DeserializeObject(this.innerJson);
        //    // 拷贝数据
        //    IDictionary<string, object> dic = (IDictionary<string, object>)resobj;
        //    IDictionary<string, object> dicdyn = (IDictionary<string, object>)d;
        //    foreach (var item in dic)
        //    {
        //        dicdyn.Add(item.Key, item.Value);
        //    }
        //    return d;
        //}
        public class Wrapper
        {
            [JsonProperty("records")]
            public Dictionary<string, Record> Records { get; set; }
        }
        public class Record
        {
            [JsonProperty(PropertyName = "Value1")]
            public string Value1 { get; set; }

            [JsonProperty(PropertyName = "Value2")]
            public string Value2 { get; set; }
        }
        public static void DeserializeToObject()
        {
            string json = @"{
						""records"" : {
							""123"": {
								""Value1"": ""test"",
								""Value2"": ""test2"",
							},
							""456"": {
								""Value1"": ""test"",
								""Value2"": ""test2"",
							} 
						}
					}";

            var wrapper = JsonConvert.DeserializeObject<Wrapper>(json);

            foreach (var key in wrapper.Records.Keys)
            {
                var val = wrapper.Records[key];
                Console.WriteLine(" - {0}", key);
                Console.WriteLine("   - {0}", val.Value1);
                Console.WriteLine("   - {0}", val.Value2);
            }
        }
    }
    public class DoForJson
    {
        public static void Show()
        {
            //JsonNet.DeserializeToDataSet();

            // [{}] x
            JsonNet.DeserializeToDict();
            //JsonNet.DeserializeToDict2();
            // [{}] x
            //JsonNet.DeserializeCollection();
            
            //JsonNet.DeserializeToObject();
        }
    }
}


					
