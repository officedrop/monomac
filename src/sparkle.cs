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
		void SetDelegate (NSObject delegateHandler);

		[Export ("setUserAgentString:")]
		void SetUserAgentString (string userAgentString);

		[Export ("items")]
		SUAppcastItem[] Items {[Bind("items")] get;}
	}

	[BaseType (typeof (NSObject))]
	interface SUUpdater {

		[Static]
		[Export ("updaterForBundle:")]
		SUUpdater UpdaterForBundle (NSBundle bundle);

		[Export ("setDelegate:")]
		void SetDelegate (NSObject delegateHandler);

		[Export ("checkForUpdates:")]
		void CheckForUpdates ();

		[Export ("checkForUpdatesInBackground")]
		void CheckForUpdatesInBackground ();

		[Export ("hostBundle")]
		NSBundle HostBundle { [Bind("hostBundle")] get;}

		[Export ("checkForUpdateInformation")]
		void CheckForUpdateInformation ();

		[Export ("resetUpdateCycle")]
		void ResetUpdateCycle ();

		[Export ("lastUpdateCheckDate")]
		NSDate LastUpdateCheckDate { [Bind("lastUpdateCheckDate")] get; }

		[Static]
		[Export ("sharedUpdater")]
		SUUpdater SharedUpdater { [Bind("sharedUpdater")] get;}

		[Export ("updateInProgress")]
		bool UpdateInProgress  { [Bind("updateInProgress")] get;}

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
		NSDictionary Dict { [Bind("dict")] get; }

		[Export ("title")]
		string Title { [Bind("title")] get; }

		[Export ("versionString")]
		string VersionString { [Bind("versionString")] get; }

		[Export ("displayVersionString")]
		string DisplayVersionString { [Bind("displayVersionString")] get; }

		[Export ("date")]
		NSDate Date { [Bind("date")] get; }

		[Export ("itemDescription")]
		string ItemDescription { [Bind("itemDescription")] get; }

		[Export ("releaseNotesURL")]
		NSUrl ReleaseNotesURL { [Bind("releaseNotesURL")] get; }

		[Export ("fileURL")]
		NSUrl FileURL { [Bind("fileURL")] get; }

		[Export ("DSASignature")]
		string DSASignature { [Bind("DSASignature")] get; }

		[Export ("minimumSystemVersion")]
		string MinimumSystemVersion { [Bind("minimumSystemVersion")] get; }

		[Export ("propertiesDictionary")]
		NSDictionary PropertiesDictionary { [Bind("propertiesDictionary")] get; }

	}	

	[BaseType (typeof (NSObject))]
	[Model]
	interface SUVersionComparison {
		[Abstract]
		[Export ("compareVersion:toVersion:")]
		NSComparisonResult CompareVersiontoVersion (string versionA, string versionB);

	}

	[BaseType (typeof (NSObject))]
	interface SUUnarchiver {

		[Export("setDelegate:")]
		void SetDelegate( NSObject delegateHandler );

		[Export("start")]
		void Start();

		[Static]
		[Export("unarchiverForPath:updatingHost:")]
		SUUnarchiver UnarchiverForPath( string path, SUHost host );

	}

	[BaseType (typeof (NSObject))]
	interface SUHost {

		[Static]
		[Export("systemVersionString")]
		string SystemVersionString { [Bind("systemVersionString")] get; }

		[Export("bundle")]
		NSBundle Bundle { [Bind("bundle")] get; }

		[Export("bundlePath")]
		string BundlePath { [Bind("bundlePath")] get; }

		[Export("appSupportPath")] 
		string AppSupportPath { [Bind("appSupportPath")] get; }

		[Export("installationPath")]
		string InstallationPath { [Bind("installationPath")] get;}

		[Export("name")]
		string Name { [Bind("name")] get; }

		[Export("version")]
		string Version {[Bind("version")] get;}

		[Export("displayVersion")]
		string DisplayVersion {[Bind("displayVersion")] get;}

		[Export("icon")]
		NSImage Icon {[Bind("icon")] get;}

		[Export("isRunningOnReadOnlyVolume")]
		bool RunningOnReadOnlyVolume {
			[Bind("isRunningOnReadOnlyVolume")] get;
		}

		[Export("isBackgroundApplication")] 
		bool BackgroundApplication {
			[Bind("isBackgroundApplication")] get;
		}

		[Export("publicDSAKey")]
		string PublicDSAKey {
			[Bind("publicDSAKey")] get;
		}

		[Export("systemProfile")]
		NSArray SystemProfile { [Bind("systemProfile")] get; }

		[Export("objectForInfoDictionaryKey:")]
		NSObject ObjectForInfoDictionaryKey( string key );

		[Export("boolForInfoDictionaryKey:")]
		bool BoolForInfoDictionaryKey( string key );

		[Export("objectForUserDefaultsKey:")]
		NSObject ObjectForUserDefaultsKey( string key );

		[Export("setObject:forUserDefaultsKey:")]
		void SetObjectForUserDefaults( NSObject value, string key );

		[Export("boolForUserDefaultsKey:")]
		bool BoolForUserDefaultsKey(string key);

		[Export("setBool:forUserDefaultsKey:")]
		void SetBoolForUserDefaultsKey( bool value, string key );

		[Export("objectForKey")]
		NSObject ObjectForKey( string key );

		[Export("boolForKey")]
		bool BoolForKey( string key );

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