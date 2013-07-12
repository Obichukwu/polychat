using System;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyCompany("Nervlite Designs")]
[assembly: AssemblyProduct("initialzr network")]
[assembly: AssemblyCopyright("Copyright © Nervlite Designs 2013")]
[assembly: AssemblyTrademark("")]

// Make it easy to distinguish Debug and Release (i.e. Retail) builds;
// for example, through the file properties window.
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyDescription("Debug Version")] // a.k.a. "Comments"
#else
[assembly: AssemblyConfiguration("Production")]
[assembly: AssemblyDescription("Production Version")] // a.k.a. "Comments"
#endif
[assembly: CLSCompliantAttribute(true)]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0.0")]