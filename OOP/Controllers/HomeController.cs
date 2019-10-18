﻿using OOP.Models;
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
        
        public static IFirebaseClient client = new FirebaseClient(config);

        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Message = "Register for Login";
            return View();
        }

        public async Task<ActionResult> About()
        {
            FirebaseResponse response = await client.GetAsync("account/");
            int i = 10;
            List<Account> result = response.ResultAs<List<Account>>();
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page";
            return View();
        }
        
        public ActionResult Login()
        {
            if (TempData["Message"] != null) //new register
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            return View();
        }

        /*public async Task<ActionResult>MyAction(Account account)
        {
            //ส่วนนี้ เอาไว้รับ Set ค่า
            string AutoIncrement = "auto/id";

            FirebaseResponse response1 = await client.GetAsync(AutoIncrement);  // อ่านค่าจาก Auto/id ก็จะได้ count=""
            Auto auto = response1.ResultAs<Auto>();                         // ใส่ค่า count ลงใน class Auto
            int autoResult = auto.count;                                    //ส่งค่าตัวเลขที่อยู่ใน auto.count ไปให้ result เพื่อบวก
            int counter = autoResult + 1;                                   
            ViewBag.auto = counter;

            account.id = counter; // กำหนด accountID ตรงนี้ เพราะไม่ได้เก็บจากหน้า View
            SetResponse response = await client.SetAsync("account/"+counter, account);   // ส่วนสำคัญอยู่ที่ path ด้านหลัง ถ้าอ้างอิงไม่ถูก จะไม่ได้ข้อมูล
            Account result = response.ResultAs<Account>();                               // set ค่า account ไปที่ Firebase 

            SetResponse autoresponse = await client.SetAsync("auto/id/count", counter);   // ส่วนสำคัญอยู่ที่ path ด้านหลัง ถ้าอ้างอิงไม่ถูก จะไม่ได้ข้อมูล
            Auto autoresult = response.ResultAs<Auto>();                                // set ค่า account ไปที่ Firebase 

            TempData["Message"] = "Register Success"; //  ส่งกลับไปแจ้งหน้า Login ว่าสมัครสมาชิคเรียบร้อยแล้ว

            return RedirectToAction("Login");
        }*/
        public ActionResult Dashboard()
        {
            return View();
        }
        public async Task<ActionResult> ActionLogin(Account login)
        {
            // ยังไม่เสร็จ
            FirebaseResponse response = await client.GetAsync("");
            Todo todo = response.ResultAs<Todo>();

            return RedirectToAction("Dashboard");
        }

    }
}