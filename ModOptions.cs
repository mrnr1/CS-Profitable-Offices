using System;
using System.IO;
using System.Xml.Serialization;
using ColossalFramework.Plugins;

namespace CS_Profitable_Offices
{
    public class ModOptions
    {
        private const string OptionsFileName = "Profitable Office ModOptions.xml";
        private static ModOptions _instance;

        public static ModOptions Instance
        {
            get { return _instance != null ? _instance : (_instance = CreateFromFile()); }
        }

        public static int[] OfficeIncomeMultipliers = { 2, 3, 4, 5, 7, 10, 15, 20, 30, 50, 100 };
        public static string[] OfficeIncomeMultipliersStr = { "x2", "x3", "x4", "x5", "x7", "x10", "x15", "x20", "x30", "x50", "x100" };
        public int OfficeIncomeMultiplier;

        public ModOptions()
        {
            OfficeIncomeMultiplier = 5;
        }

        public int GetOfficeIncomeMultiplierIndex()
        {
            var index = Array.IndexOf(OfficeIncomeMultipliers, OfficeIncomeMultiplier);

            if (index == -1) return Array.IndexOf(OfficeIncomeMultipliers, 5);  // Default to 5 if out of range

            return index;
        }

        public void Save()
        {
            try
            {
                var ser = new XmlSerializer(typeof(ModOptions));
                TextWriter writer = new StreamWriter(OptionsFileName);
                ser.Serialize(writer, this);
                writer.Close();
            }
            catch (Exception ex)
            {
                DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "Profitable Office Mod: " + ex.Message);
            }
        }

        public static ModOptions CreateFromFile()
        {
            if (!File.Exists(OptionsFileName))
            {
                DebugOutputPanel.AddMessage(PluginManager.MessageType.Error, "Unable to load options file \"" + OptionsFileName + "\", file not found!");
                return new ModOptions();
            }

            try
            {
                var ser = new XmlSerializer(typeof(ModOptions));
                TextReader reader = new StreamReader(OptionsFileName);
                var instance = (ModOptions)ser.Deserialize(reader);
                reader.Close();

                return instance;
            }
            catch (Exception ex)
            {
                DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "Profitable Office Mod (CreateFromFile): " + ex.Message);

                return new ModOptions();
            }
        }
    }
}