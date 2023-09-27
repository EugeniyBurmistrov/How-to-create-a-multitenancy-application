﻿using OutlookInspired.Module.BusinessObjects;

namespace OutlookInspired.Win.UserControls
{
    public partial class OrderDetailView : ColumnViewUserControl
    {
        public OrderDetailView()
        {
            InitializeComponent();
            labelControl1.Text = @"RECORDS: 0";
        }

        protected override void OnDataSourceOfFilterChanged()
        {
            base.OnDataSourceOfFilterChanged();
            labelControl1.Text = $@"RECORDS: {ColumnView.DataRowCount}";
        }


        public override Type ObjectType => typeof(Order);
    }
}