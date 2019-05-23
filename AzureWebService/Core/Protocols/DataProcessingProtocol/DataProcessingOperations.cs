﻿using System;
using System.Collections.Generic;
using System.Linq;
using AzureWebService.Core.Protocols.Interfaces;
using AzureWebService.Models;

namespace AzureWebService.Core.Protocols.DataProcessingProtocol
{
    /// <summary>
    /// Flights Data Processing Protocols
    /// </summary>
    public class DataProcessingOperations:IDataProcessingOperations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public DataProcessingModel DataCorrection(List<DataTransmissionModel> models)
        {
            try
            {
                DataProcessingModel procM;

                if (models == null || models.Count <= 0)
                {
                    procM = new DataProcessingModel()
                    {
                        Altitude = 0,
                        Longitude = 0,
                        Latitude = 0,
                        Flight = "Null",
                        Groundspeed = 0,
                        SenderId = "Null",
                        Timestamp = DateTime.Now,
                        Track = 0
                    };

                    return procM;
                }

                var correctedAlt = models.Select(x => x.Altitude).Average();
                var correctedLong = models.Select(x => x.Longitude).Average();
                var correctedLat = models.Select(x => x.Latitude).Average();


                DataTransmissionModel model = models.FirstOrDefault();

                procM = new DataProcessingModel()
                {
                    Altitude = (int?)(correctedAlt) ?? 0,
                    Longitude = correctedLong ?? 0,
                    Latitude = correctedLat ?? 0,
                    Flight = model.Flight ?? "Null",
                    Groundspeed = model.Groundspeed ?? 0,
                    SenderId = model.SenderId ?? "Null",
                    Timestamp = model.Timestamp ?? DateTime.Now,
                    Track = model.Track ?? 0
                };

                return procM;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

      
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public double MeanCalculator(List<double> numbers)
        {
            double sum=0;

            foreach (var variable in numbers)
            {
                sum += variable;
            }

            var mean = sum / numbers.Count + 1;

            return mean;
        }

        public DataProcessingModel ProcessDataByMean(string flight, DateTime timeStamp)
        {
           return DataCorrection(DataBaseConnection.GetDataByFlightIdAndTimeStamp(flight, timeStamp));
        }
    }
}
