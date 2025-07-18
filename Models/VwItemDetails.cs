﻿using LapShopv2.Models;
using LapShopv2.Models.IContract;
namespace LapShopv2.Models
{
    public class VmItemDetails : IWmItemDetails
    {
        public VmItemDetails()
        {
            Item = new VwItem();
            lstItemImages = new List<TbItemImage>();
            lstRecommendedItems = new List<VwItem>();
        }
        public VwItem Item { get; set; }
        public List<TbItemImage> lstItemImages { get; set; }
        public List<VwItem> lstRecommendedItems { get; set; }
    }
}

