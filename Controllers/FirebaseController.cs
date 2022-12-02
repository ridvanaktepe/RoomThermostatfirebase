using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp.Serialization.JsonNet;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using firebase.Database;
using firebase.Models;

namespace firebase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirebaseController : ControllerBase
    {
        // private SetData setdata;
        // public FirebaseController(SetData _setdata)
        // {
        //     setdata = _setdata;
        // }
        private IDbOperation dbOperation;

        public FirebaseController(IDbOperation _dbOperation)
        {
            dbOperation = _dbOperation;
        }
        SetData setdata = new SetData();
        // DbOperation? dbOperation;
        IFirebaseClient? client;

        IFirebaseConfig config = new FirebaseConfig
        {
            // Firebase projesinin url adresi
            BasePath =
                        "https://odatermo-default-rtdb.europe-west1.firebasedatabase.app/",
            // Firebase setting sayfasindan aldigimiz secret key
            AuthSecret = "AIzaSyBRKmCU11c7Xh0fm6dwFkf6ttoJXXBGArI"
        };



        FirebaseResponse response;

        private void Connection()
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                Console.WriteLine("Bağlantı sağlandı.");
            }
            else
            {
                Console.WriteLine("Bağlantı hatası.");
            }
        }

        //http://localhost:4406/firebase/getall
        [HttpGet("getall")]
        public async Task GetAll()
        {
            Connection();
            List<Room> listData = new List<Room>();
            
            response = await client.GetAsync(path: "");

            string result = response.Body;
            listData = setdata.setData(result);

            await dbOperation.Create(listData);
        }
    }
}
