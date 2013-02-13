//
// Constants.cs: StoreKit contant values
//
using System;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;
using MonoMac.AppKit;

namespace MonoMac.StoreKit {

	
	public static class Constants {

		public static readonly NSString SKErrorDomain = new NSString("SKErrorDomain");		

	}

	public enum StoreKitErrors {
		SKErrorUnknown,
		SKErrorClientInvalid,
		SKErrorPaymentCancelled,
		SKErrorPaymentInvalid,
		SKErrorPaymentNotAllowed
	}	

	public enum SKPaymentTransactionStates {
		SKPaymentTransactionStatePurchasing,
		SKPaymentTransactionStatePurchased,
		SKPaymentTransactionStateFailed,
		SKPaymentTransactionStateRestored
	}

	public enum SKDownloadStates {
		SKDownloadStateWaiting,
		SKDownloadStateActive,
		SKDownloadStatePaused,
		SKDownloadStateFinished,
		SKDownloadStateFailed,
		SKDownloadStateCancelled		
	}

}