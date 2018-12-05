using BBBWebApiCodeFirst.DataTransferObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Converters
{
    public class ObjectConverter
    {
        public ObjectConverter()
        {
            

        }

        public JObject dayJson (List<MainChartDTO> list)
        {
            var obj = new JObject();

            foreach (var item in list)
            {
                if (item.HoursAct == 0)
                {
                    obj.Add("0", item.People);
                }
                if (item.HoursAct == 1)
                {
                    obj.Add("1", item.People);
                }
                if (item.HoursAct == 2)
                {
                    obj.Add("2", item.People);
                }
                if (item.HoursAct == 3)
                {
                    obj.Add("3", item.People);
                }
                if (item.HoursAct == 4)
                {
                    obj.Add("4", item.People);
                }
                if (item.HoursAct == 5)
                {
                    obj.Add("5", item.People);
                }
                if (item.HoursAct == 6)
                {
                    obj.Add("6", item.People);
                }
                if (item.HoursAct == 7)
                {
                    obj.Add("7", item.People);
                }
                if (item.HoursAct == 8)
                {
                    obj.Add("8", item.People);
                }
                if (item.HoursAct == 9)
                {
                    obj.Add("9", item.People);
                }
                if (item.HoursAct == 10)
                {
                    obj.Add("10", item.People);
                }
                if (item.HoursAct == 11)
                {
                    obj.Add("11", item.People);
                }
                if (item.HoursAct == 12)
                {
                    obj.Add("12", item.People);
                }
                if (item.HoursAct == 13)
                {
                    obj.Add("13", item.People);
                }
                if (item.HoursAct == 14)
                {
                    obj.Add("14", item.People);
                }
                if (item.HoursAct == 15)
                {
                    obj.Add("15", item.People);
                }
                if (item.HoursAct == 16)
                {
                    obj.Add("16", item.People);
                }
                if (item.HoursAct == 17)
                {
                    obj.Add("17", item.People);
                }
                if (item.HoursAct == 18)
                {
                    obj.Add("18", item.People);
                }
                if (item.HoursAct == 19)
                {
                    obj.Add("19", item.People);
                }
                if (item.HoursAct == 20)
                {
                    obj.Add("20", item.People);
                }
                if (item.HoursAct == 21)
                {
                    obj.Add("21", item.People);
                }
                if (item.HoursAct == 22)
                {
                    obj.Add("22", item.People);
                }
                if (item.HoursAct == 23)
                {
                    obj.Add("23", item.People);
                }                
            }
            return obj;
        }






        public List<WeekDTO> createMainSeriesChartObject(List<MainChartDTO>list)
        {         

            foreach (var item in list)
            {
                               
                if (item.HoursAct == 0)
                {
                    var day = item.IdDay;
                    var people = item.People;
                    dynamic serie0 = new JObject();                    

                }
                if  (item.HoursAct == 1)
                {

                }
                if (item.HoursAct == 2)
                {

                }
                if (item.HoursAct == 3)
                {

                }
                if (item.HoursAct == 4)
                {

                }
                if (item.HoursAct == 5)
                {

                }
                if (item.HoursAct == 6)
                {

                }
                if (item.HoursAct == 7)
                {

                }
                if (item.HoursAct == 8)
                {

                }
                if (item.HoursAct == 9)
                {

                }
                if (item.HoursAct == 10)
                {

                }
                if (item.HoursAct == 11)
                {

                }
                if (item.HoursAct == 12)
                {

                }
                if (item.HoursAct == 13)
                {

                }
                if (item.HoursAct == 14)
                {

                }
                if (item.HoursAct == 15)
                {

                }
                if (item.HoursAct == 16)
                {

                }
                if (item.HoursAct == 17)
                {

                }
                if (item.HoursAct == 18)
                {

                }
                if (item.HoursAct == 19)
                {

                }
                if (item.HoursAct == 20)
                {

                }
                if (item.HoursAct == 21)
                {

                }
                if (item.HoursAct == 22)
                {

                }
                if (item.HoursAct == 23)
                {

                }                           
            }
            return null;
        }
    }
}
