﻿using _01_framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Invertory.Application.Contracts.Inventory
{
    public class Reduce
    {
        [Range(1, 1000000, ErrorMessage = ValidationMessages.IsRequired)]
        public long InventoryId { get; set; }

        public long ProductId { get; set; }
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long Count { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Describtion { get; set; }
        public long OrderId { get; set; }

        public Reduce()
        {
            
        }
        public Reduce(long productId,long count,string describtion,long orderid)
        {
            ProductId = productId;
            Count = count;
            Describtion = describtion;
            OrderId = orderid;
        }
    }

}