﻿using System;
namespace ContactListApp.Shared
{
	public class Address
	{
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}

