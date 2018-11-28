using System;

namespace BlogPortfolioAPI.Models {
    public class RSSFeed {
        public int Id { get; set; }
     
        public DateTime Date { get; set; } = DateTime.Now;

        public string Name { get; set; } 

        public bool IsActive { get; set; } = true;

        public string Email { get; set; }

    }
}
