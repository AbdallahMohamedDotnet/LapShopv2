﻿namespace LapShopv2.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            lstItems = new List<ShoppingCartItem>();
        }

        public List<ShoppingCartItem> lstItems { get; set; }
        public decimal Total { get; set; }
        public string PromoCode { get; set; }
    }
}
