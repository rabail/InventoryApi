using System;
using System.Collections.Generic;
using System.Linq;
using static InventoryManagementService.InventoryModel;

namespace InventoryManagementService
{
    public class Descriptor
    {
        public int Count { get; set; }
        public bool closedToArrival { get; set; }
        public bool closedToDepart { get; set; }
    }

    public class Mapper : IMapper
    {
        private InventoryModel _schedule;
        private Dictionary<int, Descriptor> _mapper;
        public Mapper(InventoryModel instance)
        {
            this._schedule = instance;
            _mapper = new Dictionary<int, Descriptor>();
            Build();
        }

        public Dictionary<int,Descriptor> GetMapper()
        {
            return _mapper;
        }

        private void Build()
        {
            var arrivalList = new List<bool>{
                _schedule.AllowedArrivalDays.Sunday,
                _schedule.AllowedArrivalDays.Monday,
                _schedule.AllowedArrivalDays.Tuesday,
                _schedule.AllowedArrivalDays.Wednesday,
                _schedule.AllowedArrivalDays.Thursday,
                _schedule.AllowedArrivalDays.Friday,
                _schedule.AllowedArrivalDays.Saturday
            };

            var departureList = new List<bool>{
                _schedule.AllowedDepartureDays.Sunday,
                _schedule.AllowedDepartureDays.Monday,
                _schedule.AllowedDepartureDays.Tuesday,
                _schedule.AllowedDepartureDays.Wednesday,
                _schedule.AllowedDepartureDays.Thursday,
                _schedule.AllowedDepartureDays.Friday,
                _schedule.AllowedDepartureDays.Saturday,
            };

            Map(arrivalList, departureList);

            AdjustCircular();
        }

        private void Map(List<bool> arrivalList, List<bool> departureList)
        {
            int stage = 0;
            bool stageArrival = arrivalList[0];
            bool stageDeparture = departureList[0];
            int stageCount = 1;
            int inc = 1;

            while (inc <= arrivalList.Count)
            {
                if (inc == arrivalList.Count)
                {
                    _mapper.Add(stage, new Descriptor { Count = stageCount, closedToArrival = !arrivalList[inc - 1], closedToDepart = !departureList[inc - 1] });
                    break;
                }
                if (stageArrival == arrivalList[inc] && stageDeparture == departureList[inc])
                {
                    stageCount += 1;
                    inc += 1;
                    continue;
                }
                else
                {
                    _mapper.Add(stage, new Descriptor { Count = stageCount, closedToArrival = !arrivalList[inc - 1], closedToDepart = !departureList[inc - 1] });

                    //reset counter
                    stage += stageCount;
                    stageCount = 1;
                    stageArrival = arrivalList[inc];
                    stageDeparture = departureList[inc];
                    inc += stageCount;
                }
            }
        }

        private void AdjustCircular()
        {
            if (_mapper.Count > 1)
            {
                var beginner = _mapper[_mapper.Keys.First()];
                var end = _mapper[_mapper.Keys.Last()];

                if (beginner.closedToArrival == end.closedToArrival && beginner.closedToDepart == end.closedToDepart)
                {
                    end.Count = beginner.Count + end.Count;
                    _mapper.Remove(_mapper.Keys.First());
                }
            }
        }
    }
}
