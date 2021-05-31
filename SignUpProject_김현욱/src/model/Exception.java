package model;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

import javax.swing.*;

public class Exception {

	private Constants constants = new Constants();
	
	
	public boolean checkIdInput(String check) {
		if(Pattern.matches(constants.ID_REGEX, check)) 
		{
			return true;
		}
		return false;
	}
	
	public boolean checkPasswordInput(String check) {
		if(Pattern.matches(constants.PASSWORD_REGEX, check)) 
		{
			return true;
		}
		return false;
	}
}
