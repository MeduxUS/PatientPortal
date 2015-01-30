﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace HealthPortal.Models
{
    public class PhyAllergyModel:IPhyAllergyRepository
    {
        MongoServer _server;
        MongoDatabase _database;
        MongoCollection<Allergy> _Allergy;

        public PhyAllergyModel()
            : this("")
        {

        }
        public PhyAllergyModel(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = "mongodb://Amit:pooja123@ds027829.mongolab.com:27829/healthcare";
            }
            _server = MongoServer.Create(connection);
            _database = _server.GetDatabase("healthcare", SafeMode.True);
            _Allergy = _database.GetCollection<Allergy>("Allergies");

        }

        public IEnumerable<Allergy> GebyUserId(string PatientId)
        {
            IMongoQuery query = Query.EQ("PatientId", PatientId);
            return _Allergy.Find(query).AsEnumerable();
        }


        public IEnumerable<Allergy> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}