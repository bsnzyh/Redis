using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Redis.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            string host = "127.0.0.1";
            //using (RedisClient redisClient = new RedisClient(host, 6379))
            using (IRedisClient redisClient = RedisManager.GetClient())
            {
                string host1 = redisClient.Host;
              
                //字符串(String)
                redisClient.Set("redis1", "default value");
                string ss = redisClient.Get<string>("redis1");
                string ss1 = redisClient.Get<string>("zyh");
                //哈希(hashes)
                Person p = new Person() { Age = 18, Name = "帝释天" };
                //redisClient.Add<Person>("hh12", p);
                //redisClient.
                //列表(list)
                //集合(sets) 

                List<string> list = new List<string>() { "12", "45", "78" };
                redisClient.AddRangeToList("shuzi", list);
                var s1 = redisClient.GetAllKeys();
                var s2 = redisClient.GetAllItemsFromList("shuzi");

                HashSet<string> hash = new HashSet<string>();
                hash.Add("bbb");
                hash.Add("aaa");
                redisClient.AddItemToSet("zyh4", "zyh1");
                redisClient.AddItemToSet("zyh4", "zyh2");
                redisClient.AddItemToSet("zyh4", "zyh3");
                redisClient.AddItemToSet("hzg", "hzg1");
                redisClient.AddItemToSet("hzg", "hzg2");
                redisClient.AddItemToSet("hzg", "hzg3");
                redisClient.AddItemToSet("hzg", "hzg1");
                HashSet<string> hash1 = redisClient.GetAllItemsFromSet("hzg");
                var s = redisClient.Sets;
                //有序集合(sorted sets)
                //if (redisClient.Get<string>(zyh) == null)
                //{
                //    // adding delay to see the difference
                //    Thread.Sleep(2000);
                //    // save value in cache
                //    redisClient.Set(zyh, "default value");
                //}
                //change the value
                //redisClient.Set(elementKey, "fuck you value");

                // get value from the cache by key
                string message = "Item value is: " + redisClient.Get<string>("zyh");
                ViewBag.message = message;
                return View();
            }

        }

    }


    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

    }
}
