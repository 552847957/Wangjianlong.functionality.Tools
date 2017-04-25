using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wangjianlong.API.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var tool = new APITestTool { HOST_ADDRESS = "http://localhost:61709" };
            //tool.Get("/api/user/login", "{name:\"wjl\",password:\"123456\"}");
            tool.Post("/api/receive/save", "{Number:\"20170216\",Title:\"测试公文\",ConfidentialLevel:0,UID:1,Category:\"测试种类\",Emergency:1,ReceiveWord:\"20170301\",KeyWords:\"\"}");
            //tool.Post("/api/user/register", "{ ID:\"0\", Username: \"唐尧\",Password: \"123456\",Name:\"ty\",Role:\"Guest\"}");
           
            //var result = tool.Post1("/api/user/register", "{ ID:\"0\", Username: \"唐尧\",Password: \"123456\",Name:\"ty\",Role:\"Guest\"}");
            //Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
