namespace NovaPoshta.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Ref = c.Guid(nullable: false),
                        Description = c.String(),
                        DescriptionRu = c.String(),
                        Delivery1 = c.Int(nullable: false),
                        Delivery2 = c.Int(nullable: false),
                        Delivery3 = c.Int(nullable: false),
                        Delivery4 = c.Int(nullable: false),
                        Delivery5 = c.Int(nullable: false),
                        Delivery6 = c.Int(nullable: false),
                        Delivery7 = c.Int(nullable: false),
                        Area = c.Guid(nullable: false),
                        CityId = c.Int(),
                    })
                .PrimaryKey(t => t.Ref);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Ref = c.Guid(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        PreferredDeliveryDate = c.DateTime(),
                        Weight = c.Double(nullable: false),
                        SeatsAmount = c.Short(),
                        IntDocNumber = c.String(),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Fk_CitySenderGuid = c.Guid(),
                        Fk_CityRecipientGuid = c.Guid(),
                        State = c.Guid(),
                        SenderAddress = c.Guid(),
                        RecipientAddress = c.Guid(),
                        CostOnSite = c.Decimal(precision: 18, scale: 2),
                        PayerType = c.String(),
                        PaymentMethod = c.String(),
                        AfterpaymentOnGoodsCost = c.Decimal(precision: 18, scale: 2),
                        CargoType = c.String(),
                        PackingNumber = c.String(),
                        AdditionalInformation = c.String(),
                        Number = c.String(),
                        Posted = c.String(),
                        DeletionMark = c.String(),
                        Route = c.String(),
                        EWNumber = c.String(),
                        Description = c.String(),
                        SaturdayDelivery = c.String(),
                        ExpressWaybill = c.String(),
                        CarCall = c.String(),
                        ServiceType = c.String(),
                        DeliveryDateFrom = c.String(),
                        Vip = c.String(),
                        LastModificationDate = c.DateTime(),
                        ReceiptDate = c.DateTime(),
                        LoyaltyCard = c.String(),
                        Sender = c.Guid(nullable: false),
                        ContactSender = c.Guid(),
                        SendersPhone = c.String(),
                        Recipient = c.Guid(nullable: false),
                        ContactRecipient = c.Guid(nullable: false),
                        RecipientsPhone = c.String(),
                        Redelivery = c.String(),
                        SaturdayDeliveryString = c.String(),
                        Note = c.String(),
                        ThirdPerson = c.String(),
                        Forwarding = c.String(),
                        NumberOfFloorsLifting = c.String(),
                        StatementOfAcceptanceTransferCargoID = c.String(),
                        StateId = c.Int(),
                        StateName = c.String(),
                        RecipientFullName = c.String(),
                        RecipientPost = c.String(),
                        RecipientDateTime = c.DateTime(),
                        RejectionReason = c.String(),
                        CitySenderDescription = c.String(),
                        CityRecipientDescription = c.String(),
                        SenderDescription = c.String(),
                        RecipientDescription = c.String(),
                        RecipientContactPhone = c.String(),
                        RecipientContactPerson = c.String(),
                        SenderAddressDescription = c.String(),
                        RecipientAddressDescription = c.String(),
                        Printed = c.Int(),
                        ChangedDataEW = c.Int(),
                        Fulfillment = c.Int(),
                        EstimatedDeliveryDate = c.DateTime(),
                        DateLastUpdatedStatus = c.DateTime(),
                        CreateTime = c.DateTime(),
                        ScanSheetNumber = c.String(),
                        InfoRegClientBarcodes = c.String(),
                        StatePayId = c.Int(),
                        StatePayName = c.String(),
                        BackwardDeliveryCargoType = c.String(),
                        VolumeGeneral = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Ref)
                .ForeignKey("dbo.Cities", t => t.Fk_CityRecipientGuid)
                .ForeignKey("dbo.Cities", t => t.Fk_CitySenderGuid)
                .Index(t => t.Fk_CitySenderGuid)
                .Index(t => t.Fk_CityRecipientGuid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "Fk_CitySenderGuid", "dbo.Cities");
            DropForeignKey("dbo.Documents", "Fk_CityRecipientGuid", "dbo.Cities");
            DropIndex("dbo.Documents", new[] { "Fk_CityRecipientGuid" });
            DropIndex("dbo.Documents", new[] { "Fk_CitySenderGuid" });
            DropTable("dbo.Documents");
            DropTable("dbo.Cities");
        }
    }
}
