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
	
	public boolean checkNameInput(String check) {
		if(Pattern.matches(constants.NAME_REGEX, check)) 
		{
			return true;
		}
		return false;
	}
	
	public boolean checkBirthInput(String check) {
		if(Pattern.matches(constants.BIRTH_REGEX, check)) 
		{
			return true;
		}
		return false;
	}
	
	public boolean checkPhoneNumberInput(String check) {
		if(Pattern.matches(constants.PHONENUMBER_REGEX, check)) 
		{
			return true;
		}
		return false;
	}
	
	public boolean checkEmailInput(String check) {
		if(Pattern.matches(constants.EMAIL_REGEX, check)) 
		{
			return true;
		}
		return false;
	}
}
