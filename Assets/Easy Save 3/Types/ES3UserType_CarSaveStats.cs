using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("carTorqueAdd", "carMassAdd", "carBaseTorque", "carBaseMass", "carBaseHealPoints", "classType", "scoreСoefficient", "carBaseDamage", "carBaseDamageBlock", "reduceSkillPriceCost", "goodIntervalDuration", "activeSkills")]
	public class ES3UserType_CarSaveStats : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_CarSaveStats() : base(typeof(CarSaveStats)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (CarSaveStats)obj;
			
			writer.WriteProperty("carTorqueAdd", instance.carTorqueAdd, ES3Type_int.Instance);
			writer.WriteProperty("carMassAdd", instance.carMassAdd, ES3Type_int.Instance);
			writer.WriteProperty("carBaseTorque", instance.carBaseTorque, ES3Type_int.Instance);
			writer.WriteProperty("carBaseMass", instance.carBaseMass, ES3Type_int.Instance);
			writer.WriteProperty("carBaseHealPoints", instance.carBaseHealPoints, ES3Type_int.Instance);
			writer.WriteProperty("classType", instance.classType);
			writer.WriteProperty("scoreСoefficient", instance.scoreСoefficient, ES3Type_float.Instance);
			writer.WriteProperty("carBaseDamage", instance.carBaseDamage, ES3Type_int.Instance);
			writer.WriteProperty("carBaseDamageBlock", instance.carBaseDamageBlock, ES3Type_int.Instance);
			writer.WriteProperty("reduceSkillPriceCost", instance.reduceSkillPriceCost, ES3Type_int.Instance);
			writer.WriteProperty("goodIntervalDuration", instance.goodIntervalDuration, ES3Type_float.Instance);
			writer.WriteProperty("activeSkills", instance.activeSkills);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (CarSaveStats)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "carTorqueAdd":
						instance.carTorqueAdd = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "carMassAdd":
						instance.carMassAdd = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "carBaseTorque":
						instance.carBaseTorque = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "carBaseMass":
						instance.carBaseMass = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "carBaseHealPoints":
						instance.carBaseHealPoints = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "classType":
						instance.classType = reader.Read<ClassType>();
						break;
					case "scoreСoefficient":
						instance.scoreСoefficient = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "carBaseDamage":
						instance.carBaseDamage = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "carBaseDamageBlock":
						instance.carBaseDamageBlock = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "reduceSkillPriceCost":
						instance.reduceSkillPriceCost = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "goodIntervalDuration":
						instance.goodIntervalDuration = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "activeSkills":
						instance.activeSkills = reader.Read<System.Collections.Generic.List<ActiveSkillType>>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new CarSaveStats();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_CarSaveStatsArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CarSaveStatsArray() : base(typeof(CarSaveStats[]), ES3UserType_CarSaveStats.Instance)
		{
			Instance = this;
		}
	}
}