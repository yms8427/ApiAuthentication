﻿namespace BilgeAdam.SecuredApp.Services.Contracts
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public short? Stock { get; set; }
    }
}