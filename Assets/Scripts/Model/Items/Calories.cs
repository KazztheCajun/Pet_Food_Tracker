using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calories {

	public enum Unit { KPP, KPO, KPG }; // 0 = Kilograms per Pound ; 1 = Kilograms per Ounce ; 2 = Kilograms per Grams
	
	private double calPerG;
	private double calPerOZ;
	private double calPerLB;

	public Calories(double calInfo, Unit units) 
	{
		switch (units)
		{
			case Unit.KPP:
				this.calPerG = (calInfo / 0.453592) / 1000; // 1 lb = 2.2046 kg ; 1 kg = 1000g
				this.calPerOZ = calInfo / 16.0; // 1 lb = 16 oz
				this.calPerLB = calInfo;
				break;
			case Unit.KPO:
				this.calPerG = calInfo / 28.3495;  // 1 oz = 28.3495 g
				this.calPerOZ = calInfo;
				this.calPerLB = calInfo * 16.0;
				break;
			case Unit.KPG:
				this.calPerG = calInfo / 1000.0;
				this.calPerOZ = calInfo / 35.274;
				this.calPerLB = calInfo / 2.2046;

				break;
			default:
				throw new ArgumentException("Invalid calorie data or unit type.");
		}
	}

	public static Unit GetUnitsFromString(String s)
	{
		switch (s.ToLower())
		{
			case "kilocalperpound":
				return Unit.KPP;
			case "kilocalperounce":
				return Unit.KPO;
			case "kilocalperkilogram":
				return Unit.KPG;
			default:
				throw new ArgumentException("String is not a valid unit type.");
		}

		
	}	

	// Getters

	public double GetCalPerG() 
	{
		return calPerG;
	}

	public double GetCalPerOZ() 
	{
		return calPerOZ;
	}

	public double GetCalPerLB() 
	{
		return calPerLB;
	}

	// Setters

	// toString
	public override String ToString() 
	{
		return string.Format("kcal per gram: {0:0.0000}", calPerG);
	}

	
}