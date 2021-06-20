using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DairyManagement.ViewModels.Accounts
{
    public class AccountsVM
    {
        public AccountsVM()
        {
            ConsiderOldStock = true;
            AccountDateTime = DateTime.Now;
        }
        public int AccountId { get; set; }
        //Will be autopopulate
        [Display(Name = "જૂનો સ્ટોક")]
        [Required(ErrorMessage = "Old stock is missing")]
        public decimal OldStock { get; set; }
        [Display(Name = "આજનું દૂધ")]
        [Required(ErrorMessage = "Please enter આજનું દૂધ")]
        public decimal TodayMilk { get; set; }
        [Display(Name = "કુલ ખરીદી")]
        [Required(ErrorMessage = "Total Purchase is not calculated")]
        public decimal TotalPurchase { get; set; }
        //Will be autopopulate
        //Total vaara of bhaiyas
        [Display(Name = "કુલ વેચાણ")]
        [Required(ErrorMessage = "Please enter કુલ વેચાણ")]
        public decimal TotalSell { get; set; }
        //Total Purchase - Total Sell
        [Display(Name = "ઉપલબ્ધ સ્ટોક")]
        [Required(ErrorMessage = "ઉપલબ્ધ સ્ટોક is not calculated")]
        public decimal AvailableStock { get; set; }
        [Display(Name = "વાસ્તવિક સ્ટોક")]
        [Required(ErrorMessage = "Please enter વાસ્તવિક સ્ટોક")]
        //This will be tomorrow's old stock
        public decimal RealStock { get; set; }
        [Display(Name = "સ્ટોક તફાવત")]
        //RealStock - Available stock
        public decimal StockDifference { get; set; }
        public List<AccountsVMSP> SPs { get; set; }
        public List<SelectListItem> VendorList { get; set; }
        [Display(Name = "વેપારી")]
        public int VendorId { get; set; }

        //Notes
        public string OldStockNote { get; set; }
        public string TodayMilkNote { get; set; }
        public string TotalPurchaseNote { get; set; }
        public string TotalSellNote { get; set; }
        public string AvailableStockNote { get; set; }
        public string RealStockNote { get; set; }
        public string StockDifferenceNote { get; set; }
        [Display(Name = "આવતીકાલનો જૂનો સ્ટોક")]
        public Boolean ConsiderOldStock { get; set; }
        [Display(Name = "Account Date")]
        [Required(ErrorMessage = "Please enter Date")]
        public DateTime AccountDateTime { get; set; }
    }

    public class AccountsVMSP
    {
        [Required(ErrorMessage = "Please enter એસ પી")]
        [Display(Name = "એસ પી")]
        public decimal SPValue { get; set; }
        [Display(Name = "એસપી વિગતો")]
        public string SPNote { get; set; }
    }

    public class AccountsVMs
    {
        public int AccountId { get; set; }
        [Display(Name = "જૂનો સ્ટોક")]
        public Nullable<decimal> OldStock { get; set; }
        [Display(Name = "આજનું દૂધ")]
        public Nullable<decimal> TodayMilk { get; set; }
        [Display(Name = "કુલ ખરીદી")]
        public Nullable<decimal> TotalPurchase { get; set; }
        [Display(Name = "કુલ વેચાણ")]
        public Nullable<decimal> TotalSell { get; set; }
        [Display(Name = "ઉપલબ્ધ સ્ટોક")]
        public Nullable<decimal> AvailableStock { get; set; }
        [Display(Name = "વાસ્તવિક સ્ટોક")]
        public Nullable<decimal> RealStock { get; set; }
        [Display(Name = "સ્ટોક તફાવત")]
        public Nullable<decimal> StockDifference { get; set; }
        [Display(Name = "વેપારી નામ")]
        public string VendorName { get; set; }
        [Display(Name = "એકાઉન્ટ તારીખ અને સમય")]
        public string AccountDateTime { get; set; }
    }
}