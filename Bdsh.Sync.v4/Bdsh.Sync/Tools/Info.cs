using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace Bdsh.Sync.Tools
{
    class Info
    {
        string ram = "2";
        public static string GetWindowsVersion()
        {
            string name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                           select x.GetPropertyValue("Caption")).FirstOrDefault().ToString();

            string bits = Environment.Is64BitOperatingSystem ? "64 bits" : "32 bits";
            string version = Environment.OSVersion.Version.ToString();
            string sp = Environment.OSVersion.ServicePack.ToString();

            return $"{name} - {bits} - {version} {sp}";
        }

        public static IEnumerable<string> GetDotNet1To4Versions()
        {
            RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                            .OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\");

            foreach (string keyName in ndpKey.GetSubKeyNames())
            {
                if (keyName == "v4")
                    continue;

                if (keyName.StartsWith("v"))
                {
                    RegistryKey versionKey = ndpKey.OpenSubKey(keyName);

                    string name = versionKey.GetValue("Version", "").ToString();

                    string sp = versionKey.GetValue("SP", "").ToString();

                    string install = versionKey.GetValue("Install", "").ToString();

                    if (string.IsNullOrEmpty(install))
                        yield return $"{keyName} {name}";

                    else if (!string.IsNullOrEmpty(sp) && install == "1")
                        yield return $"{keyName} {name} SP{sp}";

                    if (!string.IsNullOrEmpty(name))
                        continue;

                    foreach (string subKeyName in versionKey.GetSubKeyNames())
                    {
                        RegistryKey subKeyVersion = versionKey.OpenSubKey(subKeyName);

                        name = (string)subKeyVersion.GetValue("Version", "");

                        if (!string.IsNullOrEmpty(name))
                            sp = subKeyVersion.GetValue("SP", "").ToString();

                        install = subKeyVersion.GetValue("Install", "").ToString();

                        if (string.IsNullOrEmpty(install))
                            yield return $"{keyName} {name}";

                        else if (!string.IsNullOrEmpty(sp) && install == "1")
                            yield return $"{subKeyName} {name} SP{sp}";

                        else if (install == "1")
                            yield return $"{subKeyName} {name}";
                    }
                }
            }
        }

        public static string GetDotNet45PlusVersion()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey);

            if (ndpKey != null && ndpKey.GetValue("Release") != null)
            {
                int releaseKey = (int)ndpKey.GetValue("Release");

                if (releaseKey >= 461808)
                    return "4.7.2 or later";
                if (releaseKey >= 461308)
                    return "4.7.1";
                if (releaseKey >= 460798)
                    return "4.7";
                if (releaseKey >= 394802)
                    return "4.6.2";
                if (releaseKey >= 394254)
                    return "4.6.1";
                if (releaseKey >= 393295)
                    return "4.6";
                if (releaseKey >= 379893)
                    return "4.5.2";
                if (releaseKey >= 378675)
                    return "4.5.1";
                if (releaseKey >= 378389)
                    return "4.5";
            }

            return null;
        }
    }
}
