using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp5
{
    public class order
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public int cientId { get; set; }
        public int userId { get; set; }
        public int quantity { get; set; }
        public int totalPrice { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public virtual IEnumerable<Client> Clients { get; set; }




    }
}
