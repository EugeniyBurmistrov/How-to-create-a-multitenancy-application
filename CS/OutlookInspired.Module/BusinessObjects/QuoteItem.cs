﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Persistent.Base;


namespace OutlookInspired.Module.BusinessObjects{
    [ImageName("Shopping_Sales")]
    public class QuoteItem :OutlookInspiredBaseObject{
        public virtual Quote Quote { get; set; }
        public virtual Product Product { get; set; }
        [Browsable(false)]
        public virtual Guid? ProductId { get; set; }
        public  virtual int ProductUnits { get; set; }
        [DataType(DataType.Currency)][Column(TypeName = "decimal(18, 2)")]
        public  virtual decimal ProductPrice { get; set; }
        [DataType(DataType.Currency)][Column(TypeName = "decimal(18, 2)")]
        public  virtual decimal Discount { get; set; }
        [DataType(DataType.Currency)][Column(TypeName = "decimal(18, 2)")]
        public  virtual decimal Total { get; set; }
    }
}