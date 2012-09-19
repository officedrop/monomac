//
// growl.cs: Definitions for the Growl Framework
//
using System;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;
using MonoMac.AppKit;

namespace MonoMac.Sparkle {
	
	[BaseType (typeof (NSObject))]
	interface SUAppcast {
		[Export ("fetchAppcastFromURL:")]
		void FetchAppcastFromURL (NSUrl url);

		[Export ("setDelegate:")]
		void SetDelegate ();

		[Export ("setUserAgentString:")]
		void SetUserAgentString (string userAgentString);

		[Export ("items")]
		NSArray Items ();

	}

	[BaseType (typeof (NSObject))]
	interface SUUpdater {
		[Static]
		[Export ("sharedUpdater")]
		SUUpdater SharedUpdater ();

		[Static]
		[Export ("updaterForBundle:")]
		SUUpdater UpdaterForBundle (NSBundle bundle);

		[Export ("hostBundle")]
		NSBundle HostBundle ();

		[Export ("setDelegate:")]
		void SetDelegate (NSObject delegateHandler);

		[Export ("checkForUpdates:")]
		void CheckForUpdates ();

		[Export ("checkForUpdatesInBackground")]
		void CheckForUpdatesInBackground ();

		[Export ("lastUpdateCheckDate")]
		NSDate LastUpdateCheckDate ();

		[Export ("checkForUpdateInformation")]
		void CheckForUpdateInformation ();

		[Export ("resetUpdateCycle")]
		void ResetUpdateCycle ();

		[Export ("updateInProgress")]
		bool UpdateInProgress ();

		//Detected properties
		[Export ("automaticallyChecksForUpdates")]
		bool AutomaticallyChecksForUpdates { get; set; }

		[Export ("updateCheckInterval")]
		double UpdateCheckInterval { get; set; }

		[Export ("feedURL")]
		NSUrl FeedURL { get; set; }

		[Export ("sendsSystemProfile")]
		bool SendsSystemProfile { get; set; }

		[Export ("automaticallyDownloadsUpdates")]
		bool AutomaticallyDownloadsUpdates { get; set; }

	}

	[BaseType (typeof (NSObject))]
	interface SUAppcastItem {
		[Export ("dict")]
		NSDictionary Dict ();

		[Export ("title")]
		string Title ();

		[Export ("versionString")]
		string VersionString ();

		[Export ("displayVersionString")]
		string DisplayVersionString ();

		[Export ("date")]
		NSDate Date ();

		[Export ("itemDescription")]
		string ItemDescription ();

		[Export ("releaseNotesURL")]
		NSUrl ReleaseNotesURL ();

		[Export ("fileURL")]
		NSUrl FileURL ();

		[Export ("DSASignature")]
		string DSASignature ();

		[Export ("minimumSystemVersion")]
		string MinimumSystemVersion ();

		[Export ("propertiesDictionary")]
		NSDictionary PropertiesDictionary ();

	}	

	[BaseType (typeof (NSObject))]
	[Model]
	interface SUVersionComparison {
		[Abstract]
		[Export ("compareVersion:toVersion:")]
		NSComparisonResult CompareVersiontoVersion (string versionA, string versionB);

	}

	/*Sparkle uses an informal delegate protocol for it's delegates as follows

	interface NSObject {
		[Export ("updaterShouldPromptForPermissionToCheckForUpdates:")]
		bool UpdaterShouldPromptForPermissionToCheckForUpdates (SUUpdater bundle);

		[Export ("updater:didFinishLoadingAppcast:")]
		void UpdaterdidFinishLoadingAppcast (SUUpdater updater, SUAppcast appcast);

		[Export ("bestValidUpdateInAppcast:forUpdater:")]
		SUAppcastItem BestValidUpdateInAppcastforUpdater (SUAppcast appcast, SUUpdater bundle);

		[Export ("updater:didFindValidUpdate:")]
		void UpdaterdidFindValidUpdate (SUUpdater updater, SUAppcastItem update);

		[Export ("updaterDidNotFindUpdate:")]
		void UpdaterDidNotFindUpdate (SUUpdater update);

		[Export ("updater:willInstallUpdate:")]
		void UpdaterwillInstallUpdate (SUUpdater updater, SUAppcastItem update);

		[Export ("updater:shouldPostponeRelaunchForUpdate:untilInvoking:")]
		bool UpdatershouldPostponeRelaunchForUpdateuntilInvoking (SUUpdater updater, SUAppcastItem update, NSInvocation invocation);

		[Export ("updaterWillRelaunchApplication:")]
		void UpdaterWillRelaunchApplication (SUUpdater updater);

		[Export ("versionComparatorForUpdater:")]
		id <SUVersionComparison> VersionComparatorForUpdater (SUUpdater updater);

		[Export ("pathToRelaunchForUpdater:")]
		string PathToRelaunchForUpdater (SUUpdater updater);

	}
	
	*/

}