using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrients {
	
	private double fat;
	private double carbs;
	private double protien;
	private double minerals;

	public Nutrients(double fat, double carbs, double protien, double minerals) 
	{
		this.fat = fat;
		this.carbs = carbs;
		this.protien = protien;
		this.minerals = minerals;
	}

	// Getters

	public double GetFat() 
	{
		return fat;
	}

	public double GetCarbs() 
	{
		return carbs;
	}
	
	public double GetProtien() 
	{
		return protien;
	}

	public double GetMinerals() 
	{
		return minerals;
	}

	// Setters

	// toString
	public override String ToString() 
	{
		return string.Format("Fat: {0} | Carbs: {1} | Protien: {2} | Minerals: {3}", fat, carbs, protien, minerals);
	}

}