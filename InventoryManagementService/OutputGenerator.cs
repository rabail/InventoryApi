using System;
using System.Collections.Generic;

namespace InventoryManagementService
{
    public class OutputGenerator
    {
        private Dictionary<int, Descriptor> mapper;
        InventoryModel model;
        private List<InventoryDaysModel> output;
        public OutputGenerator(Dictionary<int,Descriptor> map, InventoryModel schedule)
        {
            mapper = map;
            model = schedule;
            output = new List<InventoryDaysModel>();
            GenerateOutput();
        }

        private void GenerateOutput()
        {
            var stage = model.StartDate;

            while(stage<=model.EndDate)
            {
                int count = 1;
                var day = (int)stage.DayOfWeek;

                InventoryDaysModel temp = new InventoryDaysModel { StartDate = stage };

                if (mapper.ContainsKey(day))
                {
                    temp.EndDate = stage.AddDays(mapper[day].Count - 1) > model.EndDate ? model.EndDate : stage.AddDays(mapper[day].Count - 1);
                }
                else
                {
                    while (!mapper.ContainsKey((int)temp.StartDate.AddDays(-count).DayOfWeek))
                    {
                        count += 1;
                    }

                    stage = temp.StartDate.AddDays(-count);
                    day = (int)stage.DayOfWeek;
                }
                temp.AllowedArrivalDays = mapper[day].closedToArrival;
                temp.AllowedDepartureDays = mapper[day].closedToDepart;

                output.Add(temp);

                stage = stage.AddDays(mapper[day].Count);           
            }
        }

        public List<InventoryDaysModel> GetOutput()
        {
            return output;
        }
    }
}
