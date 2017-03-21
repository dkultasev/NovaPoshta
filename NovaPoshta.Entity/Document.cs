using System;

namespace NovaPoshta.Core
{
    public class Document
    {
        public Guid? Ref { get; set; }

        public DateTime? DateTime
        { get; set; }

        public string DateTimeString
        {
            get { return this.DateTime != null ? this.DateTime.Value.ToString("dd.MM.yyyy") : ""; }
            set { this.DateTime = (value.Equals("") ? (DateTime?)null : System.DateTime.Parse(value)); }
        }


        public DateTime? PreferredDeliveryDate { get; set; }

        public string PreferredDeliveryDateString
        {
            get { return this.PreferredDeliveryDate != null ? this.PreferredDeliveryDate.Value.ToString("yyyy-MM-dd hh:mm:ss") : ""; }
            set { this.PreferredDeliveryDate = (value.Equals("") ? (DateTime?)null : System.DateTime.Parse(value)); }
        }
        public double Weight { get; set; }
        public Nullable<short> SeatsAmount { get; set; }
        public string IntDocNumber { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<System.Guid> CitySender { get; set; }
        public Nullable<System.Guid> CityRecipient { get; set; }
        public Nullable<System.Guid> State { get; set; }
        public Nullable<System.Guid> SenderAddress { get; set; }
        public Nullable<System.Guid> RecipientAddress { get; set; }
        public Nullable<decimal> CostOnSite { get; set; }
        public string PayerType { get; set; }
        public string PaymentMethod { get; set; }
        public Nullable<decimal> AfterpaymentOnGoodsCost { get; set; }
        public string CargoType { get; set; }
        public string PackingNumber { get; set; }
        public string AdditionalInformation { get; set; }
        public string Number { get; set; }
        public string Posted { get; set; }
        public string DeletionMark { get; set; }
        public string Route { get; set; }
        public string EWNumber { get; set; }
        public string Description { get; set; }
        public string SaturdayDelivery { get; set; }
        public string ExpressWaybill { get; set; }
        public string CarCall { get; set; }
        public string ServiceType { get; set; }
        public string DeliveryDateFrom { get; set; }
        public string Vip { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public string LastModificationDateString
        {
            get { return this.LastModificationDate != null ? this.LastModificationDate.Value.ToString("yyyy-MM-dd hh:mm:ss") : ""; }
            set { this.LastModificationDate = (value.Equals("") ? (DateTime?)null : System.DateTime.Parse(value)); }
        }
        public DateTime? ReceiptDate { get; set; }
        public string ReceiptDateString
        {
            get { return this.ReceiptDate != null ? this.ReceiptDate.Value.ToString("yyyy-MM-dd hh:mm:ss") : ""; }
            set { this.ReceiptDate = (value.Equals("") ? (DateTime?)null : System.DateTime.Parse(value)); }
        }
        public string LoyaltyCard { get; set; }
        public string Sender { get; set; }
        public string ContactSender { get; set; }
        public string SendersPhone { get; set; }
        public string Recipient { get; set; }
        public string ContactRecipient { get; set; }
        public string RecipientsPhone { get; set; }
        public string Redelivery { get; set; }
        public string SaturdayDeliveryString { get; set; }
        public string Note { get; set; }
        public string ThirdPerson { get; set; }
        public string Forwarding { get; set; }
        public string NumberOfFloorsLifting { get; set; }
        public string StatementOfAcceptanceTransferCargoID { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public string RecipientFullName { get; set; }
        public string RecipientPost { get; set; }
        public DateTime? RecipientDateTime { get; set; }
        public string RecipientDateTimeString
        {
            get { return this.RecipientDateTime != null ? this.RecipientDateTime.Value.ToString("yyyy-MM-dd hh:mm:ss") : ""; }
            set { this.RecipientDateTime = (value.Equals("") ? (DateTime?)null : System.DateTime.Parse(value)); }
        }
        public string RejectionReason { get; set; }
        public string CitySenderDescription { get; set; }
        public string CityRecipientDescription { get; set; }
        public string SenderDescription { get; set; }
        public string RecipientDescription { get; set; }
        public string RecipientContactPhone { get; set; }
        public string RecipientContactPerson { get; set; }
        public string SenderAddressDescription { get; set; }
        public string RecipientAddressDescription { get; set; }
        public int? Printed { get; set; }
        public int? ChangedDataEW { get; set; }
        public int? Fulfillment { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public string EstimatedDeliveryDateString
        {
            get { return this.EstimatedDeliveryDate != null ? this.EstimatedDeliveryDate.Value.ToString("yyyy-MM-dd hh:mm:ss") : ""; }
            set { this.EstimatedDeliveryDate = (value.Equals("") ? (DateTime?)null : System.DateTime.Parse(value)); }
        }
        public DateTime? DateLastUpdatedStatus { get; set; }
        public string DateLastUpdatedStatusString
        {
            get { return this.DateLastUpdatedStatus != null ? this.DateLastUpdatedStatus.Value.ToString("yyyy-MM-dd hh:mm:ss") : ""; }
            set { this.DateLastUpdatedStatus = (value.Equals("") ? (DateTime?)null : System.DateTime.Parse(value)); }
        }
        public DateTime? CreateTime { get; set; }
        public string CreateTimeString
        {
            get { return CreateTime?.ToString("yyyy-MM-dd hh:mm:ss") ?? ""; }
            set { this.CreateTime = (value.Equals("") ? (DateTime?)null : System.DateTime.Parse(value)); }
        }
        public string ScanSheetNumber { get; set; }
        public string InfoRegClientBarcodes { get; set; }
        public int? StatePayId { get; set; }
        public string StatePayName { get; set; }
        public string BackwardDeliveryCargoType { get; set; }
        //public virtual DocumentStatus DocumentStatus { get; set; }
        public double VolumeGeneral { get; set; }
        }
}
