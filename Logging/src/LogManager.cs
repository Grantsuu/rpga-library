#define DEBUG
//define to enable deubg statements, undef to disable

using System;
using System.Xml;
using System.Collections.Generic;

namespace Rpga.Logging
{
	public class LogManager
	{
		private class LogNode
		{
			public LogNode()
			{
				name = "";
				level = 0;
				output = "";
			}

			public string name {get; set;}
			public int level {get; set;}
			public string output {get; set;}

			public override string ToString() => $"(name: {name}, level: {level}, output: {output})";
		}

		private const String ConfigFile = @"./cfg/logging.xml";
		private const String LogManagerName = "logmanager";

		private List<LogNode> logNodes;
		private List<LogSource> logSources;

		public LogManager()
		{
			LogSelf("Tracing is enabled");

			logNodes = new List<LogNode>();
			logSources = new List<LogSource>();

			try
			{
				//ParseConfigFile();
			}
			catch (Exception) {
				throw;
			}

			for(int i=0; i < logNodes.Count; i++)
			{
				LogSelf(logNodes[i].ToString());
			}
		}

		public bool AddSource()
		{
			return false;
		}
		private void LogSelf(string message)
		{
			#if (DEBUG)
			Console.WriteLine(this.GetType().Name + "::" + (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name + ": " + message);
			#endif
		}
		private void ParseConfigFile()
		{
			XmlDocument doc = new XmlDocument();
		
			try
			{
				doc.Load(ConfigFile);
			}
			catch (Exception)
			{
				throw;
			}

			// Parse the log manager settings
			try
			{
				XmlNodeList lmConfig = doc.GetElementsByTagName(LogManagerName);
			
				if(lmConfig.Count == 1)
				{
					for (int i=0; i < lmConfig.Count; i++)
					{
						LogNode ln = new LogNode();

						if (lmConfig[i].ChildNodes.Count > 0)
						{
							for (int j=0; j < lmConfig[i].ChildNodes.Count; j++)
							{
								switch(lmConfig[i].ChildNodes[j].Name)
								{
									case "level":
										ln.level = Int16.Parse(lmConfig[i].ChildNodes[j].InnerText);
										break;
									case "output":
										ln.output = lmConfig[i].ChildNodes[j].InnerText;
										break;
									default:
										throw new Exception("lmConfig[" + i + "] contains a ChildNode with an unexpected name: " + lmConfig[i].ChildNodes[j].Name);
								}
								LogSelf(lmConfig[i].ChildNodes[j].Name + ": " + lmConfig[i].ChildNodes[j].InnerText);
							}
							ln.name = LogManagerName;
							logNodes.Add(ln);
						}
						else
						{
							throw new Exception("lmConfig[" + i + "] contains no ChildNodes");
						}
					}
				}
				else
				{
					throw new Exception("lmConfig must contain exactly 1 Node. Count: " + lmConfig.Count);
				}
			}
			catch (Exception)
			{
				throw;
			}

			// Parse the log sources
			try
			{
				XmlNodeList elemList = doc.GetElementsByTagName("logsource");

				if(elemList.Count > 0)
				{
					for (int i=0; i < elemList.Count; i++)
					{
						LogNode ln = new LogNode();

						if (elemList[i].ChildNodes.Count > 0)
						{
							for (int j=0; j < elemList[i].ChildNodes.Count; j++)
							{
								switch(elemList[i].ChildNodes[j].Name)
								{
									case "name":
										ln.name = elemList[i].ChildNodes[j].InnerText;
										break;
									case "level":
										ln.level = Int16.Parse(elemList[i].ChildNodes[j].InnerText);
										break;
									case "output":
										ln.output = elemList[i].ChildNodes[j].InnerText;
										break;
									default:
										throw new Exception("elemList[" + i + "] contains a ChildNode with an unexpected name: " + elemList[i].ChildNodes[j].Name);
								}
								LogSelf(elemList[i].ChildNodes[j].Name + ": " + elemList[i].ChildNodes[j].InnerText);
							}
							logNodes.Add(ln);
						}
						else
						{
							throw new Exception("elemList[" + i + "] contains no ChildNodes");
						}
					}
				}
				else
				{
					throw new Exception("elemList contains no elements");
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}