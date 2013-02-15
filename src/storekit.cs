//
// storekit.cs: Definitions for the StoreKit Framework
//
using System;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;
using MonoMac.AppKit;

namespace MonoMac.StoreKit {

	[BaseType (typeof (SKPayment))]
	interface SKMutablePayment {

		[Export("productIdentifier")]
		string ProductIdentifier { get; set; }

		[Export("quantity")]
		int Quantity { get; set; }

		[Export("requestData")]
		NSData RequestData { get; set; }

	}	

	[BaseType (typeof (NSObject))]
	interface SKPayment {

		[Export("productIdentifier")]
		string ProductIdentifier {get;}

		[Export("quantity")]
		int Quantity {get;}

		[Export("requestData")]
		NSData RequestData { get; }

		[Export("paymentWithProduct:")]
		[Static]
		SKPayment CreatePayment( SKProduct product );

	}

	[BaseType (typeof (NSObject))]
	interface SKPaymentQueue {

		[Export("canMakePayments")]
		[Static]
		bool CanMakePayments { get; }

		[Export("defaultQueue")]
		[Static]
		SKPaymentQueue DefaultQueue { get;}

		[Export("transactions")]
		SKPaymentTransaction Transactions { get; }

		[Export("addPayment:")]
		void AddPayment( SKPayment payment );

		[Export("addTransactionObserver:")]
		void AddTransactionObserver( NSObject observer );

		[Export("cancelDownloads:")]
		void CancelDownloads( SKDownload[] downloads );

		[Export("finishTransaction:")]
		void FinishTransaction( SKPaymentTransaction transaction );

		[Export("pauseDownloads:")]
		void PauseDownloads( SKDownload[] downloads );

		[Export("removeTransactionObserver:")]
		void RemoveTransactionObserver( NSObject observer );

		[Export("restoreCompletedTransactions:")]
		void RestoreCompletedTransactions();

	}

	[BaseType (typeof (NSObject))]
	interface SKPaymentTransaction {

		[Export("error")]
		NSError Error { get; }

		[Export("payment")]
		SKPayment Payment {get;}

		[Export("transactionState")]
		SKPaymentTransactionStates TransactionState {get;}

		[Export("transactionIdentifier")]
		string TransactionIdentifier {get;}

		[Export("transactionReceipt")]
		NSData TransactionReceipt { get; }

		[Export("transactionDate")]
		NSDate TransactionDate { get; }

		[Export("downloads")]
		SKDownload[] Downloads { get; }

		[Export("originalTransaction")]
		SKPaymentTransaction OriginalTransaction { get; }

	}

	[BaseType (typeof (NSObject))]
	interface SKProduct {

		[Export("downloadable")]
		bool Downloadable { [Bind("isDownloadable")] get; }

		[Export("localizedDescription")]
		string LocalizedDescription {get;}

		[Export("localizedTitle")]
		string LocalizedTitle { get; }

		[Export("price")]
		NSDecimalNumber Price {get;}

		[Export("priceLocale")]
		NSLocale PriceLocale {get;}

		[Export("productIdentifier")]
		string ProductIdentifier {get;}

	}

	[BaseType (typeof (SKRequest))]	
	interface SKProductsRequest {

		[Export("initWithProductIdentifiers:")]
		IntPtr Constructor( NSSet productIdentifiers );

	}

	[BaseType (typeof (SKRequest))]	
	interface SKProductsResponse {

		[Export("invalidProductIdentifiers")]
		string[] InvalidProductIndentifiers { get; }

		[Export("products")]
		SKProduct[] Products {get;}

	}

	[BaseType (typeof (NSObject))]
	interface SKRequest {

		[Export("delegate")]
		NSObject Delegate { get; set; }

		[Export("start")]
		void Start();

		[Export("cancel")]
		void Cancel();

	}

	[BaseType (typeof (NSObject))]
	interface SKDownload {

		[Export("contentIdentifier")]
		string ContentIdentifier {get;}

		[Export("contentLength")]
		long ContentLength {get;}

		[Export("contentURL")]
		NSUrl ContentURL {get;}		

		[Export("contentVersion")]
		string ContentVersion {get;}

		[Export("downloadState")]
		SKDownloadStates DownloadState {get;}

		[Export("error")]
		NSError Error {get;}

		[Export("progress")]
		float Progress {get;}

		[Export("timeRemaining")]
		double TimeRemaining {get;}

		[Export("transaction")]
		SKPaymentTransaction Transaction {get;}

	}


}