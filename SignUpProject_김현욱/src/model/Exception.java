package model;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

import javax.swing.*;

public class Exception {

	private Constants constants = new Constants();
	
	
	public boolean checkIdInput(String check) {
		String a = "^[a-z0-9]$"; 
		if(Pattern.matches(a, check)) 
		{
			return true;
		}
		return false;
	}
}
