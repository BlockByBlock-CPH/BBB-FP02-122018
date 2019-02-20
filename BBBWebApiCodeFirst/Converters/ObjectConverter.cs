using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Converters
{
    public class ObjectConverter: IObjectConverter
    {
        public ObjectConverter()
        {

        }

        public JObject MainChartDayJson(List<MainChartDTO> list)
        {
            var obj = new JObject();
            var series = HourlyPeopleJson(list);
            var labels = TimeJson();
            var day = DayJson(list);
            
            obj.Add("series", series);
            obj.Add("labels", labels);
            obj.Add("title", day);

            return obj;
        }

        public JObject HourlyPeopleJson(List<MainChartDTO> list)
        {
            var obj = new JObject();
            var series = new JObject();

            foreach (var item in list)
            {
                if (item.Hour == 0)
                {
                    obj.Add("0", item.People);
                }
                if (item.Hour == 1)
                {
                    obj.Add("1", item.People);
                }
                if (item.Hour == 2)
                {
                    obj.Add("2", item.People);
                }
                if (item.Hour == 3)
                {
                    obj.Add("3", item.People);
                }
                if (item.Hour == 4)
                {
                    obj.Add("4", item.People);
                }
                if (item.Hour == 5)
                {
                    obj.Add("5", item.People);
                }
                if (item.Hour == 6)
                {
                    obj.Add("6", item.People);
                }
                if (item.Hour == 7)
                {
                    obj.Add("7", item.People);
                }
                if (item.Hour == 8)
                {
                    obj.Add("8", item.People);
                }
                if (item.Hour == 9)
                {
                    obj.Add("9", item.People);
                }
                if (item.Hour == 10)
                {
                    obj.Add("10", item.People);
                }
                if (item.Hour == 11)
                {
                    obj.Add("11", item.People);
                }
                if (item.Hour == 12)
                {
                    obj.Add("12", item.People);
                }
                if (item.Hour == 13)
                {
                    obj.Add("13", item.People);
                }
                if (item.Hour == 14)
                {
                    obj.Add("14", item.People);
                }
                if (item.Hour == 15)
                {
                    obj.Add("15", item.People);
                }
                if (item.Hour == 16)
                {
                    obj.Add("16", item.People);
                }
                if (item.Hour == 17)
                {
                    obj.Add("17", item.People);
                }
                if (item.Hour == 18)
                {
                    obj.Add("18", item.People);
                }
                if (item.Hour == 19)
                {
                    obj.Add("19", item.People);
                }
                if (item.Hour == 20)
                {
                    obj.Add("20", item.People);
                }
                if (item.Hour == 21)
                {
                    obj.Add("21", item.People);
                }
                if (item.Hour == 22)
                {
                    obj.Add("22", item.People);
                }
                if (item.Hour == 23)
                {
                    obj.Add("23", item.People);
                }
            }
            series.Add("serie0", obj);
            return series;
        }


        public JObject TimeJson()
        {
            var obj = new JObject();

            for (int i = 0; i < 24; i++)
            {
                string stringValue = i.ToString();
                int intValue = i;
                obj.Add(stringValue, intValue);
            }      
            return obj;
        }


        public JObject DayJson(List<MainChartDTO> list)
        {
            var obj = new JObject();

            foreach (var item in list)
            {
                obj.Add("0", item.Day);
                break;
            }

            return obj;
        }

        public JObject MainChartWeekJson (List<MainChartDTO> list)
        {
            var obj = new JObject();
            var series = WeeklyPeopleJson(list);
            var labels = WeekDayJson();

            obj.Add("series", series);
            obj.Add("labels", labels);
            return obj;
        }

        public JObject WeeklyPeopleJson(List<MainChartDTO> list)
        {
            var obj = new JObject();
            var serie0 = new JObject(); var serie1 = new JObject();
            var serie2 = new JObject(); var serie3 = new JObject();
            var serie4 = new JObject(); var serie5 = new JObject();
            var serie6 = new JObject(); var serie7 = new JObject();
            var serie8 = new JObject(); var serie9 = new JObject();
            var serie10 = new JObject(); var serie11 = new JObject();
            var serie12 = new JObject(); var serie13 = new JObject();
            var serie14 = new JObject(); var serie15 = new JObject();
            var serie16 = new JObject(); var serie17 = new JObject();
            var serie18 = new JObject(); var serie19 = new JObject();
            var serie20 = new JObject(); var serie21 = new JObject();
            var serie22 = new JObject(); var serie23 = new JObject();

            foreach (var item in list)
            {
                if (item.Hour == 0)
                {
                    if (item.Day == "MON")
                    {
                        serie0.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie0.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie0.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie0.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie0.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie0.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie0.Add("6", item.People);
                    }
                }
                if (item.Hour == 1)
                {
                    if (item.Day == "MON")
                    {
                        serie1.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie1.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie1.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie1.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie1.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie1.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie1.Add("6", item.People);
                    }
                }
                if (item.Hour == 2)
                {
                    if (item.Day == "MON")
                    {
                        serie2.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie2.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie2.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie2.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie2.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie2.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie2.Add("6", item.People);
                    }
                }
                if (item.Hour == 3)
                {
                    if (item.Day == "MON")
                    {
                        serie3.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie3.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie3.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie3.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie3.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie3.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie3.Add("6", item.People);
                    }
                }
                if (item.Hour == 4)
                {
                    if (item.Day == "MON")
                    {
                        serie4.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie4.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie4.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie4.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie4.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie4.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie4.Add("6", item.People);
                    }
                }
                if (item.Hour == 5)
                {
                    if (item.Day == "MON")
                    {
                        serie5.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie5.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie5.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie5.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie5.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie5.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie5.Add("6", item.People);
                    }
                }
                if (item.Hour == 6)
                {
                    if (item.Day == "MON")
                    {
                        serie6.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie6.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie6.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie6.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie6.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie6.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie6.Add("6", item.People);
                    }
                }
                if (item.Hour == 7)
                {
                    if (item.Day == "MON")
                    {
                        serie7.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie7.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie7.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie7.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie7.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie7.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie7.Add("6", item.People);
                    }
                }
                if (item.Hour == 8)
                {
                    if (item.Day == "MON")
                    {
                        serie8.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie8.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie8.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie8.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie8.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie8.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie8.Add("6", item.People);
                    }
                }
                if (item.Hour == 9)
                {
                    if (item.Day == "MON")
                    {
                        serie9.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie9.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie9.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie9.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie9.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie9.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie9.Add("6", item.People);
                    }
                }
                if (item.Hour == 10)
                {
                    if (item.Day == "MON")
                    {
                        serie10.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie10.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie10.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie10.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie10.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie10.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie10.Add("6", item.People);
                    }
                }
                if (item.Hour == 11)
                {
                    if (item.Day == "MON")
                    {
                        serie11.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie11.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie11.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie11.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie11.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie11.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie11.Add("6", item.People);
                    }
                }
                if (item.Hour == 12)
                {
                    if (item.Day == "MON")
                    {
                        serie12.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie12.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie12.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie12.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie12.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie12.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie12.Add("6", item.People);
                    }
                }
                if (item.Hour == 13)
                {
                    if (item.Day == "MON")
                    {
                        serie13.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie13.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie13.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie13.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie13.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie13.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie13.Add("6", item.People);
                    }
                }
                if (item.Hour == 14)
                {
                    if (item.Day == "MON")
                    {
                        serie14.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie14.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie14.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie14.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie14.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie14.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie14.Add("6", item.People);
                    }
                }
                if (item.Hour == 15)
                {
                    if (item.Day == "MON")
                    {
                        serie15.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie15.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie15.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie15.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie15.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie15.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie15.Add("6", item.People);
                    }
                }
                if (item.Hour == 16)
                {
                    if (item.Day == "MON")
                    {
                        serie16.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie16.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie16.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie16.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie16.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie16.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie16.Add("6", item.People);
                    }
                }
                if (item.Hour == 17)
                {
                    if (item.Day == "MON")
                    {
                        serie17.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie17.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie17.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie17.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie17.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie17.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie17.Add("6", item.People);
                    }
                }
                if (item.Hour == 18)
                {
                    if (item.Day == "MON")
                    {
                        serie18.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie18.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie18.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie18.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie18.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie18.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie18.Add("6", item.People);
                    }
                }
                if (item.Hour == 19)
                {
                    if (item.Day == "MON")
                    {
                        serie19.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie19.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie19.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie19.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie19.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie19.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie19.Add("6", item.People);
                    }
                }
                if (item.Hour == 20)
                {
                    if (item.Day == "MON")
                    {
                        serie20.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie20.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie20.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie20.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie20.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie20.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie20.Add("6", item.People);
                    }
                }
                if (item.Hour == 21)
                {
                    if (item.Day == "MON")
                    {
                        serie21.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie21.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie21.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie21.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie21.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie21.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie21.Add("6", item.People);
                    }
                }
                if (item.Hour == 22)
                {
                    if (item.Day == "MON")
                    {
                        serie22.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie22.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie22.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie22.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie22.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie22.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie22.Add("6", item.People);
                    }
                }
                if (item.Hour == 23)
                {
                    if (item.Day == "MON")
                    {
                        serie23.Add("0", item.People);
                    }
                    if (item.Day == "TUE")
                    {
                        serie23.Add("1", item.People);
                    }
                    if (item.Day == "WED")
                    {
                        serie23.Add("2", item.People);
                    }
                    if (item.Day == "THU")
                    {
                        serie23.Add("3", item.People);
                    }
                    if (item.Day == "FRI")
                    {
                        serie23.Add("4", item.People);
                    }
                    if (item.Day == "SAT")
                    {
                        serie23.Add("5", item.People);
                    }
                    if (item.Day == "SUN")
                    {
                        serie23.Add("6", item.People);
                    }
                }
            }
            obj.Add("serie0", serie0); obj.Add("serie1", serie1);
            obj.Add("serie2", serie2); obj.Add("serie3", serie3);
            obj.Add("serie4", serie4); obj.Add("serie5", serie5);
            obj.Add("serie6", serie6); obj.Add("serie7", serie7);
            obj.Add("serie8", serie8); obj.Add("serie9", serie9);
            obj.Add("serie10", serie10); obj.Add("serie11", serie11);
            obj.Add("serie12", serie12); obj.Add("serie13", serie14);
            obj.Add("serie14", serie14); obj.Add("serie15", serie15);
            obj.Add("serie16", serie16); obj.Add("serie17", serie17);
            obj.Add("serie18", serie18); obj.Add("serie19", serie19);
            obj.Add("serie20", serie20); obj.Add("serie21", serie21);
            obj.Add("serie22", serie22); obj.Add("serie23", serie23);
            return obj;
        }


        public JObject WeekDayJson()
        {
            var obj = new JObject();           
                
                    obj.Add("0", "MON");                
                    obj.Add("1", "TUE");
                    obj.Add("2","WED");
                    obj.Add("3", "THU");
                    obj.Add("4", "FRI");                
                    obj.Add("5", "SAT");      
                    obj.Add("6", "SUN");       
            
            return obj;
        }

        public JObject TopPeopleJson(List<TopDTO> list)
        {
            var obj = new JObject();

            var series = TopPeopleChart(list);
            var labels = TopZoneChart(list);

            obj.Add("series", series);
            obj.Add("labels", labels);
            
            return obj;

        }
        public JObject TopPeopleChart(List<TopDTO> list)
        {
            var obj = new JObject();
            var serie0 = new JObject();
            int i = 0;

            foreach (var item in list)
            {
                string x = Convert.ToString(i);
                obj.Add(x, item.People);
                i++;

            }
            serie0.Add("serie0", obj);
            return serie0;
        }

        public JObject TopZoneChart(List<TopDTO> list)
        {
            var obj = new JObject();
            int i = 0;

            foreach (var item in list)
            {
                string x = Convert.ToString(i);
                obj.Add(x, item.ZoneAct);
                i++;

            }
            return obj;
        }


        public JObject MinPeopleJson (List<TopDTO> list)
        {
            var obj = new JObject();

            var series = MinPeopleChart(list);
            var labels = MinZoneChart(list);

            obj.Add("series", series);
            obj.Add("labels", labels);

            return obj;
        }

        public JObject MinPeopleChart(List<TopDTO> list)
        {
            var obj = new JObject();
            var serie0 = new JObject();
            int i = 0;

            foreach (var item in list)
            {
                string x = Convert.ToString(i);
                obj.Add(x, item.People);
                i++;

            }
            serie0.Add("serie0", obj);

            return serie0;
        }

        public JObject MinZoneChart(List<TopDTO> list)
        {
            var obj = new JObject();
            int i = 0;

            foreach (var item in list)
            {
                string x = Convert.ToString(i);
                obj.Add(x, item.ZoneAct);
                i++;

            }
            return obj;
        }

        public JObject TableHomeDayJson(List<TableHomeDayDTO> list)
        {
            var obj = new JObject();
            JArray objArray = new JArray();
            var index = 1;

            foreach (TableHomeDayDTO item in list)
            {
                var objInside = new JObject();
                objInside.Add("id", index++);
                objInside.Add("day", item.Description);
                objInside.Add("hour", item.Hour);
                objInside.Add("people", item.People);
                objArray.Add(objInside);
            }

            obj.Add("td", objArray);

            return obj;
        }

        public JObject TableHomeWeekJson(List<TableHomeWeekDTO> list)
        {
            var obj = new JObject();
            JArray objArray = new JArray();
            var index = 1;

            foreach (TableHomeWeekDTO item in list)
            {
                var objInside = new JObject();
                objInside.Add("id", index++);
                objInside.Add("day", item.Description);
                objInside.Add("people", item.People);
                objArray.Add(objInside);
            }

            obj.Add("td", objArray);

            return obj;
        }

        public JObject TopDayPeopleJson(List<TopDayDTO> list)
        {
            var obj = new JObject();

            var series = TopDayPeopleChart(list);
            var labels = TopDayZoneChart(list);

            obj.Add("series", series);
            obj.Add("labels", labels);

            return obj;
        }

        public JObject TopDayPeopleChart(List<TopDayDTO> list)
        {
            var obj = new JObject();
            var serie0 = new JObject();
            int i = 0;

            foreach (var item in list)
            {
                string x = Convert.ToString(i);
                obj.Add(x, item.People);
                i++;

            }
            serie0.Add("serie0", obj);
            return serie0;
        }

        public JObject TopDayZoneChart(List<TopDayDTO> list)
        {
            var obj = new JObject();
            int i = 0;

            foreach (var item in list)
            {
                string x = Convert.ToString(i);
                obj.Add(x, item.ZoneAct);
                i++;

            }
            return obj;
        }

        public JObject AreaOfInfluenceDayJson(List<AreaOfInfluenceDTO> list)
        {
            throw new NotImplementedException();
        }
    }
}
