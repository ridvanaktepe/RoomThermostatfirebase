
using Newtonsoft.Json.Linq;
using firebase.Models;
using Newtonsoft.Json;

namespace firebase.Controllers
{
    public class SetData
    {
        List<Room> listData = new List<Room>();
      
        public List<Room> setData(string result)
        {
            JObject jObject = JObject.Parse(result);

            Console.WriteLine("------------------------111111--------------------------------\t");

            for (var i = 0; i < jObject.Count; i++)
            {
                Room room = new Room();
                string roomKey = string.Format("Oda{0}", i + 1);
                room.RoomName = roomKey;
                room.Set_Temp = (int)(jObject[roomKey]["Set_Temp"]);
                room.Status = (int)(jObject[roomKey]["Temp"]);
                room.Temp = (int)(jObject[roomKey]["Status"]);
                room.Voltage = (int)(jObject[roomKey]["Voltage"]);

                listData.Add(room);

            }

            return listData;
        }
    }
}
