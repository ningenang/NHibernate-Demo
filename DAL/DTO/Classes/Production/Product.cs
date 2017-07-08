using System;
using System.Collections.Generic;

namespace DAL.DTO.Classes.Production
{

	public class Product : Entity
    {
        private IList<ProductReview> _reviews = new List<ProductReview>();
        private IList<ProductCostHistory> _costHistory = new List<ProductCostHistory>();
        private IList<TransactionHistory> _transactionHistory = new List<TransactionHistory>();

        public virtual string Name { get; set; }

        public virtual string ProductNumber { get; set; }

        public virtual bool Make { get; set; }

        public virtual bool FinishedGoods { get; set; }

        public virtual string Color { get; set; }

        public virtual short SafetyStockLevel { get; set; }

        public virtual short ReorderPoint { get; set; }

        public virtual decimal StandardCost { get; set; }

        public virtual decimal ListPrice { get; set; }

        public virtual string Size { get; set; }

        public virtual double Weight { get; set; }

        public virtual int DaysToManufacture { get; set; }

        public virtual string ProductLine { get; set; }

        public virtual string Class { get; set; }

        public virtual string Style { get; set; }

        public virtual DateTime SellStartDate { get; set; }

        public virtual DateTime? SellEndDate { get; set; }

        public virtual DateTime DiscontinuedDate { get; set; }

        public virtual ProductModel ProductModel { get; set; }

        public virtual ProductSubcategory ProductSubcategory { get; set; }

		public virtual IEnumerable<ProductReview> Reviews => _reviews;

		public virtual IEnumerable<ProductCostHistory> CostHistory => _costHistory;

		public virtual IEnumerable<TransactionHistory> TransactionHistory => _transactionHistory;
	}
}
