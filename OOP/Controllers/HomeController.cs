using OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Json;

namespace OOP.Controllers
{
    public class HomeController : Controller

    {
        public static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "WAZkKR7woJ4hpRibeKTM8ynAym4sVrt4DerGH4DE",
            BasePath = "https://testproject-25470.firebaseio.com/"
        };
        public static IFirebaseClient client;

        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Message = "Register for Login";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "test return string";
            /*Account test1 = new Account();
            test1.firstname = "Suntiparb";
            test1.username = 1;
            test1.addID();
            

                ViewBag.Message = test1.name + " " + test1.id;
            //string accountName = test1.name + " " + test1.id;
            */
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page";
            return View();
        }
        
        public async Task<ActionResult>MyAction(Account account)
        {
            //ส่วนนี้ เอาไว้รับ Set ค่า
            IFirebaseClient client = new FirebaseClient(config);
            /*
            Auto auto = new Auto();
            auto.count = 1;
            SetResponse response1 = await client.SetAsync("auto/id", auto);   // ส่วนสำคัญอยู่ที่ path ด้านหลัง ถ้าอ้างอิงไม่ถูก จะไม่ได้ข้อมูล
            Auto resultA = response1.ResultAs<Auto>();
            int counter =resultA.count;*/
            FirebaseResponse response1 = await client.GetAsync("auto/id");
            Auto auto = response1.ResultAs<Auto>();
            int autoResult = auto.count;
            int counter = autoResult + 1;
            ViewBag.auto = counter;

            SetResponse response2 = await client.SetAsync("auto/id",auto);
            Auto result2 = response2.ResultAs<Auto>(); // เดี่ยวมาทำต่อ ยังไม่เสร็จ


            account.id = counter;
            SetResponse response = await client.SetAsync("account/"+counter, account);   // ส่วนสำคัญอยู่ที่ path ด้านหลัง ถ้าอ้างอิงไม่ถูก จะไม่ได้ข้อมูล
            Account result = response.ResultAs<Account>();                             // เช่นเดียวกัน ใน class ก็ต้องตรงกันด้วย

            ViewBag.Message = "Updated";
            
            //ส่วนนี้ เอาไว้รับ Response ใช้ได้แล้ว
            /*
            // account.fullName() ดึงมาจาก class เพราะงั้น OOP ใน C# นำมาใช้งานได้s
            var data = account.fullName();
            ViewBag.Message = data;

            client = new FireSharp.FirebaseClient(config);

            FirebaseResponse response = await client.GetAsync("account/set");
            Account acc = response.ResultAs<Account>(); //อันนี้ของ Firesharp เอง
            ViewBag.tester = acc.passWord; */
            

            return View();
        }
    }
}