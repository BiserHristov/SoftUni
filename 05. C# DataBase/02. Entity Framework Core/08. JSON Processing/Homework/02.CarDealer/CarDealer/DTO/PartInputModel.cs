﻿using Newtonsoft.Json;

namespace CarDealer.DTO
{
    public class PartInputModel
    {
        [JsonProperty("")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("supplierId")]
        public int SupplierId { get; set; }
    }
}

