﻿namespace ShopListApp.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public ICollection<LobbyProduct>? LobbyProducts { get; set; }
    }
}