﻿using Microsoft.AspNetCore.Http;

namespace OnlineShop.Service.ViewModels
{
    public class CustomerAnnouncementViewModel
    {
        public long Id { get; set; }
        public string Category { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public string ImagePath { get; set; } = String.Empty;
        public IFormFile Image { get; set; }
        public string Description { get; set; } = String.Empty;
        public double Price { get; set; }
        public string PhoneNumber { get; set; } = String.Empty;
    }
}
