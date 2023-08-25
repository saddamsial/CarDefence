using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("upgradeLevel", "priceToUse", "ammoCount", "bulletDamage", "attackSpeed", "reloadTime", "ammoUsePerShot")]
	public class ES3UserType_ActiveSkillStats : ES3Type
	{
		public static ES3Type Instance = null;

		public ES3UserType_ActiveSkillStats() : base(typeof(ActiveSkillStats)){ Instance = this; priority = 1;}


		public override void Write(object obj, ES3Writer writer)
		{
			var instance = (ActiveSkillStats)obj;
			
			writer.WriteProperty("upgradeLevel", instance.upgradeLevel, ES3Type_int.Instance);
			writer.WriteProperty("priceToUse", instance.priceToUse, ES3Type_float.Instance);
			writer.WriteProperty("ammoCount", instance.ammoCount, ES3Type_int.Instance);
			writer.WriteProperty("bulletDamage", instance.bulletDamage, ES3Type_int.Instance);
			writer.WriteProperty("attackSpeed", instance.attackSpeed, ES3Type_float.Instance);
			writer.WriteProperty("reloadTime", instance.reloadTime, ES3Type_float.Instance);
			writer.WriteProperty("ammoUsePerShot", instance.ammoUsePerShot, ES3Type_int.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			var instance = new ActiveSkillStats();
			string propertyName;
			while((propertyName = reader.ReadPropertyName()) != null)
			{
				switch(propertyName)
				{
					
					case "upgradeLevel":
						instance.upgradeLevel = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "priceToUse":
						instance.priceToUse = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "ammoCount":
						instance.ammoCount = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "bulletDamage":
						instance.bulletDamage = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "attackSpeed":
						instance.attackSpeed = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "reloadTime":
						instance.reloadTime = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "ammoUsePerShot":
						instance.ammoUsePerShot = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
			return instance;
		}
	}


	public class ES3UserType_ActiveSkillStatsArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ActiveSkillStatsArray() : base(typeof(ActiveSkillStats[]), ES3UserType_ActiveSkillStats.Instance)
		{
			Instance = this;
		}
	}
}