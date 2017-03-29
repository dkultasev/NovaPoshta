using System;

namespace NovaPoshta.Core
{
    public class Document
    {
        public Guid? Ref { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? PreferredDeliveryDate { get; set; }
        public double Weight { get; set; }
        public short? SeatsAmount { get; set; }
        public string IntDocNumber { get; set; }
        public decimal? Cost { get; set; }
        public Guid? CitySender { get; set; }
        public Guid? CityRecipient { get; set; }
        public Guid? State { get; set; }
        public Guid? SenderAddress { get; set; }
        public Guid? RecipientAddress { get; set; }
        public decimal? CostOnSite { get; set; }
        public string PayerType { get; set; }
        public string PaymentMethod { get; set; }
        public decimal? AfterpaymentOnGoodsCost { get; set; }
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
        public DateTime? ReceiptDate { get; set; }
        public string LoyaltyCard { get; set; }
        public Guid Sender { get; set; }
        public Guid? ContactSender { get; set; }
        public string SendersPhone { get; set; }
        public Guid Recipient { get; set; }
        public Guid ContactRecipient { get; set; }
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
        public DateTime? DateLastUpdatedStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public string ScanSheetNumber { get; set; }
        public string InfoRegClientBarcodes { get; set; }
        public int? StatePayId { get; set; }
        public string StatePayName { get; set; }
        public string BackwardDeliveryCargoType { get; set; }
        public double VolumeGeneral { get; set; }
        }
}
