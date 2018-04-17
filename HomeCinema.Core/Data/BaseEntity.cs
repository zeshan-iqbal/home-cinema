using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Core.Data
{
    public abstract class BaseEntity : IEntity, IAuditable
    {
        public int Id { get; set; }

        [JsonIgnore]
        public string CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        [JsonIgnore]
        public string LastModifiedBy { get; set; }

        [JsonIgnore]
        public DateTime? LastModifiedDate { get; set; }

        [JsonIgnore]
        public bool Deleted { get; set; }

        // this is not the best way to check for a new entity. For some tables where primary key starts from 0 instead of 1 that will be a problem
        // better avoid using this property until better implementation is found.
        [JsonIgnore]
        public bool IsNew
        {
            get { return Id == 0; }
        }
    }
}
