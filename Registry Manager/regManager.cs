using System;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Registry_Manager
{
    public class RegistryNotWritableException : ApplicationException
    {
        public RegistryNotWritableException(string keyPath)
            : base("This instance of RegistryBrowser doesn't possess write access.")
        {
            base.Data.Add("KeyPath", keyPath);
        }
    }

    public class RegistryBrowser
    {
        RegistryKey currentKey, regRoot, tempKey;
        bool writeable;
        string temp;

        public string FullPath
        {
            get
            {
                return currentKey.Name;
            }
        }

        public int SubKeyCount
        {
            get
            {
                return currentKey.SubKeyCount;
            }
        }

        public int ValueCount
        {
            get
            {
                return currentKey.ValueCount;
            }
        }

        public RegistryBrowser(RegistryKey root, bool writeable)
        {
            if (root == null)
                throw new ArgumentNullException("root", "The root parameter cannot be null");

            regRoot = CopyKey(root, writeable);
            currentKey = CopyKey(regRoot, writeable);
            this.writeable = writeable;
        }

        public RegistryBrowser(RegistryKey root, string subKey, bool writeable)
        {
            if (root == null)
                throw new ArgumentNullException("root", "The root parameter cannot be null");

            regRoot = CopyKey(root, writeable);
            currentKey = regRoot.OpenSubKey(subKey, writeable);
            this.writeable = writeable;
        }

        private static RegistryKey CopyKey(RegistryKey k, bool writeable)
        {
            string[] pathParts = k.Name.Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries);
            RegistryKey currentKey = null;

            switch (pathParts[0].ToUpper())
            {
                case "HKEY_CLASSES_ROOT":
                    currentKey = Registry.ClassesRoot;
                    break;
                case "HKEY_CURRENT_CONFIG":
                    currentKey = Registry.CurrentConfig;
                    break;
                case "HKEY_CURRENT_USER":
                    currentKey = Registry.CurrentUser;
                    break;
                case "HKEY_DYN_DATA":
                    currentKey = Registry.DynData;
                    break;
                case "HKEY_LOCAL_MACHINE":
                    currentKey = Registry.LocalMachine;
                    break;
                case "HKEY_PERFORMANCE_DATA":
                    currentKey = Registry.PerformanceData;
                    break;
                case "HKEY_USERS":
                    currentKey = Registry.Users;
                    break;
            }
            if (pathParts.Length == 1)
                return currentKey;
            currentKey = currentKey.OpenSubKey(k.Name.Substring(k.Name.IndexOf(@"\") + 1), writeable);
            return currentKey;
        }

        public bool BrowseTo(string subKey)
        {
            tempKey = currentKey;
            currentKey = currentKey.OpenSubKey(subKey, writeable);
            if (currentKey == null)
            {
                currentKey = tempKey;
                return false;
            }
            else if(!tempKey.Equals(regRoot))
                tempKey.Close();
            return true;
        }

        public bool GotoParent()
        {
            if (currentKey.Name != regRoot.Name)
            {
                tempKey = currentKey;
                temp = currentKey.Name;
                temp = temp.Substring(temp.IndexOf("\\") + 1);
                if (temp.LastIndexOf("\\") > 0)
                {
                    temp = temp.Substring(0, temp.LastIndexOf("\\"));
                    currentKey = regRoot.OpenSubKey(temp, writeable);
                }
                else
                    currentKey = regRoot;
                if (currentKey == null)
                {
                    currentKey = tempKey;
                    return false;
                }
                else
                    tempKey.Close();
                return true;
            }
            return false;
        }

        public object GetValue(string valName)
        {
            return currentKey.GetValue(valName);
        }

        public void SetValue(string valName, object value, RegistryValueKind valKind)
        {
            if (!writeable)
                throw new RegistryNotWritableException(currentKey.Name);
            
            currentKey.SetValue(valName, value, valKind);
        }

        public bool CheckKeyExists(string keyName)
        {
            try
            {
                if (currentKey.OpenSubKey(keyName, false) == null)
                    return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        public void CreateSubKey(string keyName)
        {
            if (!writeable)
                throw new RegistryNotWritableException(currentKey.Name);
            
            currentKey.CreateSubKey(keyName);
        }

        public void DeleteSubKey(string keyName)
        {
            if (!writeable)
                throw new RegistryNotWritableException(currentKey.Name);

            currentKey.DeleteSubKey(keyName);
        }

        public void DeleteSubKeyTree(string keyName)
        {
            if (!writeable)
                throw new RegistryNotWritableException(currentKey.Name);

            currentKey.DeleteSubKeyTree(keyName);
        }

        public bool DeleteValue(string valName)
        {
            if (!writeable)
                throw new RegistryNotWritableException(currentKey.Name);

            try
            {
                currentKey.DeleteValue(valName, true);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public string[] GetSubKeyNames()
        {
            return currentKey.GetSubKeyNames();
        }

        public string[] GetValueNames()
        {
            return currentKey.GetValueNames();
        }

        public RegistryValueKind GetValueKind(string valName)
        {
            return currentKey.GetValueKind(valName);
        }

        public void Close()
        {
            currentKey.Close();
        }

        public void GotoRoot()
        {
            if (currentKey.Name != regRoot.Name)
            {
                currentKey.Close();
                currentKey = CopyKey(regRoot, writeable);
            }
        }
    }
}