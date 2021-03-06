﻿using FlightRadarWebService.Models.ProcessedModels;
using FlightRadarWebService.Models.ProcessingModels;
using FlightRadarWebService.Models.TransmissionModels;
using NUnit.Framework;
using System.Collections.Generic;

namespace FlightRadarWebService.Test.DataContainers.Test
{
    /// <summary>
    /// Test Data Containers (Dictionaries)
    /// </summary>
    internal class DataContainersTest
    {
        [SetUp]
        public void Setup()
        {
            Core.DataContainers.GetInstance().DATA_PROCESSED_CONTAINER = new Dictionary<string, DataProcessedModel>();
            Core.DataContainers.GetInstance().DATA_PROCESSING_CONTAINER = new Dictionary<string, DataProcessingModel>();
            Core.DataContainers.GetInstance().DATA_RECEIVED_CONTAINER = new Dictionary<string, DataTransmissionModel>();
        }

        [Test]
        public void TestInitializationOfDataContainersCollections()
        {
            Assert.IsNotNull(Core.DataContainers.GetInstance().DATA_PROCESSED_CONTAINER);
            Assert.IsNotNull(Core.DataContainers.GetInstance().DATA_PROCESSING_CONTAINER);
            Assert.IsNotNull(Core.DataContainers.GetInstance().DATA_RECEIVED_CONTAINER);
        }
    }
}