using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Утилита работы с картами")]
[assembly: AssemblyDescription("Утилита работы с картами Mifare для системы ParkMaster"
#if DEBUG
 + " (DEBUG build)"
#else
 + " (RELEASE build)"
#endif
)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Штрих-М")]
[assembly: AssemblyProduct("ParkMaster")]
[assembly: AssemblyCopyright("Copyright © shtrih 2009")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("cfae411e-3d9f-4312-8ad2-40cdb46b386d")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
